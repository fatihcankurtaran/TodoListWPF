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

        }
    }
}
