using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBank.Service.Services
{
    public class AgenciaService : IAgenciaService
    {
        private IRepository<Agencia> _repository;
        public AgenciaService(IRepository<Agencia> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<Agencia> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Agencia>> GetAll()
        {
            return  await _repository.SelectAsync();
        }

        public async Task<Agencia> Post(Agencia agencia)
        {
            return await _repository.InsertAsync(agencia);
        }

        public async Task<Agencia> Put(Agencia agencia)
        {
            return await _repository.UpdateAsync(agencia);
        }
    }
}