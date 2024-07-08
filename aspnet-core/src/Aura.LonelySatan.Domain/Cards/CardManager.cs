using Aura.LonelySatan.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace Aura.LonelySatan.Cards
{
    public class CardManager : DomainService
    {
        private readonly ICardRepository _cardRepository;
        private readonly UserOtpManager _userOtpManager;
        public CardManager(ICardRepository cardRepository, UserOtpManager userOtpManager)
        {
            _cardRepository = cardRepository;
            _userOtpManager = userOtpManager;
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


        public async Task<Card?> GetCardDetails(IdentityUser user, Guid cardId, string otp)
        {
            var OTP = await _userOtpManager.ValidateOtpAsync(user, otp, UserOtpType.VIEW_CARD);

            return OTP ? throw new BusinessException("User:InvalidOTP") : await _cardRepository.GetCardByUserIdAsync(user.Id, cardId);
        }
    }
}
