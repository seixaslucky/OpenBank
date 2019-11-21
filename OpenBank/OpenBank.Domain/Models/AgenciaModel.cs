using OpenBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class AgenciaModel : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
