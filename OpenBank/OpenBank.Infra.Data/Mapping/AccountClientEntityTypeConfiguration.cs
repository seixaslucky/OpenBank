using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Infra.Data.Context.EntitiesConfiguration
{
    internal class AccountClientEntityTypeConfiguration : IEntityTypeConfiguration<AccountClient>
    {
        public void Configure(EntityTypeBuilder<AccountClient> builder)
        {
            builder.ToTable("AccountClient");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedAt);
            builder.HasOne(a => a.Account).WithMany(ac => ac.AccountClients).HasForeignKey(a => a.IdAccount);
            builder.HasOne(c => c.Client).WithMany(ac => ac.AccountClients).HasForeignKey(c => c.IdClient);
        }
    }
}
