namespace ManagementHighStudySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class insertRoles : DbMigration
    {
        public override void Up()
        {
            Sql("insert into AspNetRoles (id,Name) values(1,'admin')");
            Sql("insert into AspNetRoles (id,Name) values(2,'user')");
            Sql("insert into AspNetRoles (id,Name) values(3,'student')");
        }

        public override void Down()
        {
        }
    }
}
