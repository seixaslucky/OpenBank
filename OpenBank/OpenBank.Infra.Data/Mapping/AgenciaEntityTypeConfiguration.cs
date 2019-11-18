using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Infra.Data.Context
{
    internal class AgenciaEntityTypeConfiguration : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.ToTable("Agencia");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name);
            builder.Property(a => a.CreatedAt);

            builder.HasData(
                new Agencia{}
            );
        }
    }
}
