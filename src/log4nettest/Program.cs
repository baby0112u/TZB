using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.Utils;

namespace log4nettest
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.WriteLog(LogType.Debug, "debug...");
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
