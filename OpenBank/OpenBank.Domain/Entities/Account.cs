using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class Account : BaseEntity
    {
        public double Balance { get; set; }
        public Guid IdAgencia { get; set; }
        public bool Active { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual ICollection<AccountClient> AccountClients { get; set; }
        public virtual ICollection<Transaction> TransactionsFrom { get; set; }
        public virtual ICollection<Transaction> TransactionsTo { get; set; }
    }
}
