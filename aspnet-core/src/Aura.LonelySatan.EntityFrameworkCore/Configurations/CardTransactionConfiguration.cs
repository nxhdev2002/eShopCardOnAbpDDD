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
    internal class CardTransactionConfiguration : IEntityTypeConfiguration<CardTransaction>
    {
        public void Configure(EntityTypeBuilder<CardTransaction> b)
        {
            b.ToTable("CardTransactions");
            b.ConfigureByConvention(); //auto configure for the base class props
            //b.OwnsOne(o => o.Cvv, a => { a.WithOwner(); });
            //b.OwnsMany(o => o.Transactions, a => { a.WithOwner(); });

            b.Property(q => q.Status).HasConversion(new EnumToStringConverter<CardTransactionStatus>());
        }
    }
}
