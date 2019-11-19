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
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Balance);
            builder.Property(a => a.CreatedAt);
            builder.Property(a => a.IdAgencia);
            builder.Property(a => a.Password);
            builder.Property(a => a.Active).IsRequired();
            builder.Property(a => a.Code).ValueGeneratedOnAdd(); //HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasIndex(a => a.Code).IsUnique();
            builder.HasOne(a => a.Agencia).WithMany(ac => ac.Accounts).HasForeignKey(a => a.IdAgencia);
        }
    }
}
