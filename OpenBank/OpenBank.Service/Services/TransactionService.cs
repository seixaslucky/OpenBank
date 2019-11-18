using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBank.Service.Services
{
    public class TransactionService : ITransactionService
    {
         private IRepository<Transaction> _repository;
        public TransactionService(IRepository<Transaction> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<Transaction> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return  await _repository.SelectAsync();
        }

        public async Task<Transaction> Post(Transaction transaction)
        {
            return await _repository.InsertAsync(transaction);
        }

        public async Task<Transaction> Put(Transaction transaction)
        {
            return await _repository.UpdateAsync(transaction);
        }
    }
}