namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tasks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "taskList_Id", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "taskList_Id" });
            RenameColumn(table: "dbo.Tasks", name: "taskList_Id", newName: "TaskListId");
            AlterColumn("dbo.Tasks", "TaskListId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "TaskListId");
            AddForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "TaskListId" });
            AlterColumn("dbo.Tasks", "TaskListId", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "TaskListId", newName: "taskList_Id");
            CreateIndex("dbo.Tasks", "taskList_Id");
            AddForeignKey("dbo.Tasks", "taskList_Id", "dbo.TaskLists", "Id");
        }
    }
}
