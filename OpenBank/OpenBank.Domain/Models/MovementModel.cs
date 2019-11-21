using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class MovementModel : BaseEntity
    {
        public Guid? IdAccount { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public bool Success { get; set; }
    }
}
