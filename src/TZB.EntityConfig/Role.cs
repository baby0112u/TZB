using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.EntityConfig
{
    public class Role : EntityTypeConfiguration<Entity.Role>
    {
        public Role()
        {
            ToTable("TBL_ROLE");
            // Description varchar2(1000) not null, --角色描述
            Property(r => r.Description).HasMaxLength(1000).IsRequired();
            // Name varchar2(100) not null, --角色名称
            Property(r => r.Name).HasMaxLength(100).IsRequired();
        }
    }
}
