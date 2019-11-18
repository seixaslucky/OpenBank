using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid? IdAccountFrom { get; set; }
        public Guid? IdAccountTo { get; set; }
        public int Type { get; set; }
        public decimal Value { get; set; }
        public bool Success { get; set; }
        public virtual Account From { get; set; }
        public virtual Account To { get; set; }
    }
}
