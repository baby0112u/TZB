using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework
{
    public class PageList:AjaxResult
    {
        /// <summary>
        /// 返回的分页信息
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}
