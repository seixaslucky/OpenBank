using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace OpenBank.Infra.Data.Context
{
    internal class MovementEntityTypeConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movement");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedAt);
            builder.Property(t => t.Success);
            builder.Property(t => t.Type);
            builder.Property(t => t.Value);
            builder.HasOne(t => t.Account).WithMany(c => c.Movements).HasForeignKey(a => a.IdAccount);
        }
    }
}
