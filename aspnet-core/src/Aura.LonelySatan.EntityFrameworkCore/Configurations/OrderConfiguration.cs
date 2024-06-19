using Aura.LonelySatan.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Aura.LonelySatan.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> b)
        {
            b.ToTable("Orders");
            b.ConfigureByConvention(); //auto configure for the base class props
            b.OwnsOne(o => o.Address, a => { a.WithOwner(); });
            b.OwnsOne(o => o.Customer, a => { a.WithOwner(); });

            b.Property(q => q.OrderStatus).HasConversion(new EnumToStringConverter<OrderStatus>());
        }
    }
}
