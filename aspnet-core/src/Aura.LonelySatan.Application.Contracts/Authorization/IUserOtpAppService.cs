using Aura.LonelySatan.Authorization.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan.Authorization
{
    public interface IUserOtpAppService : IApplicationService
    {
        Task CreateUserOtp(UserOtpCreateInputDto input);
    }
}
