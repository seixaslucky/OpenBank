using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface IAccountClientService {
        Task<AccountClient> Get (Guid id);
        Task<IEnumerable<AccountClient>> GetAll ();
        Task<AccountClient> Post (AccountClient client);
        Task<AccountClient> Put (AccountClient client);
        Task<bool> Delete (Guid id);
    }
}