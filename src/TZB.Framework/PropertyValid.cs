using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TZB.Framework
{
    /// <summary>
    /// model验证
    /// </summary>
    public class PropertyValid
    {
        public static string GetValidMsg(ModelStateDictionary modelState)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var ms in modelState.Values)
            {
                foreach (var modelErr in ms.Errors)
                {
                    stringBuilder.AppendLine(modelErr.ErrorMessage);
                }
            }
            return stringBuilder.ToString();
        }
    }   

    /*
     using System.ComponentModel.DataAnnotations;
     [Required]支持正则，Range StringLength 自定义Attribute
     对ViewModel进行验证
     */
}
