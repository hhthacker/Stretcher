namespace Stretcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Goals", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Goals", new[] { "User_Id" });
            DropColumn("dbo.Goals", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goals", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Goals", "User_Id");
            AddForeignKey("dbo.Goals", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
