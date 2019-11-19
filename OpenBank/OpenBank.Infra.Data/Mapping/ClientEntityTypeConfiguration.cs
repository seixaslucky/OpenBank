using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Infra.Data.Context
{
    internal class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.BirthDate).IsRequired();
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.Property(c => c.Cpf);
            builder.Property(c => c.CreatedAt);
        }
    }
}
