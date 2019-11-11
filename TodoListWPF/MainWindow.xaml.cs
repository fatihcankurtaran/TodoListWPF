using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TodoListWPF.DTO;
using TodoListWPF.Model;
namespace TodoListWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
        }
        private static int? selectedTaskList { get; set; }
        public static string uname { get; set; }
        public static int userId { get; set; }
        public MainWindow(string username)
        {
            InitializeComponent();
            uname = username;
            try
            {
                using (TodoList context = new TodoList())
                {
                    var user = context.Users.Where(x => x.Username == username && x.IsDeleted == false).FirstOrDefault();
                    if (user != null)
                    {
                        userId = user.Id;
                        var tasks = context.TaskLists.Where(x => x.CreatedUserId == user.Id && x.IsDeleted == false).ToList();
                        MainTaskList.ItemsSource = tasks;

                    }

                }

            }
            catch (Exception ex)
            {

            }



        }

        private void Btn_kapat_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (TaskListInput.Text != string.Empty)
                {
                    using (TodoList context = new TodoList())
                    {
                        var user = context.Users.Where(x => x.Username == uname).FirstOrDefault();
                        if (user != null)
                        {
                            var tasklist = new TaskList();
                            tasklist.Name = TaskListInput.Text;
                            tasklist.CreatedUserId = user.Id;
                            tasklist.IsDeleted = false;
                            context.TaskLists.Add(tasklist);
                            context.SaveChanges();
                            MainTaskList.ItemsSource = context.TaskLists.Where(x => x.IsDeleted == false && x.CreatedUserId == user.Id).ToList();
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }

        }




        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TodoList context = new TodoList())
                {
                    var button = sender as Button;
                    var myValue = int.Parse(button.Tag.ToString());
                    if (myValue != null)
                    {
                        var tasklist = context.TaskLists.Where(x => x.Id == myValue).FirstOrDefault();
                        if (tasklist != null)
                        {
                            tasklist.IsDeleted = true;
                            context.SaveChanges();
                            MainTaskList.ItemsSource = context.TaskLists.Where(x => x.IsDeleted == false && x.CreatedUserId == userId).ToList();
                            TaskGrid.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }




        private void IsCompleted_Checked(object sender, RoutedEventArgs e)
        {
            updateTasks();
        }

        private void IsCompleted_Unchecked(object sender, RoutedEventArgs e)
        {
            updateTasks();
        }

        private void IsExpired_Checked(object sender, RoutedEventArgs e)
        {
            updateTasks();

        }

        private void IsExpired_Unchecked(object sender, RoutedEventArgs e)
        {
            updateTasks();
        }



        private void OrderComboBox_DropDownClosed(object sender, EventArgs e)
        {
            updateTasks();
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            updateTasks();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ItemName.Text == string.Empty)
                {
                    ItemName.BorderBrush = Brushes.Red;
                }
                else
                {
                    ItemName.BorderBrush = Brushes.Transparent;
                }
                if (Deadline.Text == string.Empty)
                {
                    Deadline.BorderBrush = Brushes.Red;
                }
                else

                {
                    Deadline.BorderBrush = Brushes.Transparent;
                }
                if (Description.Text == string.Empty)
                {
                    Description.BorderBrush = Brushes.Red;
                }
                else
                {
                    Description.BorderBrush = Brushes.Transparent;
                }
                if (ItemName.Text != string.Empty && Deadline.Text != string.Empty && selectedTaskList != null && Description.Text != string.Empty)
                {


                    using (TodoList context = new TodoList())
                    {
                        var task = new Model.Task();
                        task.Deadline = Deadline.SelectedDate.Value.Date;
                        task.Description = Description.Text;
                        task.IsCompleted = false;
                        task.Name = ItemName.Text;
                        task.CreatedUserId = userId;
                        task.TaskListId = (int)selectedTaskList;
                        context.Tasks.Add(task);
                        context.SaveChanges();
                        updateTasks();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }
        public void updateTasks()
        {
            try
            {

                if (selectedTaskList != null)
                {
                    using (TodoList context = new TodoList())
                    {
                        var list = context.TaskLists.Where(x => x.Id == selectedTaskList && x.IsDeleted == false).FirstOrDefault();
                        if (list != null)
                        {

                            var tasks = context.Tasks.Where(x => x.TaskListId == selectedTaskList && x.IsDeleted == false).ToList();
                            if((bool)IsCompleted.IsChecked)
                            {
                                tasks = tasks.Where(x => x.IsCompleted == true).ToList();
                            }
                            if((bool)IsExpired.IsChecked)
                            { tasks = tasks.Where(x => x.Deadline < DateTime.Now).ToList(); }
                            if(Search.Text != string.Empty)
                            { tasks = tasks.Where(x => x.Name.Contains(Search.Text)).ToList(); }
                                
                            IOrderedEnumerable<Task> sonuc; 

                            if(OrderComboBox.Text  == string.Empty)
                            {
                                 sonuc = tasks.OrderBy(x => x.CreatedDate);
                            }
                            else if (OrderComboBox.Text == "Created Date")
                            {
                                 sonuc = tasks.OrderBy(x => x.CreatedDate);
                            }
                            else if (OrderComboBox.Text == "Deadline")
                            {
                                 sonuc = tasks.OrderBy(x => x.Deadline);
                            }
                            else if (OrderComboBox.Text == "Name")
                            {
                                 sonuc = tasks.OrderBy(x => x.Name);
                            }
                            else if (OrderComboBox.Text == "Status")
                            {
                                 sonuc = tasks.OrderByDescending(x => x.IsCompleted);
                            }
                            else
                            {
                                sonuc = tasks.OrderBy(x => x.CreatedDate);
                            }

                            var taskList = new List<TaskDTO>();

                            foreach (var item in sonuc)
                            {
                                var taskDTO = new TaskDTO();
                                taskDTO.Name = item.Name;
                                taskDTO.IsDeleted = item.IsDeleted;
                                taskDTO.IsCompleted = item.IsCompleted;
                                taskDTO.TaskListId = item.TaskListId;
                                taskDTO.CreatedDate = item.CreatedDate.ToString("dd/MM/yyyy");
                                taskDTO.Deadline = item.Deadline.ToString("dd/MM/yyyy");
                                taskDTO.Description = item.Description;
                                taskDTO.Id = item.Id;
                                taskList.Add(taskDTO);
                            }
                            Tasks.ItemsSource = taskList;
                            TaskGrid.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SelectedList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                selectedTaskList = int.Parse(button.Tag.ToString());
                updateTasks();

            }
            catch
            {

            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TodoList context = new TodoList())
                {
                    var button = sender as Button;
                    var myValue = int.Parse(button.Tag.ToString());

                    var task = context.Tasks.Where(x => x.Id == myValue).FirstOrDefault();
                    if (task != null)
                    {
                        task.IsDeleted = true;
                        context.SaveChanges();
                        updateTasks();

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void ItemCompleted_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as CheckBox;
                var myValue = int.Parse(button.Tag.ToString());

                using (TodoList context = new TodoList())
                {
                    var task = context.Tasks.Where(x => x.Id == myValue).FirstOrDefault();
                    if (task != null)
                    {
                        task.IsCompleted = true;
                        context.SaveChanges();
                        updateTasks();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ItemCompleted_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as CheckBox;
                var myValue = int.Parse(button.Tag.ToString());

                using (TodoList context = new TodoList())
                {
                    var task = context.Tasks.Where(x => x.Id == myValue).FirstOrDefault();
                    if (task != null)
                    {
                        task.IsCompleted = false;
                        context.SaveChanges();
                        updateTasks();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }

}
