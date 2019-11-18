
using Microsoft.EntityFrameworkCore;
using OpenBank.Domain.Entities;
using OpenBank.Infra.Data.Context.EntitiesConfiguration;

namespace OpenBank.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
             : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountClient> AccountClients { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AgenciaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());

        }
    }
}
