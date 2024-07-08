using Aura.LonelySatan.Cards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Aura.LonelySatan.Configurations
{
    public class CardTransactionConfiguration : IEntityTypeConfiguration<CardTransaction>
    {
        public void Configure(EntityTypeBuilder<CardTransaction> builder)
        {
            builder.ToTable("CardTransactions");
            builder.ConfigureByConvention();
            builder.Property<Guid>("CardId").IsRequired();
        }
    }
}
