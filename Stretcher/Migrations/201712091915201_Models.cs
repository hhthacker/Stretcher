namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foci",
                c => new
                    {
                        FocusId = c.Int(nullable: false, identity: true),
                        FocusArea = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FocusId);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        GoalId = c.Int(nullable: false, identity: true),
                        Intensity = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GoalId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reflections",
                c => new
                    {
                        ReflectionId = c.Int(nullable: false, identity: true),
                        Goal = c.String(),
                        ReflectionCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReflectionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Stretches",
                c => new
                    {
                        StretchId = c.Int(nullable: false, identity: true),
                        StretchName = c.String(),
                        StretchDescription = c.String(),
                        StretchImage = c.String(),
                        StretchSequence = c.Int(nullable: false),
                        StretchDifficulty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StretchId);
            
            CreateTable(
                "dbo.StretchGoals",
                c => new
                    {
                        StretchGoalId = c.Int(nullable: false, identity: true),
                        IsComplete = c.Boolean(nullable: false),
                        GoalSequence_GoalId = c.Int(),
                        ReflectionNote_ReflectionId = c.Int(),
                        StretchStep_StretchId = c.Int(),
                    })
                .PrimaryKey(t => t.StretchGoalId)
                .ForeignKey("dbo.Goals", t => t.GoalSequence_GoalId)
                .ForeignKey("dbo.Reflections", t => t.ReflectionNote_ReflectionId)
                .ForeignKey("dbo.Stretches", t => t.StretchStep_StretchId)
                .Index(t => t.GoalSequence_GoalId)
                .Index(t => t.ReflectionNote_ReflectionId)
                .Index(t => t.StretchStep_StretchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StretchGoals", "StretchStep_StretchId", "dbo.Stretches");
            DropForeignKey("dbo.StretchGoals", "ReflectionNote_ReflectionId", "dbo.Reflections");
            DropForeignKey("dbo.StretchGoals", "GoalSequence_GoalId", "dbo.Goals");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Goals", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.StretchGoals", new[] { "StretchStep_StretchId" });
            DropIndex("dbo.StretchGoals", new[] { "ReflectionNote_ReflectionId" });
            DropIndex("dbo.StretchGoals", new[] { "GoalSequence_GoalId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Goals", new[] { "User_Id" });
            DropTable("dbo.StretchGoals");
            DropTable("dbo.Stretches");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reflections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Goals");
            DropTable("dbo.Foci");
        }
    }
}
