using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoListWPF;
using System.Windows;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1:Window
    {
        [TestMethod]
        public void LoginTest()
        {
            Login login = new Login();
            Assert.IsTrue(login.LoginUser("test", "Test3*")); 
        }
        [TestMethod]
        public void RegisterTest()
        {
            Register register = new Register();
            Random rnd = new Random();
            var username= rnd.Next(1000, 10000).ToString();
            var result = register.RegisterUser("Fatih", "Cankurtaran", username, "1Test*");
            using (TodoListWPF.Model.TodoList context = new TodoListWPF.Model.TodoList())
            {
              var user=   context.Users.Where(x => x.Username == username).FirstOrDefault();
                    Assert.IsTrue(user != null && result == "OK");
            }
        }
        [TestMethod]
        public void ValidationWrongPasswordTest()
        {
            Register register = new Register();
            Assert.IsTrue(!register.ValidatePassword("1") && !register.ValidatePassword("test")&& !register.ValidatePassword("Test1*Test1*") && !register.ValidatePassword("Te1")&& !register.ValidatePassword("test1*") && !register.ValidatePassword("T1*"));
        }
        [TestMethod]
        public void ValidationValidPasswordTest()
        {
            Register register = new Register();
            Assert.IsTrue(register.ValidatePassword("1Test*") && register.ValidatePassword("Test2") && register.ValidatePassword("Tes2") && register.ValidatePassword("T2*m") );
        }
    }
}
