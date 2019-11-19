﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Entities;

namespace OpenBank.Infra.Data.Context.EntitiesConfiguration {
    internal class AccountClientEntityTypeConfiguration : IEntityTypeConfiguration<AccountClient> {
        private static Account account = new Account {
            Id = Guid.NewGuid (),
            CreatedAt = DateTime.UtcNow,
            Balance = 0,
            Active = true,
            Agencia = new Agencia {
            Name = "Agencia1",
            CreatedAt = DateTime.UtcNow
            },
        };

        private static Client client = new Client {
            Id = Guid.NewGuid (),
            BirthDate = new DateTime (1993, 1, 13),
            Cpf = "00000000000",
            Name = "Lucky Seixas",
            CreatedAt = DateTime.UtcNow
        };

        private static AccountClient accountClient = new AccountClient {
            Id = Guid.NewGuid (),
            Account = account,
            Client = client,
            CreatedAt = DateTime.UtcNow
        };

        public void Configure (EntityTypeBuilder<AccountClient> builder) {
            builder.ToTable ("AccountClient");
            builder.HasKey (a => a.Id);
            builder.Property (a => a.CreatedAt);
            builder.HasOne (a => a.Account).WithMany (ac => ac.AccountClients).HasForeignKey (a => a.IdAccount);
            builder.HasOne (c => c.Client).WithMany (ac => ac.AccountClients).HasForeignKey (c => c.IdClient);

        }
    }
}