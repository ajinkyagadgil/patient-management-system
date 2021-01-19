using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("Users", Schema = "User")]
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")]
        public Guid RoleId { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
