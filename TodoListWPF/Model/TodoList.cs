using System;
using System.Data.Entity;
using System.Linq;
using TodoListWPF.Model;
namespace TodoListWPF.Model
{
   

    public class TodoList : DbContext
    {
        // Your context has been configured to use a 'TodoList' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TodoListWPF.TodoList' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TodoList' 
        // connection string in the application configuration file.
        public TodoList()
            : base("name=TodoList")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<TaskList> TaskLists { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }


    }


}