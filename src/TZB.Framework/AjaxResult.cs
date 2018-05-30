using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework
{
    /// <summary>
    /// ajax类型返回对象
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 执行结果：0成功，1-100失败，101以上返回错误信息
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
    }
}
