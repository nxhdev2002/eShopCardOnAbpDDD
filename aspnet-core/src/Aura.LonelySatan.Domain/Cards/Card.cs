using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;

namespace Aura.LonelySatan.Cards
{
    public class Card : AuditedAggregateRoot<Guid>
    {
        [MaxLength(16)]
        public string CardNumber { get; private set; }
        public DateTime ExpDate { get; private set; }
        public Cvv Cvv { get; private set; }

        [Range(0, double.MaxValue)]
        public decimal? Balance { get; private set; }
        public CardStatus Status { get; private set; }
        
        //public Guid OrderId { get; private set; }

        private Card() { }

        public Card(Guid Id, 
            string cardNumber, 
            DateTime expDate, 
            Cvv cvv,
            CardStatus status = CardStatus.Unknown
        ) : base(Id)
        {
            CardNumber = Check.NotNullOrEmpty(cardNumber, nameof(cardNumber));
            ExpDate = expDate;
            Cvv = cvv;
            Balance = 0;
            Status = status;
        }

        public Card SetCardAsActive()
        {
            if (Status == CardStatus.Active)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardAlreadyActive).WithData(nameof(Card), this);
            }

            Status = CardStatus.Active;
            return this;
        }

        public Card SetCardAsInActive()
        {
            if (Status == CardStatus.Inactive)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardAlreadyInactive);
            }

            Status = CardStatus.Inactive;
            return this;
        }

        public Card FundingCard(decimal Amount)
        {
            if (Amount <= 0)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.InvalidFundingAmount).WithData(nameof(Amount), Amount);
            }

            if (Status == CardStatus.Inactive)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsInActive).WithData(nameof(Card), this);
            }

            if (ExpDate < DateTime.UtcNow)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsExpired);
            }

            Balance += Amount;
            return this;
        }

        public Card SpendingCard(decimal Amount)
        {
            if (Amount <= 0)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.InvalidSpendingAmount);
            }

            if (Status == CardStatus.Inactive)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsInActive);
            }

            if (ExpDate < DateTime.UtcNow)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsExpired);
            }

            if (Balance < Amount)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.InsufficientFundingAmount);
            }
            Balance -= Amount;
            return this;
        }

    }
}
