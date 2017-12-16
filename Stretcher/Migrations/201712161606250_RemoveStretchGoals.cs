namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStretchGoals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StretchGoals", "GoalSequence_GoalId", "dbo.Goals");
            DropForeignKey("dbo.StretchGoals", "ReflectionNote_ReflectionId", "dbo.Reflections");
            DropForeignKey("dbo.StretchGoals", "StretchStep_StretchId", "dbo.Stretches");
            DropIndex("dbo.Goals", new[] { "Stretches_StretchId" });
            DropIndex("dbo.StretchGoals", new[] { "GoalSequence_GoalId" });
            DropIndex("dbo.StretchGoals", new[] { "ReflectionNote_ReflectionId" });
            DropIndex("dbo.StretchGoals", new[] { "StretchStep_StretchId" });
            AddColumn(table: "dbo.Stretches", name: "Goal_GoalId", columnAction:c => c.Int());
            CreateIndex("dbo.Stretches", "Goal_GoalId");
            DropColumn("dbo.Goals", "Stretches_StretchId");
            DropTable("dbo.StretchGoals");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.StretchGoalId);
            
            AddColumn("dbo.Goals", "Stretches_StretchId", c => c.Int());
            DropIndex("dbo.Stretches", new[] { "Goal_GoalId" });
            RenameColumn(table: "dbo.Stretches", name: "Goal_GoalId", newName: "Stretches_StretchId");
            CreateIndex("dbo.StretchGoals", "StretchStep_StretchId");
            CreateIndex("dbo.StretchGoals", "ReflectionNote_ReflectionId");
            CreateIndex("dbo.StretchGoals", "GoalSequence_GoalId");
            CreateIndex("dbo.Goals", "Stretches_StretchId");
            AddForeignKey("dbo.StretchGoals", "StretchStep_StretchId", "dbo.Stretches", "StretchId");
            AddForeignKey("dbo.StretchGoals", "ReflectionNote_ReflectionId", "dbo.Reflections", "ReflectionId");
            AddForeignKey("dbo.StretchGoals", "GoalSequence_GoalId", "dbo.Goals", "GoalId");
        }
    }
}
