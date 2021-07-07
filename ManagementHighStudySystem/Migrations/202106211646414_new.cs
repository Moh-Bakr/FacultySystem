namespace ManagementHighStudySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AdditionalEnrolls");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdditionalEnrolls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.String(),
                        path = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
