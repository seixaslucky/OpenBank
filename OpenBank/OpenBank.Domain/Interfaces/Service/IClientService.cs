using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service
{
    public interface IClientService
    {
        Task<Client> Get(Guid id);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> Post(Client client, Guid idAgencia);
        Task<Client> Put(Client client);
        Task<bool> Delete(Guid id);
    }
}
