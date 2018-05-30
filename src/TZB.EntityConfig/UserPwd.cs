using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.EntityConfig
{
    public class UserPwd : EntityTypeConfiguration<Entity.UserPwd>
    {
        public UserPwd()
        {
            ToTable("TBL_USERPWD");
        }
    }
}
