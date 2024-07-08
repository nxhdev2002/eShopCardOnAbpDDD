using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Aura.LonelySatan.Orders
{
    public class Order : AuditedAggregateRoot<Guid>
    {
        public int OrderNo { get; private set; }
        public Customer Customer { get; private set; }
        public Address Address { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        private Order() { }

        internal Order(Guid id, Customer customer, Address address) : base(id)
        {
            OrderNo = GenerateOrderNo(id);
            Customer = customer;
            Address = address;

        }

        private int GenerateOrderNo(Guid id)
        {
            // Simple order no generation. Should be improved for uniqueness.
            var code = Id.GetHashCode();
            if (code < 0) // Should be negative
            {
                code *= -1;
            }

            return code;
        }

        internal Order SetOrderAccepted()
        {
            OrderStatus = OrderStatus.Paid;
            return this;
        }

        public Order SetOrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
            return this;
        }
    }



}
