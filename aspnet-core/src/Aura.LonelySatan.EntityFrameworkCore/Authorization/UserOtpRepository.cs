using Aura.LonelySatan.Cards;
using Aura.LonelySatan.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace Aura.LonelySatan.Authorization
{
    public class UserOtpRepository : EfCoreRepository<LonelySatanDbContext, UserOtp, Guid>, IUserOtpRepository
    {
        public UserOtpRepository(IDbContextProvider<LonelySatanDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<UserOtp?> GetOtpAsync(IdentityUser User, string OTP, UserOtpType OTPType, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetQueryableAsync();
            var result = await dbSet
                .FirstOrDefaultAsync(x => 
                        x.Otp == OTP && 
                        x.User == User.Id && 
                        x.Type == OTPType &&
                        x.ExpirationTime > DateTime.UtcNow,
                        cancellationToken: GetCancellationToken(cancellationToken));

            return result;
        }
    }
}
