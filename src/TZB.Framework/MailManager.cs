using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TZB.Framework.Model;

namespace TZB.Framework
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailManager
    {

        #region 邮件发送
        /*
        1、调用的时候记录数据库
        2、MailServerInfo配置到Web.config中
        */
        #endregion

        //邮件地址分隔
        private static readonly char[] MailAddrSpliters = new char[] { ',', ';', ' ' };
        private static object lockHelper = new object();
        private static readonly string ResImgPathMatchRegex = "(?<=<\\s*img\\s*.*?src\\s*=\\s*\").*?\\.\\w+(?=\")";

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="mailserverinfo">邮件服务器信息</param>
        /// <param name="mailInfo">邮件内容相关信息</param>
        /// <param name="isAsync">false:同步、true:异步</param>
        public static void Send(MailServerInfo mailserverinfo, MailInfo mailInfo, bool isAsync)
        {
            lock (lockHelper)
            {
                MailMessage message = new MailMessage();
                SmtpClient mailClient = new SmtpClient(mailserverinfo.Server, mailserverinfo.Port);
                if (!string.IsNullOrEmpty(mailserverinfo.Username) && !string.IsNullOrEmpty(mailserverinfo.Password))
                {
                    mailClient.Credentials = new System.Net.NetworkCredential(mailserverinfo.Username, mailserverinfo.Password);
                }
                else
                {
                    mailClient.UseDefaultCredentials = true;
                }

                mailClient.EnableSsl = mailserverinfo.IsEnableSsl; //是否加密
                FillMessage(ref message, mailInfo);//邮件消息

                if (isAsync)
                {
                    mailClient.SendAsync(message, null);
                }
                else
                {
                    mailClient.Send(message);
                }
            }
        }

        #region 邮件基本填充
        /// <summary>
        /// 邮件处理
        /// </summary>
        /// <param name="message">MailMessage</param>
        /// <param name="mailInfo">MailInfo</param>
        private static void FillMessage(ref MailMessage message, MailInfo mailInfo)
        {
            //主题，正文
            GetSubject(ref message, mailInfo);
            //处理地址
            GetMailAddrInfo(ref message, mailInfo);
            // 处理附件
            GetAttachmentInfo(ref message, mailInfo);
            // 处理图片
            GetMailImagesInfo(ref message, mailInfo);

        }

        /// <summary>
        /// 邮件主题
        /// </summary>
        /// <param name="message">MailMessage</param>
        /// <param name="mailInfo">MailInfo</param>
        private static void GetSubject(ref MailMessage message, MailInfo mailInfo)
        {
            message.Subject = mailInfo.Subject;
            message.IsBodyHtml = mailInfo.IsHtml;
            message.Body = mailInfo.Body;
            message.BodyEncoding = mailInfo.Encoding;//编码
            message.Priority = mailInfo.Priority;

        }

        /// <summary>
        ///  邮件地址
        /// </summary>
        /// <param name="message">MailMessage</param>
        /// <param name="mailInfo">MailInfo</param>
        private static void GetMailAddrInfo(ref MailMessage message, MailInfo mailInfo)
        {
            MailAddrInfo addrInfo = mailInfo.MailAddrInfo;
            if (addrInfo != null)
            {
                // 处理地址
                if (!string.IsNullOrEmpty(addrInfo.From))
                {
                    message.From = new MailAddress(addrInfo.From);
                }
                FillAddress(message.To, addrInfo.To);
                FillAddress(message.CC, addrInfo.Cc);
                FillAddress(message.Bcc, addrInfo.Bcc);
            }
        }

        /// <summary>
        /// 处理附件
        /// </summary>
        /// <param name="message">MailMessage</param>
        /// <param name="mailInfo">MailInfo</param>
        private static void GetAttachmentInfo(ref MailMessage message, MailInfo mailInfo)
        {
            if (mailInfo.AttachmentList != null && mailInfo.AttachmentList.Count > 0)
            {
                foreach (string attachPath in mailInfo.AttachmentList)
                {
                    message.Attachments.Add(new Attachment(attachPath));
                }
            }

            if (mailInfo.AttachList != null && mailInfo.AttachList.Count > 0)
            {
                System.IO.StreamReader sr = null;
                foreach (KeyValuePair<string, string> attach in mailInfo.AttachList)
                {
                    sr = new System.IO.StreamReader(attach.Value);
                    message.Attachments.Add(new Attachment(sr.BaseStream, attach.Key));
                }
                //if (sr != null) sr.Close();
            }
        }

        /// <summary>
        /// 处理邮件图片
        /// </summary>
        /// <param name="message">MailMessage</param>
        /// <param name="mailInfo">MailInfo</param>
        private static void GetMailImagesInfo(ref MailMessage message, MailInfo mailInfo)
        {
            if (mailInfo.IsHtml && mailInfo.LinkImgRes)
            {
                string html = mailInfo.Body;
                List<LinkedResource> imgResources = GetImgResources(ref html, mailInfo.ImgDirectory);
                AlternateView view = AlternateView.CreateAlternateViewFromString(html, mailInfo.Encoding, MediaTypeNames.Text.Html);
                foreach (LinkedResource res in imgResources)
                    view.LinkedResources.Add(res);
                message.AlternateViews.Add(view);
            }
        }

        /// <summary>
        /// 邮件地址转换
        /// </summary>
        /// <param name="addressColl">MailAddressCollection</param>
        /// <param name="addressStr">邮件地址</param>
        private static void FillAddress(MailAddressCollection addressCollection, string addressStr)
        {
            if (!string.IsNullOrEmpty(addressStr))
            {
                string[] addresses = addressStr.Split(MailAddrSpliters);
                foreach (string address in addresses)
                {
                    if (!string.IsNullOrEmpty(address))
                        addressCollection.Add(address);
                }
            }
        }

        /// <summary>
        /// 图片资源处理
        /// </summary>
        /// <param name="html">邮件内容html</param>
        /// <param name="imgDirectory">图片目录</param>
        /// <returns></returns>
        private static List<LinkedResource> GetImgResources(ref string html, string imgDirectory)
        {
            List<LinkedResource> result = new List<LinkedResource>();
            MatchCollection matches = Regex.Matches(html, ResImgPathMatchRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            StringBuilder strBulder = new StringBuilder(html);
            string imgPath, imgID;//, imgName;
            int index = 0;
            LinkedResource res;
            foreach (Match match in matches)
            {
                imgPath = match.Value; //img/003.png
                                       // imgName = Regex.Match(imgPath, ResImgNameRegex).Value;  //003.png
                imgID = "Img" + index.ToString();
                strBulder.Replace(imgPath, "cid:" + imgID);
                //res = new LinkedResource(imgDirectory + imgName, "image/jpeg");
                res = new LinkedResource(imgDirectory + imgPath, "image/jpeg");
                res.ContentId = imgID;
                res.TransferEncoding = TransferEncoding.Base64;
                result.Add(res);
                index++;
            }
            html = strBulder.ToString();
            return result;
        }
        #endregion

    }
}
