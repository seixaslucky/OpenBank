using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Entities
{
    public class Movement : BaseEntity
    {
        public Guid? IdAccount { get; set; }
        public int Type { get; set; }
        public decimal Value { get; set; }
        public bool Success { get; set; }
        public virtual Account Account { get; set; }
    }
}
