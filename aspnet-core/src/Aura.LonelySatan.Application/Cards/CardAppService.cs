using Aura.LonelySatan.Cards.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Aura.LonelySatan.Cards
{
    public class CardAppService : ApplicationService, ICardAppService
    {
        private readonly CardManager _cardManager;
        private readonly ICardRepository _cardRepository;
        private readonly ICardTransactionRepository _cardTransactionRepository;

        public CardAppService(CardManager cardManager, ICardRepository cardRepository, ICardTransactionRepository cardTransactionRepository)
        {
            _cardManager = cardManager;
            _cardRepository = cardRepository;
            _cardTransactionRepository = cardTransactionRepository;
        }

        public async Task<CardDto> Get(CardGetInputDto input)
        {
            var card = await _cardRepository.GetAsync(input.Id);
            return card.Adapt<CardDto>();
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

        public async Task<PagedResultDto<CardTransactionDto>> GetTransactions(CardTransactionInputDto cardTransactionInputDto)
        {
            var result = await _cardTransactionRepository.GetTransactionByCardId(cardTransactionInputDto.CardId);
            var pagedAndFiltered = result.Skip(cardTransactionInputDto.SkipCount).Take(cardTransactionInputDto.MaxResultCount).ToList()
                .Adapt<List<CardTransactionDto>>();

            return new PagedResultDto<CardTransactionDto>(
                result.Count,
                pagedAndFiltered);
        }
    }
}
