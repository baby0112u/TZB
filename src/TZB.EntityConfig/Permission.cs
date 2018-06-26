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
            ToTable("Tbl_Permission");
            //MapLeftKey为HasMany里p(Permission)所指，MapRightKey为WithMany里r(Role)所指的
            HasMany(p => p.Roles).WithMany(r => r.Permissions).Map(m => m.ToTable("Tbl_RolePermissions")
                .MapLeftKey("PermissionId").MapRightKey("RoleId"));
            // Description varchar2(1000) not null, --权限描述
            Property(p => p.Description).HasMaxLength(1000).IsRequired();
            // Name varchar2(100) not null, --权限名称
            Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
