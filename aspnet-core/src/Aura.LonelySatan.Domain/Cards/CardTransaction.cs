using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace Aura.LonelySatan.Cards
{
    public class CardTransaction : FullAuditedEntity<Guid>
    {
        public string Type { get; private set; }
        public string Merchant { get; private set; }
        public CardTransactionStatus Status { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public Guid CardId { get; private set; }

        private CardTransaction() { }

        public CardTransaction(Guid id, Guid cardId, string type, string merchant, CardTransactionStatus status, decimal amount, string currency) : base(id)
        {
            CardId = cardId;
            Type = Check.NotNullOrWhiteSpace(type, nameof(type));
            Merchant = Check.NotNullOrWhiteSpace(merchant, nameof(merchant));
            Status = status;
            Amount = amount;
            Currency = Check.NotNullOrWhiteSpace(currency, nameof(currency));
        }

    }
}
