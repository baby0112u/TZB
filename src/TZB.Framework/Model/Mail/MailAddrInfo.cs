using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework.Model
{
    /// <summary>
    /// MailAddrInfo
    /// </summary>
    [Serializable]
    public class MailAddrInfo
    {
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// 抄送地址
        /// </summary>
        public string Cc { get; set; }
        /// <summary>
        /// 密送地址
        /// </summary>
        public string Bcc { get; set; }
        /// <summary>
        /// MailAddrInfo
        /// </summary>
        public MailAddrInfo() { }
        /// <summary>
        /// MailAddrInfo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MailAddrInfo(string from, string to)
        {
            this.From = from;
            this.To = to;
        }
        /// <summary>
        /// MailAddrInfo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        public MailAddrInfo(string from, string to, string cc)
            : this(from, to)
        {
            this.Cc = cc;
        }
    }
}
