using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;

        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
