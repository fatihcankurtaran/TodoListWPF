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
            user.Password = "Ø�Ŏ!���d��;޺}Y";
            context.Users.AddOrUpdate(user);
            context.SaveChanges();
            TaskList taskList = new TaskList();
            
            taskList.Name = "Math";
            taskList.CreatedDate = new DateTime(2019, 11, 11);
            taskList.IsDeleted = false;
            taskList.CreatedUserId = user.Id;
            context.TaskLists.AddOrUpdate(taskList);
            context.SaveChanges();
            TaskList taskList2 = new TaskList();
            taskList2.Name = "Computer Organization";
            taskList2.CreatedDate = new DateTime(2019, 11, 11);
            taskList2.IsDeleted = false;
            taskList2.CreatedUserId = user.Id;
            context.TaskLists.AddOrUpdate(taskList2);
            context.SaveChanges();
            Task task = new Task();
            task.Name = "Homework";
            task.IsCompleted = false;
            task.Deadline = new DateTime(2019, 11, 23);
            task.Description = "Unit 1";
            task.CreatedDate = new DateTime(2019, 11, 11);
            task.IsDeleted = false;
            task.CreatedUserId = user.Id;
            task.TaskListId = taskList2.Id;
            context.Tasks.AddOrUpdate(task);
            context.SaveChanges();
            var task2 = new Task();
            task2.Name = "Exam";
            task2.IsCompleted = true;
            task2.Deadline = new DateTime(2019, 11, 30);
            task2.Description = "Questions from derivatives";
            task2.CreatedDate = new DateTime(2019, 11, 11);
            task2.IsDeleted = false;
            task2.CreatedUserId = user.Id;
            task2.TaskListId = taskList.Id;
            context.Tasks.AddOrUpdate(task2);
            context.SaveChanges();




        }
    }
}
