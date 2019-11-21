using OpenBank.Domain.Entities;
using System;

namespace OpenBank.Domain.Models
{
    public class ClientModel : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
