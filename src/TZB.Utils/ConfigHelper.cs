using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Utils
{
    /// <summary>
    /// 配置文件参数帮助类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 返回AppSetting配置节值
        /// </summary>
        /// <param name="appSettingName">AppSetting名称</param>
        /// <returns>根据节点的key值获取节点的值</returns>
        public static string GetAppSettingValue(string appSettingName)
        {
            return ConfigurationManager.AppSettings[appSettingName];
        }

        /// <summary>
        /// 返回AppSetting配置节值
        /// </summary>
        /// <param name="appSettingName">配置节的Key值</param>
        /// <param name="defaultValue">配置节的默认值</param>
        /// <returns>根据节点的key值获取节点的值，为空则返回传入的默认值</returns>
        public static string GetAppSettingValue(string appSettingName, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[appSettingName];
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 返回数据库配置节点列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetConnStrings()
        {
            List<string> list = new List<string>();
            foreach (ConnectionStringSettings set in ConfigurationManager.ConnectionStrings)
            {
                if (set.Name != "LocalSqlServer")
                {
                    list.Add(set.Name);
                }
            }
            return list.ToArray();
        }
    }
}
