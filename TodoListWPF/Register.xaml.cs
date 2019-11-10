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

            var login  = new Login();
            login.Top = Top;
            login.Left = Left;
            login.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var th = this;
            try {
                string warning = string.Empty; 
                if (FirstName.Text == string.Empty || Surname.Text == string.Empty || Username.Text == string.Empty || this.Password.Password == string.Empty)
                {
                    Warning.Text = ""; 
                    Warning.Foreground = Brushes.DarkRed;
                    warning += FirstName.Text == string.Empty ? "Name " : "";
                    warning += Surname.Text == string.Empty ? "Surname " : "";
                    warning += Username.Text == string.Empty ? "Username " : "";
                    warning += Password.Password == string.Empty ? "Password " : "";
                    warning+= "is Empty!";
                    Warning.Text = warning;
                    warning = "";
                }
                else 
                {
                    Warning.Text = "";
                    using (TodoList context = new TodoList())
                    {
                       if(context.Users.Where(x => x.Username == Username.Text).FirstOrDefault() == null )
                        { 
                        var user = new User();
                        user.Name = FirstName.Text;
                        user.Surname = Surname.Text;
                        user.Password = Password.Password;
                        user.Username = Username.Text;
                        context.Users.Add(user);
                        context.SaveChanges();
                            FirstName.Text = string.Empty;
                            Surname.Text = string.Empty;
                            Username.Text = string.Empty;
                            Password.Password= string.Empty;
                            Warning.Foreground = Brushes.Green;
                            Warning.Text = "Registered Successfully";
                           
                            

                        }
                       else
                        {
                            Warning.Foreground = Brushes.DarkRed;
                            Warning.Text = "Username is already occupied"; 
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Warning.Foreground = Brushes.Black;
                Warning.Text = "Error occured!"; 
            }
            
            

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
