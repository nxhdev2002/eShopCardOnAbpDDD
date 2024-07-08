using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Aura.LonelySatan.Authorization
{
    public class UserOtp : AggregateRoot<Guid>
    {
        public Guid User { get; set; }
        public string Otp { get; set; }
        public UserOtpType Type { get; set; }
        public DateTime ExpirationTime { get; set; }

        private UserOtp() { }

        public UserOtp(Guid user, string otp, UserOtpType type, DateTime expirationTime)
        {
            User = user;
            Otp = otp;
            Type = type;
            ExpirationTime = expirationTime;
        }

        public UserOtp SetNewOtp(string otp, DateTime expirationTime)
        {
            Otp = otp;
            ExpirationTime = expirationTime;
            return this;
        }
    }
}
