using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Dto
{
    public class Permission:BaseDto
    {
        /// <summary>
        /// Description varchar2(1000) not null, --权限描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Name varchar2(100) not null, --权限名称
        /// </summary>
        public string Name { get; set; }
    }
}
