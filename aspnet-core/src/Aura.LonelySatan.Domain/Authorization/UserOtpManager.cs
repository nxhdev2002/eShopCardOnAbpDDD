using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;
using Volo.Abp.Security.Encryption;

namespace Aura.LonelySatan.Authorization
{
    public class UserOtpManager : DomainService
    {
        private readonly IUserOtpRepository _userOtpRepository;
        private readonly IStringEncryptionService _stringEncryptionService;
        private readonly IEmailSender _emailSender;

        public UserOtpManager(
            IUserOtpRepository userOtpRepository, 
            IStringEncryptionService stringEncryptionService,
            IEmailSender emailSender
        )
        {
            _userOtpRepository = userOtpRepository;
            _stringEncryptionService = stringEncryptionService;
            _emailSender = emailSender;
        }

        public async Task<UserOtp> GenerateOtpAsync(Guid user, UserOtpType otpType)
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");

            var otpEncrypted = _stringEncryptionService.Encrypt(sixDigitNumber);
            var existingOtp = await _userOtpRepository.FindAsync(x => x.User == user && x.Type == otpType);

            await SendOtpToEmailAsync(otpEncrypted, "xuanhoangv7c@gmail.com"); // wrong, because it's not business logic
            if (existingOtp != null)
            {
                existingOtp.SetNewOtp(otpEncrypted, DateTime.UtcNow.AddHours(LonelySatanConsts.DefaultOTPExpirationTimeInMinutes));
                return await _userOtpRepository.UpdateAsync(existingOtp, true); // wrong, because it's not business logic, don't save any changes in domain service
            } else
            {
                var otp = new UserOtp(user, otpEncrypted, otpType, DateTime.UtcNow.AddHours(LonelySatanConsts.DefaultOTPExpirationTimeInMinutes));
                return await _userOtpRepository.InsertAsync(otp, true); // wrong, because it's not business logic, don't save any changes in domain service
            }
        }

        public async Task<bool> ValidateOtpAsync(IdentityUser user, string otp, UserOtpType otpType)
        {
            return (await _userOtpRepository.GetOtpAsync(user, otp, otpType)) != null;
        }

        private async Task SendOtpToEmailAsync(string otpEncrypted, string emailAddress)
        {
            await _emailSender.QueueAsync(emailAddress, "OTP", otpEncrypted);
        }
    }
}
