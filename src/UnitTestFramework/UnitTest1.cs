using System;
using System.Configuration;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TZB.Framework;
using TZB.Framework.Model;

namespace UnitTestFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MailServerInfo serverInfo = new MailServerInfo();
            serverInfo.Server = ConfigurationManager.AppSettings["SmtpServer"];
            serverInfo.Username = ConfigurationManager.AppSettings["SmtpUserName"];
            serverInfo.Password = ConfigurationManager.AppSettings["SmtpPassword"];
            string smtpFrom = ConfigurationManager.AppSettings["SmtpFrom"];

            MailInfo mailInfo = new MailInfo();
            mailInfo.IsHtml = true;
            mailInfo.MailAddrInfo.From = smtpFrom;   //发送人邮箱地址
            mailInfo.MailAddrInfo.To = "573365799@qq.com";                    //收件人邮箱地址
            mailInfo.Subject = "20180109报表";                  //主题
            mailInfo.Body = "fdsjaklwifjlak";                        //正文

            MailManager.Send(serverInfo, mailInfo, true);
        }
    }
}
