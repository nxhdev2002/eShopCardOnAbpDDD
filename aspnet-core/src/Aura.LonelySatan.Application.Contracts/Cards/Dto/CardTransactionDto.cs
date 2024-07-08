using System;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardTransactionDto
    {
        public string Type { get; private set; }
        public string Merchant { get; private set; }
        public CardTransactionStatus Status { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public DateTime CreationTime { get; set; }
    }
}
