using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;

namespace OpenBank.Infra.Data.Context
{
    internal class AgenciaEntityTypeConfiguration : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.ToTable("Agencia");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name);
            builder.Property(a => a.Code).ValueGeneratedOnAdd();
            builder.HasIndex(a => a.Code).IsUnique();
            builder.Property(a => a.CreatedAt);
        }
    }
}
