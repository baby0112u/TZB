using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.Framework;
using TZB.Framework.Model;

namespace MailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MailServerInfo serverInfo = new MailServerInfo();
            serverInfo.Server = ConfigurationManager.AppSettings["SmtpServer"];
            serverInfo.Username = ConfigurationManager.AppSettings["SmtpUserName"];
            serverInfo.Password = ConfigurationManager.AppSettings["SmtpPassword"];
            string smtpFrom = ConfigurationManager.AppSettings["SmtpFrom"];

            MailInfo mailInfo = new MailInfo();
            mailInfo.IsHtml = true;
            mailInfo.MailAddrInfo = new MailAddrInfo();
            mailInfo.MailAddrInfo.From = smtpFrom;   //发送人邮箱地址
            mailInfo.MailAddrInfo.To = "baby0112@yeah.net";                    //收件人邮箱地址
            mailInfo.Subject = "20180109报表";                  //主题
            mailInfo.Body = "fdsjaklwifjlak";                        //正文

            MailManager.Send(serverInfo, mailInfo, true);
        }
    }
}
