namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lessViewModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stretches", "StretchImage");
            DropColumn("dbo.Stretches", "StretchSequence");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stretches", "StretchSequence", c => c.Int(nullable: false));
            AddColumn("dbo.Stretches", "StretchImage", c => c.String());
        }
    }
}
