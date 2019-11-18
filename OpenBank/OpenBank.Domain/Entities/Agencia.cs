using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class Agencia : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
