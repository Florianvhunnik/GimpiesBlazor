using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static System.String;

namespace GimpiesBlazor.Models.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = Empty;

        [Required, MaxLength(50), EmailAddress]
        public string Email { get; set; } = Empty;

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = Empty;

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Role))]
        public int FkRoleId { get; set; }

        public virtual required Role Role { get; set; }
    }
}