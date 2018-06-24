using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TZB.Admin.Web.Models
{
    public class RolePermEditGetModel
    {
        public Dto.Role Role { get; set; }
        public Dto.Permission[] AllPermissions { get; set; }
        public Dto.Permission[] OwnPermissions { get; set; }
    }
}