namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "taskList_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "taskList_Id");
            AddForeignKey("dbo.Tasks", "taskList_Id", "dbo.TaskLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "taskList_Id", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "taskList_Id" });
            DropColumn("dbo.Tasks", "taskList_Id");
        }
    }
}
