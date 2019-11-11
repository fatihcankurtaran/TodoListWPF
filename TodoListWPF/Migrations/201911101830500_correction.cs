namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TaskLists", "CreatedId");
            DropColumn("dbo.TaskLists", "ModifiedId");
            DropColumn("dbo.Tasks", "CreatedId");
            DropColumn("dbo.Tasks", "ModifiedId");
            DropColumn("dbo.Users", "CreatedId");
            DropColumn("dbo.Users", "ModifiedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ModifiedId", c => c.DateTime());
            AddColumn("dbo.Users", "CreatedId", c => c.DateTime());
            AddColumn("dbo.Tasks", "ModifiedId", c => c.DateTime());
            AddColumn("dbo.Tasks", "CreatedId", c => c.DateTime());
            AddColumn("dbo.TaskLists", "ModifiedId", c => c.DateTime());
            AddColumn("dbo.TaskLists", "CreatedId", c => c.DateTime());
        }
    }
}
