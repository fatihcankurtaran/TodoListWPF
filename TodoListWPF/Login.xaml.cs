using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            if(Username.Text != string.Empty && Password.Password != string.Empty)
            {
                try
                {
                    using (TodoList context = new TodoList())
                    {
                        var user = context.Users.Where(x => x.Username == Username.Text).FirstOrDefault();

                        if (user != null  )
                        {
                            
                            if(user.Password  == Helpers.PasswordHash.Hash(Password.Password))
                            {
                                var mainWindow = new MainWindow(user.Username);
                                mainWindow.Left = Left;
                                mainWindow.Top = Top;
                                mainWindow.Show();
                                this.Close();
                            }

                            
                        }
                        else
                        {
                        
                        }
                    }


                       
                }
                catch(Exception ex)
                {
                   
                }


              
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
