using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;

namespace OpenBank.Service.Services {
    public class ClientService : IClientService {
        private IRepository<Client> _repository;
        public ClientService (IRepository<Client> repository) {
            _repository = repository;
        }
        public async Task<bool> Delete (Guid id) {
            return await _repository.RemoveAsync (id);
        }

        public async Task<Client> Get (Guid id) {
            return await _repository.SelectAsync (id);
        }

        public async Task<IEnumerable<Client>> GetAll () {
            return await _repository.SelectAsync ();
        }

        public async Task<Client> Post (Client client, Guid idAgencia) {
            //generate a new account when a client is created
            Account account = new Account {
                Id = Guid.NewGuid (),
                Active = true,
                IdAgencia = idAgencia,
                Balance = 0,
                CreatedAt = DateTime.UtcNow
            };

            AccountClient accountClient = new AccountClient{
                Id = Guid.NewGuid(),
                Account = account,
                Client = client,
                CreatedAt = DateTime.UtcNow
            };

            client.AccountClients = new List<AccountClient>();
            client.AccountClients.Add(accountClient);
            return await _repository.InsertAsync (client);
        }

        public async Task<Client> Put (Client client) {
            return await _repository.UpdateAsync (client);
        }
    }
}