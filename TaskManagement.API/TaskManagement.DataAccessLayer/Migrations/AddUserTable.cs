using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataAccessLayer.Migrations
{
    [Migration(202505220004)]
    public class AddUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("EmailAddress").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
