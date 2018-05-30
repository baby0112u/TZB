using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework.Model
{
    /// <summary>
    /// 邮件配置信息
    /// </summary>
    [Serializable]
    public class MailConfigInfo
    {
        /// <summary>
        /// 邮件服务
        /// </summary>
        public MailServerInfo ServerInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 邮件信息
        /// </summary>
        public MailInfo MailInfo
        {
            get;
            set;
        }

    }
}
