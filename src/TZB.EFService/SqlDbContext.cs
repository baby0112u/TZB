﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TZB.Entity;
using TZB.Utils;

namespace TZB.EFService
{
    public  class SqlDbContext:DbContext
    {
        public DbSet<UserPwd> UserPwds { get; set;}
        public DbSet<UserInfo> UserInfos { get; set; }
        static SqlDbContext()
        {
            //Database.SetInitializer<SqlDbContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SqlDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SqlDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SqlDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlDbContext, TZB.EFService.Migrations.Configuration>());
        }
        public SqlDbContext():base("name=SqlConn")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SqlDbContext>());
            this.Database.Log = sql =>
            {
                string msg = sql.ToString();
                string hr = "/**********************************************************************************/";
                if (msg.StartsWith("Opened connection"))
                {
                    LogHelper.WriteLog(LogType.Debug, hr);
                    LogHelper.WriteLog(LogType.Debug, String.Format("EF执行的sql:{0}",sql));
                }
                else if (msg.StartsWith("Closed connection"))
                {
                    LogHelper.WriteLog(LogType.Debug, String.Format("EF执行的sql:{0}", sql));
                    LogHelper.WriteLog(LogType.Debug, hr);
                }
                else
                {
                    LogHelper.WriteLog(LogType.Debug, String.Format("EF执行的sql:{0}", sql));
                }
            };
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("TZB.EntityConfig"));
        }
    }
}