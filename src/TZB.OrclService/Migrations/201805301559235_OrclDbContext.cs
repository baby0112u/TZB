namespace OrclService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrclDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "G_USER.TBL_SETTINGS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        Type = c.String(nullable: false, maxLength: 20),
                        Key = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 200),
                        Parent = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(nullable: false, maxLength: 1000),
                        OrderIndex = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRequired = c.Decimal(nullable: false, precision: 1, scale: 0),
                        IsDeleted = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "G_USER.TBL_USERINFO",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        UserId = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(maxLength: 6),
                        IdCard = c.String(maxLength: 32),
                        Birthday = c.DateTime(nullable: false),
                        QQ = c.String(maxLength: 12),
                        Mobile = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        CompId = c.String(nullable: false, maxLength: 10),
                        CompName = c.String(nullable: false, maxLength: 100),
                        OrgId = c.String(nullable: false, maxLength: 10),
                        OrgName = c.String(nullable: false, maxLength: 100),
                        JobId = c.String(nullable: false, maxLength: 10),
                        JobName = c.String(nullable: false, maxLength: 100),
                        RoleId = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(nullable: false, maxLength: 100),
                        UserLevel = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Status = c.String(nullable: false, maxLength: 10),
                        RegisterDate = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "G_USER.TBL_USERPWD",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        UserId = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(nullable: false, maxLength: 100),
                        LoginErrTimes = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LastLoginErrtime = c.DateTime(nullable: false),
                        IsDeleted = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("G_USER.TBL_USERPWD");
            DropTable("G_USER.TBL_USERINFO");
            DropTable("G_USER.TBL_SETTINGS");
        }
    }
}
