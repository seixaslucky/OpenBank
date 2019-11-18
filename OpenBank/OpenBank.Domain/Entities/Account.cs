using System;
using System.Collections.Generic;

namespace OpenBank.Domain.Entities
{
    public class Account : BaseEntity
    {
        private decimal _balance { get; set; }
        public Guid IdAgencia { get; set; }
        public bool Active { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual ICollection<AccountClient> AccountClients { get; set; }
        public virtual ICollection<Transaction> TransactionsFrom { get; set; }
        public virtual ICollection<Transaction> TransactionsTo { get; set; }
        public decimal Balance
        {
            get {return _balance;}
            set {_balance = value<0? throw new ArgumentException("not enough balance") : value;}
        }
    }
}
