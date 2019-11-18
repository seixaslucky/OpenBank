using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class Agencia : BaseEntity
    {
        public string Endereco { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
