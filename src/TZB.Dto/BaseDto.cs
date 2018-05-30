using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Dto
{
    /// <summary>
    /// Dto基类
    /// </summary>
    public abstract class BaseDto
    {
        /// <summary>
        /// Id integer not null, --主键 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// CreateDateTime date default sysdate not null --创建时间  
        /// </summary>
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
