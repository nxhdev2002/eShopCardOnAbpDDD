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

        public async Task<CardDto> Create(CardCreateDto cardCreateDto)
        {
            var card = await _cardManager.CreateCardAsync("Test", DateTime.Now, "123");
            await _cardManager.FundingCardAsync(card, cardCreateDto.Amount);

            return card.Adapt<CardDto>();
        }

        
        public async Task<CardDto> Lock(CardLockedDto cardLockedDto)
        {
            var card = await _cardRepository.GetByCardNumberAsync(
                    cardLockedDto.CardNumber
                );
            card.SetCardAsInActive();

            return card.Adapt<CardDto>();
        }


        public async Task<CardDto> Unlock(CardUnlockedDto cardUnlockedDto)
        {
            var card = await _cardRepository.GetByCardNumberAsync(
                    cardUnlockedDto.CardNumber
                );
            card.SetCardAsActive();

            return card.Adapt<CardDto>();
        }
    }
}
