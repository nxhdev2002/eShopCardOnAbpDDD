using Aura.LonelySatan.Cards.Dto;
using Bogus;
using Bogus.DataSets;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Aura.LonelySatan.Cards
{
    [Authorize]
    public class CardAppService : LonelySatanAppService, ICardAppService
    {
        private readonly CardManager _cardManager;
        private readonly ICardRepository _cardRepository;

        public CardAppService(CardManager cardManager, ICardRepository cardRepository)
        {
            _cardManager = cardManager;
            _cardRepository = cardRepository;
        }

        public async Task<CardDto> Get(CardGetInputDto input)
        {
            var card = await _cardRepository
                .GetCardByUserIdAsync(CurrentUser.Id.GetValueOrDefault(), input.Id)
                ?? throw new UserFriendlyException(L["CardNotFound"]);
            return card.Adapt<CardDto>();
        }

        public async Task<CardDto> Create(CardCreateDto cardCreateDto)
        {
            var faker = new Faker();

            var card = await _cardManager.CreateCardAsync(
                faker.Finance.CreditCardNumber(CardType.Visa), 
                DateTime.Now,
                faker.Finance.CreditCardCvv()
                );
            card.FundingCard(cardCreateDto.Amount);

            return card.Adapt<CardDto>();
        }

        public async Task<CardDto> Lock(CardLockedDto cardLockedDto)
        {
            var card = await _cardRepository.GetCardByUserIdAsync(
                    CurrentUser.Id.GetValueOrDefault(),
                    cardLockedDto.CardId
                ) ?? throw new UserFriendlyException(L["CardNotFound"]);
            card.SetCardAsInActive();

            return card.Adapt<CardDto>();
        }

        public async Task<CardDto> Unlock(CardUnlockedDto cardUnlockedDto)
        {
            var card = await _cardRepository.GetCardByUserIdAsync(
                    CurrentUser.Id.GetValueOrDefault(),
                    cardUnlockedDto.CardId
                ) ?? throw new UserFriendlyException(L["CardNotFound"]);
            card.SetCardAsActive();

            return card.Adapt<CardDto>();
        }

        public async Task<PagedResultDto<CardTransactionDto>> GetTransactions(CardTransactionInputDto cardTransactionInputDto)
        {
            var card = await _cardRepository
                .GetCardByUserIdAsync(CurrentUser.Id.GetValueOrDefault(), cardTransactionInputDto.CardId)
                ?? throw new UserFriendlyException(L["CardNotFound"]);
            var transactions = card.Transactions.Adapt<List<CardTransactionDto>>();
            var pagedAndFiltered = transactions
                .Skip(cardTransactionInputDto.SkipCount)
                .Take(cardTransactionInputDto.MaxResultCount).ToList();

            return new PagedResultDto<CardTransactionDto>(
                    transactions.Count,
                    pagedAndFiltered
                );
        }

        public async Task<CardDetailsDto> GetDetails(CardGetDetailsInputDto input)
        {
            //var card = await _cardManager.Get
            return null;
        }
    }
}
