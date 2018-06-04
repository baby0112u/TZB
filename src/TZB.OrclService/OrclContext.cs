using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using TZB.Entity;
using TZB.Utils;

namespace TZB.OrclService
{
    public class OrclDbContext : DbContext
    {
        public DbSet<UserPwd> UserPwds { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Settings> Settings { get; set; }

        static OrclDbContext()
        {
            //Database.SetInitializer<SqlDbContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SqlDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SqlDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrclDbContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrclDbContext,TZB.OrclService.>());
        }

        public OrclDbContext() : base("name=OrclConn")
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
            modelBuilder.HasDefaultSchema("G_USER");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("TZB.EntityConfig"));
        }
    }
}