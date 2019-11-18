using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class AccountClient : BaseEntity
    {
        public Guid IdAccount { get; set; }
        public Guid IdClient { get; set; }
        public virtual Account Account {get;set;}
        public virtual Client Client {get;set;}
    }
}
