namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskListandTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedId = c.DateTime(),
                        ModifiedId = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deadline = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedId = c.DateTime(),
                        ModifiedId = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Users", "CreatedId", c => c.DateTime());
            AddColumn("dbo.Users", "ModifiedId", c => c.DateTime());
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "ModifiedId");
            DropColumn("dbo.Users", "CreatedId");
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreatedDate");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskLists");
        }
    }
}
