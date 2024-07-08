using Aura.LonelySatan.Authorization.Dto;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.LonelySatan.Authorization
{
    [Authorize]
    public class UserOtpAppService(UserOtpManager manager) : LonelySatanAppService, IUserOtpAppService
    {
        private readonly UserOtpManager _manager = manager;
        public async Task CreateUserOtp(UserOtpCreateInputDto input)
        {
            await _manager.GenerateOtpAsync(CurrentUser.Id.Value, input.OtpType);
            return;
        }
    }
}
