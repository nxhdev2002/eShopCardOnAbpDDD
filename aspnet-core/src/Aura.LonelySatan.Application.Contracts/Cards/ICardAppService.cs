using Aura.LonelySatan.Cards.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan.Cards
{
    public interface ICardAppService : IApplicationService
    {
        Task<CardDto> Get(CardGetInputDto input);
        Task<CardDetailsDto> GetDetails(CardGetDetailsInputDto input);
        Task<CardDto> Create(CardCreateDto cardCreateDto);
        Task<CardDto> Lock(CardLockedDto cardLockedDto);
        Task<CardDto> Unlock(CardUnlockedDto cardUnlockedDto);
        Task<PagedResultDto<CardTransactionDto>> GetTransactions(CardTransactionInputDto cardTransactionInputDto);
    }
}
