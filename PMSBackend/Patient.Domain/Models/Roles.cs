using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("Roles", Schema = "User")]
    public class Roles
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
