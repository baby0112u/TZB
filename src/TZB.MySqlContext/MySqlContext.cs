using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TZB.Entity;
using TZB.Utils;

namespace TZB.MySqlService
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext:DbContext
    {

        public DbSet<UserPwd> UserPwds { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Settings> Settings { get; set; }

        static MySqlContext()
        {
            //Database.SetInitializer<SqlDbContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MySqlContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MySqlContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MySqlContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySqlContext, TZB.MySqlService.Migrations.Configuration>());
        }
        public MySqlContext() : base("name=MySqlConn")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SqlDbContext>());
            this.Database.Log = sql =>
            {
                LogHelper.WriteLog(LogType.Debug, String.Format("EF执行的SQL：{0}", sql));
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("G_USER");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("TZB.EntityConfig"));
        }
    }
}
