using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TZB.Admin.Web.Models
{
    public class RolePermAddModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long[] PermissionIds { get; set; }
    }
}