using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface IAccountService {
        Task<Account> Get (Guid id);
        Task<IEnumerable<Account>> GetAll ();
        Task<Account> Post (Account client);
        Task<Account> Put (Account client);
        Task<bool> Delete (Guid id);
        Task<Account> Withdraw(Guid id, decimal value);
        Task<Account> Deposit(Guid id, decimal value);
    }
}