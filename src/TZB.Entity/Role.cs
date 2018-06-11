using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Entity
{
    public class Role:BaseEntity
    {
        /// <summary>
        /// Description varchar2(1000) not null, --角色描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Name varchar2(100) not null, --角色名称
        /// </summary>
        public string Name { get; set; }

        //既可以一张表对应一个Entity，关系表也建立实体，也可以像这样直接让对象带属性，隐式的关系表
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public virtual ICollection<UserPwd> UserPwds { get; set; } = new List<UserPwd>();
    }
}
