namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFocus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stretches", "Foci_FocusId", "dbo.Foci");
            DropIndex("dbo.Stretches", new[] { "Foci_FocusId" });
            DropColumn("dbo.Stretches", "Foci_FocusId");
            DropTable("dbo.Foci");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Foci",
                c => new
                    {
                        FocusId = c.Int(nullable: false, identity: true),
                        FocusArea = c.String(),
                        FocusDescription = c.String(),
                    })
                .PrimaryKey(t => t.FocusId);
            
            AddColumn("dbo.Stretches", "Foci_FocusId", c => c.Int());
            CreateIndex("dbo.Stretches", "Foci_FocusId");
            AddForeignKey("dbo.Stretches", "Foci_FocusId", "dbo.Foci", "FocusId");
        }
    }
}
