using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.EntityConfig
{
    public class Settings : EntityTypeConfiguration<Entity.Settings>
    {
        public Settings()
        {
            ToTable("TBL_Settings");

        }
    }
}
