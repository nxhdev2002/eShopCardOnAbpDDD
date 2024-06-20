using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Aura.LonelySatan.Cards
{
    public class CardManager : DomainService
    {
        private readonly ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> CreateCardAsync(
                               string cardNumber, DateTime expDate, string Cvv)
        {
            Card card = new Card(
                GuidGenerator.Create(),
                cardNumber,
                expDate,
                new Cvv(Cvv)
            );

            var placedCard = await _cardRepository.InsertAsync(card, true);

            return placedCard;
        }
    }
}
