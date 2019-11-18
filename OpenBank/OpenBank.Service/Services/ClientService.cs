using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBank.Service.Services
{
    public class ClientService : IClientService
    {
        private IRepository<Client> _repository;
        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<Client> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return  await _repository.SelectAsync();
        }

        public async Task<Client> Post(Client client)
        {
            return await _repository.InsertAsync(client);
        }

        public async Task<Client> Put(Client client)
        {
            return await _repository.UpdateAsync(client);
        }
    }
}
