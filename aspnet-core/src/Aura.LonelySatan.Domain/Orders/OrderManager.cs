using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Aura.LonelySatan.Orders
{
    public class OrderManager : DomainService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(
                    Guid customer, 
                    string customerName, string customerEmail, 
                    string addressStreet, string addressCity, string addressCountry, string addressZipCode, string addressDescription = null)
        {
            Order order = new Order(
                    id: GuidGenerator.Create(),
                    customer: new Customer(customerEmail, customerName, customer),
                    address: new Address(addressStreet, addressCity, addressCountry, addressZipCode, addressDescription)
            );

            var placedOrder = await _orderRepository.InsertAsync(order, true);
            return placedOrder;
        }

    }
}
