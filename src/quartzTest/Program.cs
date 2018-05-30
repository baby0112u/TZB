using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartzTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            //IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(23,45).Build();//每天 23:45 执行一次
            IMutableTrigger triggerBossReport = CronScheduleBuilder.CronSchedule("1/3 * * * * ? ").Build();

            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }
    }
}
