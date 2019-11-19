using System;
using System.Collections.Generic;

namespace OpenBank.Domain.Entities {
    public class Account : BaseEntity {
        private decimal _balance { get; set; }
        public int Code { get; set; }
        private string _password { get; set; }
        public Guid IdAgencia { get; set; }
        public bool Active { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual ICollection<AccountClient> AccountClients { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }
        public decimal Balance {
            get { return _balance; }
            set {
                _balance = value < 0 ?
                    throw new ArgumentException ("not enough balance") : value;
            }
        }

        public string Password {
            get { return _password; }
            set {_password =_password == null? value: throw new ArgumentException ("use ChangePassword method");}
        }

        public bool ChangePassword (string oldP, string newP) {
            if (String.IsNullOrEmpty (newP)) return false;
            if (oldP != _password) return false;
            this._password = newP;
            return true;
        }
    }
}