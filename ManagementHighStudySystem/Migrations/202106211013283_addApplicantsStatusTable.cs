namespace ManagementHighStudySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApplicantsStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Condition = c.String(),
                        userID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.userID_Id)
                .Index(t => t.userID_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "userID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Status", new[] { "userID_Id" });
            DropTable("dbo.Status");
        }
    }
}
