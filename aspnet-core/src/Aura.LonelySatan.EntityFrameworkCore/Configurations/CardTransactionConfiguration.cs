﻿using Aura.LonelySatan.Cards;
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
