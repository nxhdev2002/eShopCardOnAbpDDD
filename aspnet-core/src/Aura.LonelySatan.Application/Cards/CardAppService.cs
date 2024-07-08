using Aura.LonelySatan.Cards.Dto;
using Bogus;
using Bogus.DataSets;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Aura.LonelySatan.Cards
{
    [Authorize]
    public class CardAppService(
        CardManager cardManager,
        ICardRepository cardRepository,
        IRepository<IdentityUser, Guid> userRepository
            ) : LonelySatanAppService, ICardAppService
    {
        private readonly CardManager _cardManager = cardManager;
        private readonly ICardRepository _cardRepository = cardRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository = userRepository;

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

            var user = await GetAndCheckIfUserHasValidBalance(cardCreateDto.Amount);

            //if (_userRepository.GetAsync(CurrentUser.Id)
            var card = await _cardManager.CreateCardAsync(
                faker.Finance.CreditCardNumber(CardType.Visa),
                DateTime.Now,
                faker.Finance.CreditCardCvv()
                );
            card.FundingCard(cardCreateDto.Amount);
            await AdjustUserBalance(user, cardCreateDto.Amount);
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

        #region Private Methods

        private async Task<IdentityUser> GetAndCheckIfUserHasValidBalance(decimal MinBalance)
        {
            var user = await _userRepository.GetAsync(CurrentUser.Id.GetValueOrDefault());
            var balance = user.ExtraProperties["Balance"] ?? throw new UserFriendlyException(L["InsufficientBalance"]);
            if ((decimal)balance < MinBalance)
                throw new UserFriendlyException(L["InsufficientBalance"]);

            return user;
        }

        private async Task AdjustUserBalance(IdentityUser User, decimal Amount)
        {
            User.ExtraProperties["Balance"] = (decimal)User.ExtraProperties["Balance"] - Amount;
            await _userRepository.UpdateAsync(User, true);
        }
        #endregion
    }
}
