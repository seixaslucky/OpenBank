using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class AccountModel : BaseEntity
    {
        public decimal Balance { get; set; }
        public int Code { get; set; }
        public Guid IdAgencia { get; set; }
        public bool Active { get; set; }
    }
}
