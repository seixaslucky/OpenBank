using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface IAgenciaService {
        Task<Agencia> Get (Guid id);
        Task<IEnumerable<Agencia>> GetAll ();
        Task<Agencia> Post (Agencia client);
        Task<Agencia> Put (Agencia client);
        Task<bool> Delete (Guid id);
    }
}