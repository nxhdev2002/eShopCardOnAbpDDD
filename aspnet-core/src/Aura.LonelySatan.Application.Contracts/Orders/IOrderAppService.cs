using Aura.LonelySatan.Satan.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan.Satan
{
    public interface IOrderAppService : IApplicationService
    {
        Task<OrderDto> CreateAsync(OrderCreateDto input);
        Task<OrderDto> GetAsync(Guid id);
        //Task<List<OrderDto>> GetMySatanAsync(GetMySatanInput input);
        //Task<List<OrderDto>> GetSatanAsync(GetSatanInput input);
        //Task<OrderDto> GetByOrderNoAsync(int orderNo);
        //Task SetAsCancelledAsync(Guid id);
        //Task<PagedResultDto<OrderDto>> GetListPagedAsync(PagedAndSortedResultRequestDto input);
    }
}
