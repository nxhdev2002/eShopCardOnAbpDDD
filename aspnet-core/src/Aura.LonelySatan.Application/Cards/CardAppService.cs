using Aura.LonelySatan.Cards.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan.Cards
{
    public class CardAppService : ApplicationService, ICardAppService
    {
        private readonly CardManager _cardManager;
        private readonly ICardRepository _cardRepository;

        public CardAppService(CardManager cardManager, ICardRepository cardRepository)
        {
            _cardManager = cardManager;
            _cardRepository = cardRepository;
        }

        public async Task<CardDto> CreateAsync(CardCreateDto cardCreateDto)
        {
            var card = await _cardManager.CreateCardAsync("Test", DateTime.Now, "123");
            await _cardManager.FundingCardAsync(card, cardCreateDto.Amount);

            return card.Adapt<CardDto>();
        }
    }
}
