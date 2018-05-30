using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Entity
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id integer not null, --主键 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// IsDeleted integer default 0 not null, --状态 
        /// </summary>
        public int IsDeleted { get; set; } = 0;
        /// <summary>
        /// CreateDateTime date default sysdate not null --创建时间  
        /// </summary>
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
