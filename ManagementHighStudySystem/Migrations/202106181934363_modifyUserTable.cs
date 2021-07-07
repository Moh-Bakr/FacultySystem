namespace ManagementHighStudySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "path", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "path", c => c.String());
        }
    }
}
