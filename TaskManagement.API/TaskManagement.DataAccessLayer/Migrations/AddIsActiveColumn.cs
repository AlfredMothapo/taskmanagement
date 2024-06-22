using FluentMigrator;

namespace TaskManagement.DataAccessLayer.Migrations
{
    [Migration(202505220006)]
    public class AddIsActiveColumn : Migration
    {
        public override void Up()
        {
            Alter.Table("User")
                 .AddColumn("IsActive")
                 .AsBoolean()
                 .WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Column("IsActive").FromTable("User");
        }
    }
}
