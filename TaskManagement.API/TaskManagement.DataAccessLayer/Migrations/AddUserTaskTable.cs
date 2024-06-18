using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataAccessLayer.Migrations
{
    [Migration(202505220005)]
    public class AddUserTaskTable : Migration
    {
        public override void Down()
        {
            Delete.Table("UserTask");
        }

        public override void Up()
        {
            Create.Table("UserTask")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("TaskId").AsGuid().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable();

            Create.ForeignKey("FK_UserTask_User")
                .FromTable("UserTask").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("Id");

            Create.ForeignKey("FK_UserTask_Task")
                .FromTable("UserTask").ForeignColumn("TaskId")
                .ToTable("Task").PrimaryColumn("Id");

        }
    }
}
