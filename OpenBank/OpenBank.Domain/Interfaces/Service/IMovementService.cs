using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank.Domain.Interfaces.Service {
    public interface IMovementService {
        Task<Movement> Get (Guid id);
        Task<IEnumerable<Movement>> GetAll ();
        Task<Movement> Post (Movement client);
        Task<Movement> Put (Movement client);
        Task<bool> Delete (Guid id);
    }
}