using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (TZB.MySqlDB.MySqlContext ctx = new MySqlContext())
            {
                TZB.Entity.UserPwd pwd = new TZB.Entity.UserPwd();
                pwd.LastLoginErrtime = DateTime.Now;
                pwd.LoginErrTimes = 0;
                pwd.PasswordSalt = "18286865338";
                pwd.UserId = "011239";
                pwd.UserName = "baby0112";
                pwd.PasswordHash = MD5Helper.CalcMD5(pwd.PasswordSalt + pwd.UserId);
                ctx.UserPwds.Add(pwd);
                ctx.SaveChanges();
                Console.WriteLine(pwd.Id);
            }

        }
        static void Main1(string[] args)
        {
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //dict.Add("name", "tzb");
            //dict.Add("age", "18");
            //foreach (var item in dict)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //}
            string strList = "fdsakjlfjksdljiwofajkld";
            string newStyle = " aaa dsakjl aaa jksdljiwo aaa ajkld";
            string splitStr = " aaa";
            string err;
            string newstyleStr = GetNewStyle(strList, newStyle, splitStr, out err);
            if(!string.IsNullOrEmpty(err))
            {
                Console.WriteLine(err);
            }
            Console.WriteLine(newstyleStr);
            Console.ReadKey();
        }
        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string ReturnValue = "";
            //如果输入空值，返回空，并给出错误提示
            if (StrList == null)
            {
                ReturnValue = "";
                Error = "请输入需要划分格式的字符串";
            }
            else
            {
                //检查传入的字符串长度和样式是否匹配,如果不匹配，则说明使用错误。给出错误信息并返回空值
                int strListLength = StrList.Length;
                int NewStyleLength = GetCleanStyle(NewStyle, SplitString).Length;
                if (strListLength != NewStyleLength)
                {
                    ReturnValue = "";
                    Error = "样式格式的长度与输入的字符长度不符，请重新输入";
                }
                else
                {
                    //检查新样式中分隔符的位置
                    string Lengstr = "";
                    for (int i = 0; i < NewStyle.Length; i++)
                    {
                        if (SplitString.Length+i <= NewStyle.Length && NewStyle.Substring(i, SplitString.Length) == SplitString)
                        {
                            Lengstr = Lengstr + "," + i;
                        }
                    }
                    if (Lengstr != "")
                    {
                        Lengstr = Lengstr.Substring(1);
                    }
                    //将分隔符放在新样式中的位置
                    string[] str = Lengstr.Split(',');
                    foreach (string bb in str)
                    {
                        StrList = StrList.Insert(int.Parse(bb), SplitString);
                    }
                    //给出最后的结果
                    ReturnValue = StrList;
                    //因为是正常的输出，没有错误
                    Error = "";
                }
            }
            return ReturnValue;
        }
        /// <summary>
        ///  将字符串样式转换为纯字符串
        /// </summary>
        /// <param name="StrList"></param>
        /// <param name="SplitString"></param>
        /// <returns></returns>
        public static string GetCleanStyle(string StrList, string SplitString)
        {
            string RetrunValue = "";
            //如果为空，返回空值
            if (StrList == null)
            {
                RetrunValue = "";
            }
            else
            {
                //返回去掉分隔符
                string NewString = "";
                NewString = StrList.Replace(SplitString, "");
                RetrunValue = NewString;
            }
            return RetrunValue;
        }
    }
}
