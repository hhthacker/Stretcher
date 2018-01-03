namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stretchSelect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stretches", "StretchSelect", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stretches", "StretchSelect");
        }
    }
}
