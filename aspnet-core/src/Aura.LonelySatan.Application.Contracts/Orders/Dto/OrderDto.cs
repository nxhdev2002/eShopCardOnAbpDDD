using Aura.LonelySatan.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Satan.Dto
{
    public class OrderDto : EntityDto<Guid>
    {
        public int OrderNo { get; set; }
        public OrderStatus Status { get; set; }
        public CustomerDto Customer { get; set; }
        public OrderAddressDto Address { get; set; }
    }
}
