using System.Data.Entity.ModelConfiguration;

namespace TZB.EntityConfig
{
    public class UserInfo : EntityTypeConfiguration<Entity.UserInfo>
    {
        public UserInfo()
        {
            ToTable("Tbl_UserInfo");
            // UserId varchar2(10) not null, --工号
            Property(u => u.UserId).HasMaxLength(10).IsRequired();
            // UserName varchar2(100) not null, --姓名
            Property(u => u.UserName).HasMaxLength(100).IsRequired();
            //  Gender varchar2(6), --性别
            Property(u => u.Gender).HasMaxLength(6);
            // IdCard varchar2(32), --身份证
            Property(u => u.IdCard).HasMaxLength(32);
            // QQ varchar2(12), --QQ号
            Property(u => u.QQ).HasMaxLength(12);
            //  Mobile varchar2(15), --手机号
            Property(u => u.Mobile).HasMaxLength(15);
            // Email varchar2(100), --邮箱
            Property(u => u.Email).HasMaxLength(100);
            // CompId varchar2(10) not null, --公司代码
            Property(u => u.CompId).HasMaxLength(10).IsRequired();
            // CompName varchar2(100) not null, --公司名称
            Property(u => u.CompName).HasMaxLength(100).IsRequired();
            // OrgId varchar2(10) not null, --部门代码
            Property(u => u.OrgId).HasMaxLength(10).IsRequired();
            // OrgName varchar2(100) not null, --部门名称
            Property(u => u.OrgName).HasMaxLength(100).IsRequired();
            // JobId varchar2(10) not null, --岗位代码
            Property(u => u.JobId).HasMaxLength(10).IsRequired();
            // JobName varchar2(100) not null, --岗位名称
            Property(u => u.JobName).HasMaxLength(100).IsRequired();
            // RoleId varchar2(10) not null, --岗位代码
            Property(u => u.RoleId).HasMaxLength(10).IsRequired();
            // RoleName varchar2(100) not null, --岗位名称
            Property(u => u.RoleName).HasMaxLength(100).IsRequired();
            // UserLevel integer not null, --用户级别
            Property(u => u.UserLevel).IsRequired();
            // Status varchar2(10) not null, --在职状态
            Property(u => u.Status).HasMaxLength(10).IsRequired();
            // RegisterDate date not null, --入职日期
            Property(u => u.RegisterDate).IsRequired();
            // UpdateTime date not null, --状态更新日期
            Property(u => u.UpdateTime).IsRequired();
        }
    }
}