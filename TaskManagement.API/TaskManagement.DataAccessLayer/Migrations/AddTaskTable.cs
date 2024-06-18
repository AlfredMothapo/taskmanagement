using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataAccessLayer.Migrations
{
    [Migration(202505220003)]
    public class AddTaskTable : Migration
    {
        public override void Up()
        {
            Create.Table("Task")
               .WithColumn("Id").AsGuid().PrimaryKey()
               .WithColumn("Title").AsString().NotNullable()
               .WithColumn("Description").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Task");
        }
    }
}
