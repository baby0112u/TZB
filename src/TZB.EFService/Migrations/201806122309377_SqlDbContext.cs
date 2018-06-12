namespace TZB.SqlServerDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SqlDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_PERMISSION",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_ROLE",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_USERPWD",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(nullable: false, maxLength: 100),
                        LoginErrTimes = c.Int(nullable: false),
                        LastLoginErrTime = c.DateTime(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_USERINFO",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
                        UserLevel = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        RegisterDate = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 20),
                        Key = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 200),
                        Parent = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(nullable: false, maxLength: 1000),
                        OrderIndex = c.Int(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_UserPwdRoles",
                c => new
                    {
                        UserPwdId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserPwdId, t.RoleId })
                .ForeignKey("dbo.TBL_USERPWD", t => t.UserPwdId)
                .ForeignKey("dbo.TBL_ROLE", t => t.RoleId)
                .Index(t => t.UserPwdId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tbl_RolePermissions",
                c => new
                    {
                        RoleId = c.Long(nullable: false),
                        PermissionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId })
                .ForeignKey("dbo.TBL_PERMISSION", t => t.RoleId)
                .ForeignKey("dbo.TBL_ROLE", t => t.PermissionId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_RolePermissions", "PermissionId", "dbo.TBL_ROLE");
            DropForeignKey("dbo.Tbl_RolePermissions", "RoleId", "dbo.TBL_PERMISSION");
            DropForeignKey("dbo.Tbl_UserPwdRoles", "RoleId", "dbo.TBL_ROLE");
            DropForeignKey("dbo.Tbl_UserPwdRoles", "UserPwdId", "dbo.TBL_USERPWD");
            DropIndex("dbo.Tbl_RolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.Tbl_RolePermissions", new[] { "RoleId" });
            DropIndex("dbo.Tbl_UserPwdRoles", new[] { "RoleId" });
            DropIndex("dbo.Tbl_UserPwdRoles", new[] { "UserPwdId" });
            DropTable("dbo.Tbl_RolePermissions");
            DropTable("dbo.Tbl_UserPwdRoles");
            DropTable("dbo.TBL_Settings");
            DropTable("dbo.TBL_USERINFO");
            DropTable("dbo.TBL_USERPWD");
            DropTable("dbo.TBL_ROLE");
            DropTable("dbo.TBL_PERMISSION");
        }
    }
}
