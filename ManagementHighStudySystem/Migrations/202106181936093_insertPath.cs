namespace ManagementHighStudySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class insertPath : DbMigration
    {
        public override void Up()
        {
            Sql("insert into paths (pathTitle) values('دبلومة')");
            Sql("insert into paths (pathTitle) values('ماجستير')");
            Sql("insert into paths (pathTitle) values('دكتوراه')");
        }

        public override void Down()
        {
        }
    }
}
