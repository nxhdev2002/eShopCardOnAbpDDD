using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.LonelySatan.Satan.Dto
{
    public class OrderCreateDto
    {
        public OrderAddressDto Address { get; set; } = new();
    }
}
