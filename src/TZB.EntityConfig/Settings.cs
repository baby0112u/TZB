using System.Data.Entity.ModelConfiguration;

namespace TZB.EntityConfig
{
    public class Settings : EntityTypeConfiguration<Entity.Settings>
    {
        public Settings()
        {
            ToTable("TBL_Settings");
            // Type varchar2(20) not null, --类型
            Property(u => u.Type).HasMaxLength(20).IsRequired();
            // Key VARCHAR2(50) not null, --值，有字符和数字
            Property(u => u.Key).HasMaxLength(50).IsRequired();
            // Text VARCHAR2(200) not null, --显示的文本
            Property(u => u.Text).HasMaxLength(200).IsRequired();
            // Parent VARCHAR2(50) not null, --父级Key
            Property(u => u.Parent).HasMaxLength(50).IsRequired();
            // UserId varchar2(10) not null, --员工工号
            Property(u => u.UserId).HasMaxLength(10).IsRequired();
            // UserName varchar2(100) not null, --姓名
            Property(u => u.UserName).HasMaxLength(100).IsRequired();
            // Remark varchar2(1000) not null, --备注，字典说明
            Property(u => u.Remark).HasMaxLength(1000).IsRequired();
        }
    }
}