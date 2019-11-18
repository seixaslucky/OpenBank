using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface ITransactionService {
        Task<Transaction> Get (Guid id);
        Task<IEnumerable<Transaction>> GetAll ();
        Task<Transaction> Post (Transaction client);
        Task<Transaction> Put (Transaction client);
        Task<bool> Delete (Guid id);
    }
}