using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.MySqlDB;
using TZB.Utils;

namespace quartzTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (TZB.MySqlDB.MySqlContext ctx = new MySqlContext())
            {
                TZB.Entity.UserPwd pwd = new TZB.Entity.UserPwd();
                pwd.LastLoginErrTime = DateTime.Now;
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
            IScheduler sched = (IScheduler)new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            //IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(23,45).Build();//每天 23:45 执行一次
            IMutableTrigger triggerBossReport = CronScheduleBuilder.CronSchedule("1/3 * * * * ? ").Build();

            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }
    }
}
