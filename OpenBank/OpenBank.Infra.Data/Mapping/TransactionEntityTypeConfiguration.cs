using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace OpenBank.Infra.Data.Context
{
    internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedAt);
            builder.Property(t => t.Success);
            builder.Property(t => t.Type);
            builder.Property(t => t.Value);
            builder.HasOne(t => t.From).WithMany(c => c.TransactionsFrom).HasForeignKey(a => a.IdAccountFrom);
            builder.HasOne(t => t.To).WithMany(c => c.TransactionsTo).HasForeignKey(a => a.IdAccountTo);
        }
    }
}
