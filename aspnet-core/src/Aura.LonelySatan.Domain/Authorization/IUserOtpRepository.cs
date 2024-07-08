using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Aura.LonelySatan.Authorization
{
    public interface IUserOtpRepository : IRepository<UserOtp, Guid>
    {
        public Task<UserOtp?> GetOtpAsync(IdentityUser User, string OTP, UserOtpType OTPType, CancellationToken cancellationToken = default);
    }
}
