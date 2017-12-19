namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualStuffs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals", "Stretches_StretchId", c => c.Int());
            AddColumn("dbo.Reflections", "Goals_GoalId", c => c.Int());
            AddColumn("dbo.Stretches", "Foci_FocusId", c => c.Int());
            CreateIndex("dbo.Goals", "Stretches_StretchId");
            CreateIndex("dbo.Stretches", "Foci_FocusId");
            CreateIndex("dbo.Reflections", "Goals_GoalId");
            AddForeignKey("dbo.Stretches", "Foci_FocusId", "dbo.Foci", "FocusId");
            AddForeignKey("dbo.Goals", "Stretches_StretchId", "dbo.Stretches", "StretchId");
            AddForeignKey("dbo.Reflections", "Goals_GoalId", "dbo.Goals", "GoalId");
            DropColumn("dbo.Reflections", "Goal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reflections", "Goal", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reflections", "Goals_GoalId", "dbo.Goals");
            DropForeignKey("dbo.Goals", "Stretches_StretchId", "dbo.Stretches");
            DropForeignKey("dbo.Stretches", "Foci_FocusId", "dbo.Foci");
            DropIndex("dbo.Reflections", new[] { "Goals_GoalId" });
            DropIndex("dbo.Stretches", new[] { "Foci_FocusId" });
            DropIndex("dbo.Goals", new[] { "Stretches_StretchId" });
            DropColumn("dbo.Stretches", "Foci_FocusId");
            DropColumn("dbo.Reflections", "Goals_GoalId");
            DropColumn("dbo.Goals", "Stretches_StretchId");
        }
    }
}
