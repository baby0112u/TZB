using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Utils
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5Helper
    {
        #region CalcMD5
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string CalcMD5(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return CalcMD5(bytes);
        }

        /// <summary>
        /// 二进制数据加密
        /// </summary>
        /// <param name="bytes">二进制数组</param>
        /// <returns></returns>
        public static string CalcMD5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }

        /// <summary>
        /// 流加密
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns></returns>
        public static string CalcMD5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }

        #endregion
    }
}
