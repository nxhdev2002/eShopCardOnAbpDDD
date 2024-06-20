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
        public string CardNumber { get; private set; }
        public DateTime ExpDate { get; private set; }
        public Cvv Cvv { get; private set; }
        public decimal? Balance { get; private set; }
        public CardStatus Status { get; private set; }
        public List<CardTransaction> Transactions { get; private set; }

        private Card() { }

        internal Card(Guid Id, string cardNumber, DateTime expDate, Cvv cvv) : base(Id)
        {
            CardNumber = Check.NotNullOrEmpty(cardNumber, nameof(cardNumber));
            ExpDate = expDate;
            Cvv = cvv;
            Balance = 0;
            Status = CardStatus.Unknown;
            Transactions = new List<CardTransaction>();
        }

        public Card AddCardTransaction(Guid id, Guid cardId, string type, string merchant, CardTransactionStatus status, decimal amount, string currency)
        {
            var cardTrans = new CardTransaction(id, cardId, type, merchant, status, amount, currency);
            Transactions.Add(cardTrans);

            return this;
        }

        public Card SetCardAsActive()
        {
            if (Status == CardStatus.Active)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardAlreadyActive);
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
                throw new BusinessException(LonelySatanDomainErrorCodes.InvalidFundingAmount);
            }

            if (Status == CardStatus.Inactive)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsInActive);
            }

            if (ExpDate < DateTime.UtcNow)
            {
                throw new BusinessException(LonelySatanDomainErrorCodes.CardIsExpired);
            }

            Balance += Amount;
            AddCardTransaction(
                Guid.NewGuid(),
                Id,
                "Funding",
                "Banking",
                CardTransactionStatus.Accepted,
                Amount,
                "USD"
            );
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

            AddCardTransaction(
                Guid.NewGuid(),
                Id,
                "Spending",
                "Banking",
                CardTransactionStatus.Accepted,
                Amount,
                "USD"
            );
            return this;
        }

        public decimal GetTotalSpend()
        {
            return Transactions.Sum(x => x.Amount);
        }
    }
}
