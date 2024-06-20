using Aura.LonelySatan.Cards.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan.Cards
{
    public interface ICardAppService : IApplicationService
    {
        Task<CardDto> CreateAsync(CardCreateDto cardCreateDto);
    }
}
