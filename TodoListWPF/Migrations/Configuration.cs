namespace TodoListWPF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoListWPF.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoListWPF.Model.TodoList>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoListWPF.Model.TodoList context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            User user = new User();
            user.Name = "Fatih";
            user.Surname = "Cankurtaran";
            user.Username = "test";
            user.Password = "fBV�jJ[Ю�%��ڮw";
            context.Users.AddOrUpdate(user); 


        }
    }
}
