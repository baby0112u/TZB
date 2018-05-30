using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace TZB.Framework
{
    /// <summary>
    /// Json数据格式化
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            //格式化的配置
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
        }
        public JsonSerializerSettings Settings { get; private set; }

        /// <summary>
        /// 重写JsonResult的ExecuteResult方法
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;
            //用Setting配置 创建个序列化对象
            var scriptSerializer = JsonSerializer.Create(this.Settings);
            scriptSerializer.Serialize(response.Output, this.Data);
        }
    }
}
