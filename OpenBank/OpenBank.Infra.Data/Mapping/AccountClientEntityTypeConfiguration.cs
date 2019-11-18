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
        private static Account account = new Account{
                    CreatedAt = DateTime.UtcNow,
                    Balance = 1000,
                    Active = true,
                    Agencia = new Agencia{
                        Name = "Agencia001",
                        CreatedAt = DateTime.UtcNow
                    },
                };
        
        private static Client client = new Client{
            BirthDate = new DateTime(1993,1,13),
            Cpf = "00000000000",
            Name = "Lucky Seixas",
            CreatedAt = DateTime.UtcNow
        };

        private static AccountClient accountClient = new AccountClient {
            Account = account,
            Client = client,
            CreatedAt = DateTime.UtcNow
        };

        public void Configure(EntityTypeBuilder<AccountClient> builder)
        {
            builder.ToTable("AccountClient");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedAt);
            builder.HasOne(a => a.Account).WithMany(ac => ac.AccountClients).HasForeignKey(a => a.IdAccount);
            builder.HasOne(c => c.Client).WithMany(ac => ac.AccountClients).HasForeignKey(c => c.IdClient);

            builder.HasData(
                accountClient
            );
        }
    }
}
