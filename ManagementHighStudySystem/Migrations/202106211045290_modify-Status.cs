namespace ManagementHighStudySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Status", "userID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Status", new[] { "userID_Id" });
            AddColumn("dbo.Status", "userID", c => c.String());
            DropColumn("dbo.Status", "userID_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "userID_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Status", "userID");
            CreateIndex("dbo.Status", "userID_Id");
            AddForeignKey("dbo.Status", "userID_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
