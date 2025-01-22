using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}