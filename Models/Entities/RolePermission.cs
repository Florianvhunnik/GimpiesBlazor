﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GimpiesBlazor.Models.Entities
{
    public class RolePermission
    {
        [ForeignKey(nameof(Role))]
        public int FkRoleId { get; set; }

        [ForeignKey(nameof(Permission))]
        public int FkPermissionId { get; set; }

        public virtual required Role Role { get; set; }
        public virtual required Permission Permission { get; set; }
    }
}