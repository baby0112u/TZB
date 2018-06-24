using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TZB.Admin.Web.Models
{
    public class RolePermEditPostModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public long[] PermissionIds { get; set; }
    }
}