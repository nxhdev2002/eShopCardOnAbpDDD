using Aura.LonelySatan.Cards;
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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> b)
        {
            b.ToTable("Cards");
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Navigation(a => a.Transactions).UsePropertyAccessMode(PropertyAccessMode.Property);
            b.OwnsOne(o => o.Cvv, a => { 
                a.Property(v => v.Value)
                .IsRequired()
                .HasColumnName("Cvv")
                .HasMaxLength(3);
            });

            b.Property(q => q.Status).HasConversion(new EnumToStringConverter<CardStatus>());
        }
    }
}
