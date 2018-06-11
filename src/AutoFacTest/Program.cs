using Autofac;
using TZB.OrclService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.EFService;
using TZB.Utils;
using TZB.MySqlDB;

namespace AutoFacTest
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

            #region OrclDbContext
            /*
            using (OrclDbContext ctx = new OrclDbContext())
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
            */
            #endregion

            #region AutoFac
            /*
            var builder = new ContainerBuilder();
            builder.Register(n => new ClassC { D = n.Resolve<ClassD>(), Name = "sss" });
            builder.RegisterType<ClassD>();
            var container = builder.Build();
            var c = container.Resolve<ClassC>();
            //var c = new ClassC();
            c.Show();
            c.D.Show();
            */
            #endregion

            Console.ReadKey();
        }
    }
    public class ClassA
    {
        private readonly ClassB b;

        public ClassA(ClassB b)
        {
            this.b = b;
        }

        public void Show()
        {
            Console.WriteLine("I am ClassA's instance !");
        }
    }

    public class ClassB
    {
        public ClassA A { get; set; }

        public void Show()
        {
            Console.WriteLine("I am ClassB's instance !");
        }

    }

    public class ClassC
    {
        public string Name { get; set; }

        public ClassD D { get; set; }

        public void Show()
        {
            Console.WriteLine("I am ClassC's instance !" + Name);
        }
    }

    public class ClassD
    {
        public void Show()
        {
            Console.WriteLine("I am ClassD's instance !");
        }
    }
}
