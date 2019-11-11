using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TodoListWPF.Model;
namespace TodoListWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        public Register()
        {
            InitializeComponent();
        }


        private void Btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            var login = new Login();
            login.Top = Top;
            login.Left = Left;
            login.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var th = this;
            try
            {
                string warning = string.Empty;
                if (FirstName.Text == string.Empty || Surname.Text == string.Empty || Username.Text == string.Empty || this.Password.Password == string.Empty)
                {
                    Warning.Text = "";
                    Warning.Foreground = Brushes.DarkRed;
                    warning += FirstName.Text == string.Empty ? "Name " : "";
                    warning += Surname.Text == string.Empty ? "Surname " : "";
                    warning += Username.Text == string.Empty ? "Username " : "";
                    warning += Password.Password == string.Empty ? "Password " : "";
                    warning += "is Empty!";
                    Warning.Text = warning;
                    warning = "";
                }
                else
                {
                    var result = RegisterUser(FirstName.Text, Surname.Text, Username.Text, Password.Password);
                    if (result == "OK")
                    {
                        FirstName.Text = string.Empty;
                        Surname.Text = string.Empty;
                        Username.Text = string.Empty;
                        Password.Password = string.Empty;
                        var login = new Login();
                        login.Top = Top;
                        login.Left = Left;
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        Warning.Foreground = Brushes.Red;
                        Warning.Text = result;


                    }
                }
            }
            catch (Exception ex)
            {
                Warning.Foreground = Brushes.Black;
                Warning.Text = "Error occured!";
            }



        }
        public string RegisterUser(string name, string surname, string username, string password)
        {
            try
            {
                if (ValidatePassword(password))
                {
                    Warning.Text = "";
                    using (TodoList context = new TodoList())
                    {
                        if (context.Users.Where(x => x.Username == username).FirstOrDefault() == null)
                        {
                            var user = new User();
                            user.Name = name;
                            user.Surname = surname;
                            user.Password = Helpers.PasswordHash.Hash(password);
                            user.Username = username;
                            context.Users.Add(user);
                            context.SaveChanges();


                            return "OK";



                        }
                        else
                        {

                            return "Username is already occupied";
                        }
                    }
                }
                else
                {
                    return "Password should be 4 to 8 character & include upper and lower case letter and number";
                }
            }
            catch (Exception ex)
            {
                return "Error occurred";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Password_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Minimize_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public bool ValidatePassword(string password)
        {
            string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            if (!string.IsNullOrEmpty(password))
            {
                if (!Regex.IsMatch(password, patternPassword))
                {
                    return false;
                }
                else
                {
                    //Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.
                    return true;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
