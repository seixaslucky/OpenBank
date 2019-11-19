using System;
using System.Collections.Generic;

namespace OpenBank.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<AccountClient> AccountClients { get; set; }
    }
}
