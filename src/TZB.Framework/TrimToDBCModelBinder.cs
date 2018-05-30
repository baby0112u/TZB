using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TZB.Utils;

namespace TZB.Framework
{
    //一定要使用using System.Web.Mvc下的DefaultModelBinder
    /// <summary>
    /// 
    /// </summary>
    public class TrimToDBCModelBinder : DefaultModelBinder
    {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            if (value is string)
            {
                string strValue = (string)value;
                string value2 = ToDBCHelper.ToDBC(strValue).Trim();
                return value2;
            }
            else
            {
                return value;
            }
        }
    }
}
