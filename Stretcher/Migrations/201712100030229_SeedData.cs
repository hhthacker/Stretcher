namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foci", "FocusDescription", c => c.String());
            AddColumn("dbo.Goals", "GoalName", c => c.String());
            AddColumn("dbo.Goals", "GoalDescription", c => c.String());
            AddColumn("dbo.Reflections", "ReflectionTitle", c => c.String());
            AddColumn("dbo.Reflections", "ReflectionNotes", c => c.String());
            AlterColumn("dbo.Reflections", "Goal", c => c.Int(nullable: false));
            DropColumn("dbo.Foci", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foci", "Description", c => c.String());
            AlterColumn("dbo.Reflections", "Goal", c => c.String());
            DropColumn("dbo.Reflections", "ReflectionNotes");
            DropColumn("dbo.Reflections", "ReflectionTitle");
            DropColumn("dbo.Goals", "GoalDescription");
            DropColumn("dbo.Goals", "GoalName");
            DropColumn("dbo.Foci", "FocusDescription");
        }
    }
}
