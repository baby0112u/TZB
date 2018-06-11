using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.EntityConfig
{
    public class Permission : EntityTypeConfiguration<Entity.Permission>
    {
        public Permission()
        {
            ToTable("TBL_PERMISSION");

            HasMany(u => u.Roles).WithMany(p => p.Permissions).Map(m => m.ToTable("Tbl_RolePermissions")
                .MapLeftKey("RoleId").MapRightKey("PermissionId"));
            // Description varchar2(1000) not null, --权限描述
            Property(p => p.Description).HasMaxLength(1000).IsRequired();
            // Name varchar2(100) not null, --权限名称
            Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
