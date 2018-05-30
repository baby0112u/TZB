using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Utils
{
    /// <summary>
    /// 返回随机码
    /// </summary>
    public class CaptchaHelper
    {
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="len">验证码长度</param>
        /// <returns></returns>
        public static string CreateVerifyCode(int len)
        {
            char[] data = { 'a','c','d','e','f','h','k','m','n','r','s','t','w','x','y','2','3','4','5','7','8'};
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = rand.Next(data.Length);//[0,data.length)
                char ch = data[index];
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}
