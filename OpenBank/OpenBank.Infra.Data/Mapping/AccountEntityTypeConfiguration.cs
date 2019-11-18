
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;

namespace OpenBank.Infra.Data.Context
{
    internal class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Balance);
            builder.Property(a => a.CreatedAt);
            builder.Property(a => a.Active).IsRequired();
            builder.HasOne(a => a.Agencia).WithMany(ac => ac.Accounts).HasForeignKey(a => a.IdAgencia);
        }
    }
}
