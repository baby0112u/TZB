using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TZB.Framework.Model
{
    /// <summary>
    /// 邮件信息
    /// </summary>
    [Serializable]
    public class MailInfo : ICloneable
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public MailPriority Priority { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 是否带html格式
        /// </summary>
        public bool IsHtml { get; set; }
        /// <summary>
        /// 编码格式
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 是否嵌入图片资源
        /// </summary>
        public bool LinkImgRes { get; set; }
        /// <summary>
        /// 当以HTML形式发送邮件且嵌入图片资源时，指示图片资源路径
        /// </summary>
        public string ImgDirectory { get; set; }
        /// <summary>
        /// 附件地址列表
        /// </summary>
        public List<string> AttachmentList { get; set; }
        /// <summary>
        /// 附件列表(key:附件文件显示名称，value:附件地址)
        /// </summary>
        public List<KeyValuePair<string, string>> AttachList { get; set; }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public MailAddrInfo MailAddrInfo { get; set; }
        /// <summary>
        /// 获取克隆对象
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            MailInfo info = new MailInfo();
            if (this.AttachList != null)
            {
                info.AttachList = new List<KeyValuePair<string, string>>(this.AttachList.Count);
                foreach (var pair in this.AttachList)
                {
                    KeyValuePair<string, string> p = new KeyValuePair<string, string>(pair.Key, pair.Value);
                    info.AttachList.Add(p);
                }
            }
            if (this.AttachmentList != null)
            {
                info.AttachmentList = new List<string>(this.AttachmentList.Count);
                foreach (string att in this.AttachmentList)
                {
                    info.AttachmentList.Add(att);
                }
            }
            info.Body = this.Body;
            info.Encoding = this.Encoding;
            info.ImgDirectory = this.ImgDirectory;
            info.IsHtml = this.IsHtml;
            info.LinkImgRes = this.LinkImgRes;
            if (this.MailAddrInfo != null)
            {
                info.MailAddrInfo = new MailAddrInfo(this.MailAddrInfo.From, this.MailAddrInfo.To, this.MailAddrInfo.Cc);
                info.MailAddrInfo.Bcc = this.MailAddrInfo.Bcc;
            }
            info.Priority = this.Priority;
            info.Subject = this.Subject;
            return info;
        }
    }
}
