using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Service.Services
{
    public class AccountClientService : IAccountClientService
    {
        private IRepository<AccountClient> _repository;
        public AccountClientService(IRepository<AccountClient> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<AccountClient> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<AccountClient>> GetAll()
        {
            return  await _repository.SelectAsync();
        }

        public async Task<AccountClient> Post(AccountClient accountClient)
        {
            return await _repository.InsertAsync(accountClient);
        }

        public async Task<AccountClient> Put(AccountClient accountClient)
        {
            return await _repository.UpdateAsync(accountClient);
        }
    }
}