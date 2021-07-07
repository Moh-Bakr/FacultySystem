namespace ManagementHighStudySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pathTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pathTitle = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Paths");
        }
    }
}
