namespace TZB.EFService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SqlDbContext : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_UserPwdRoles", "RoleId", "dbo.TBL_ROLE");
            DropForeignKey("dbo.Tbl_UserPwdRoles", "UserPwdId", "dbo.TBL_USERPWD");
            DropForeignKey("dbo.Tbl_RolePermissions", "PermissionId", "dbo.TBL_ROLE");
            DropForeignKey("dbo.Tbl_RolePermissions", "RoleId", "dbo.TBL_PERMISSION");
            DropIndex("dbo.Tbl_UserPwdRoles", new[] { "RoleId" });
            DropIndex("dbo.Tbl_UserPwdRoles", new[] { "UserPwdId" });
            DropIndex("dbo.Tbl_RolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.Tbl_RolePermissions", new[] { "RoleId" });
            DropTable("dbo.Tbl_UserPwdRoles");
            DropTable("dbo.Tbl_RolePermissions");
            DropTable("dbo.TBL_PERMISSION");
            DropTable("dbo.TBL_ROLE");
        }
    }
}
