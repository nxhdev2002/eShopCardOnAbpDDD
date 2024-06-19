using Aura.LonelyLucifer.Permissions;
using Aura.LonelySatan.Satan;
using Aura.LonelySatan.Satan.Dto;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Aura.LonelySatan.Orders
{
    [Authorize(OrderingServicePermissions.Orders.Default)]
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly OrderManager _orderManager;
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(OrderManager orderManager, IOrderRepository orderRepository)
        {
            _orderManager = orderManager;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> CreateAsync(OrderCreateDto input)
        {
            var placedOrder = await _orderManager.CreateOrderAsync(
                customer: CurrentUser.GetId(),
                customerName: CurrentUser.Name,
                customerEmail: CurrentUser.Email,
                addressStreet: input.Address.Street,
                addressCity: input.Address.City,
                addressCountry: input.Address.Country,
                addressZipCode: input.Address.ZipCode,
                addressDescription: input.Address.Description
            );

            return placedOrder.Adapt<OrderDto>();
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await _orderRepository.GetAsync(id);
            return order.Adapt<OrderDto>();
        }


    }
}
