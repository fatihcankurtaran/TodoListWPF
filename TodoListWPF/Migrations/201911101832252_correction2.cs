namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskLists", "CreatedUserId", c => c.Int());
            AddColumn("dbo.TaskLists", "ModifiedUserId", c => c.Int());
            AddColumn("dbo.Tasks", "CreatedUserId", c => c.Int());
            AddColumn("dbo.Tasks", "ModifiedUserId", c => c.Int());
            AddColumn("dbo.Users", "CreatedUserId", c => c.Int());
            AddColumn("dbo.Users", "ModifiedUserId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ModifiedUserId");
            DropColumn("dbo.Users", "CreatedUserId");
            DropColumn("dbo.Tasks", "ModifiedUserId");
            DropColumn("dbo.Tasks", "CreatedUserId");
            DropColumn("dbo.TaskLists", "ModifiedUserId");
            DropColumn("dbo.TaskLists", "CreatedUserId");
        }
    }
}
