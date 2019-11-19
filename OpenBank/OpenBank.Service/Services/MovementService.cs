using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBank.Service.Services
{
    public class MovementService : IMovementService
    {
         private IRepository<Movement> _repository;
        public MovementService(IRepository<Movement> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<Movement> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetAll()
        {
            return  await _repository.SelectAsync();
        }

        public async Task<Movement> Post(Movement Movement)
        {
            return await _repository.InsertAsync(Movement);
        }

        public async Task<Movement> Put(Movement Movement)
        {
            return await _repository.UpdateAsync(Movement);
        }

        public async Task<IEnumerable<Movement>> GetByDateInerval(DateTime startDate, DateTime endDate, Guid idAccount){
            return await _repository.Find(x => x.CreatedAt>= startDate && x.CreatedAt<=endDate && x.IdAccount == idAccount);
        }
    }
}