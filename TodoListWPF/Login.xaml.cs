using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TodoListWPF.Model;
namespace TodoListWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {

            InitializeComponent();
        }

        private void Btn_kapat_Click(object sender, RoutedEventArgs e)
        {

            System.Environment.Exit(0);
        }

        private void TextBox_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            var register = new Register();

            register.Left = Left;
            register.Top = Top;
            register.Show();
            this.Close();


        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text != string.Empty && Password.Password != string.Empty)
            {
                try
                {
                    if (LoginUser(Username.Text, Password.Password))
                    {
                        var mainWindow = new MainWindow(Username.Text);
                        mainWindow.Left = Left;
                        mainWindow.Top = Top;
                        mainWindow.Show();
                        this.Close();
                    }




                }
                catch (Exception ex)
                {

                }



            }


        }
        public  bool LoginUser(string username, string password)
        {
            try
            {
                using (TodoList context = new TodoList())
                {
                    var user = context.Users.Where(x => x.Username == username).FirstOrDefault();

                    if (user != null)
                    {
                        if (user.Password == Helpers.PasswordHash.Hash(password))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }
}
