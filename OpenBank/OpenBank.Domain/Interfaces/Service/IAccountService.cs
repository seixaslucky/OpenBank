using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface IAccountService {
        Task<Account> Get (Guid id);
        Task<Account> Get (int agenciaCode, int accountCode, string password);
        Task<IEnumerable<Account>> GetAll ();
        Task<Account> Post (Agencia agencia, Client client, string password);
        Task<Account> Put (Account client);
        Task<bool> Delete (Guid id);
        Task<Account> Withdraw(Guid id, decimal value, string password);
        Task<Account> Deposit(Guid id, decimal value, string password);
        Task<Account> AddClientToAccount(Guid id, Client client, string password);
    }
}