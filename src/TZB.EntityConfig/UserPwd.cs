﻿using System.Data.Entity.ModelConfiguration;

namespace TZB.EntityConfig
{
    public class UserPwd : EntityTypeConfiguration<Entity.UserPwd>
    {
        public UserPwd()
        {
            ToTable("Tbl_UserPwd");
            //UserId工号 不能跟系统编号混淆了
            HasMany(u => u.Roles).WithMany(r => r.UserPwds).Map(m => m.ToTable("Tbl_UserPwdRoles")
                .MapLeftKey("UserPwdId").MapRightKey("RoleId"));
            // UserId varchar2(10) not null, --工号
            Property(u => u.UserId).HasMaxLength(10).IsRequired();
            // UserName VARCHAR2(50) not null, --用户账号
            Property(u => u.UserName).HasMaxLength(50).IsRequired();
            // PasswordHash VARCHAR2(100) not null, --密码哈希值
            Property(u => u.PasswordHash).HasMaxLength(100).IsRequired();
            // PasswordSalt VARCHAR2(100) not null, --密码盐值
            Property(u => u.PasswordSalt).HasMaxLength(100).IsRequired();
            // LoginErrTimes INTEGER default 0 not null,--登陆错误次数
            Property(u => u.LoginErrTimes).IsRequired();
            // LastLoginErrtime DATE default SYSDATE not null,--最后一次错误登陆时间
            Property(u => u.LastLoginErrTime).IsRequired();
        }
    }
}