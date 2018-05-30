using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Framework.Model
{
    /// <summary>
    /// MailServerInfo
    /// </summary>
    [Serializable]
    public class MailServerInfo
    {

        /// <summary>
        /// 邮件服务器
        /// </summary>
        public string Server
        {
            get;
            set;
        }


        /// <summary>
        /// 是否加密
        /// </summary>
        public bool IsEnableSsl
        {
            get;
            set;
        }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// 用户
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get;
            set;
        }


        /// <summary>
        /// MailServerInfo
        /// </summary>
        public MailServerInfo()
        { }
        /// <summary>
        /// MailServerInfo
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        public MailServerInfo(string server, int port)
        {
            this.Server = server;
            this.Port = port;
        }

        /// <summary>
        /// MailServerInfo
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public MailServerInfo(string server, int port, string username, string password)
            : this(server, port)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
