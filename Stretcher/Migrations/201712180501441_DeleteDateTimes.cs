namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateTimes : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Stretches", "Goal_GoalId", "dbo.Goals", "GoalId");


        }

        public override void Down()
        {
        }
    }
}
