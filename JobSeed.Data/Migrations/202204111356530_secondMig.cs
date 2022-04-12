namespace JobSeed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false),
                        DocumentAdded = c.Boolean(nullable: false),
                        DocSubmitted = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserId = c.String(),
                        Job_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Job", t => t.Job_JobId)
                .Index(t => t.Job_JobId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        JobId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Document", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Position = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserId = c.String(),
                        DocumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_UserId = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "JobId", "dbo.Job");
            DropForeignKey("dbo.Document", "Job_JobId", "dbo.Job");
            DropForeignKey("dbo.ApplicationUser", "DocumentId", "dbo.Document");
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.ApplicationUser", new[] { "DocumentId" });
            DropIndex("dbo.ApplicationUser", new[] { "JobId" });
            DropIndex("dbo.Document", new[] { "Job_JobId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.Job");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Document");
        }
    }
}
