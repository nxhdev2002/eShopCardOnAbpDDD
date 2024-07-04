using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Aura.LonelySatan.Authorization
{
    public class UserOtp : AggregateRoot<Guid>
    {
        public IdentityUser User { get; set; }
        public int Otp {  get; set; }
        public UserOtpType Type { get; set; }
        public DateTime ExpirationTime { get; set; }

        private UserOtp() { }

        public UserOtp(IdentityUser user, int otp, UserOtpType type, DateTime expirationTime)
        {
            User = user;
            Otp = otp;
            Type = type;
            ExpirationTime = expirationTime;
        }

        public UserOtp SetNewOtp(int otp)
        {
            Otp = otp;
            return this;
        }
    }
}
