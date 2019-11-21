using OpenBank.Domain.Entities;
using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service
{
    public interface IClientService
    {
        Task<Client> Get(Guid id);
        Task<Client> Get(string cpf);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> Post(Client client);
        Task<Client> Put(Client client);
        Task<bool> Delete(Guid id);
    }
}
