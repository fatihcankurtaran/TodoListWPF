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
            Assert.IsTrue((register.RegisterUser("Fatih", "Cankurtaran",rnd.Next(1000,10000).ToString(), "1Test*") == "OK") && (register.RegisterUser("Fatih", "Cankurtaran", rnd.Next(1000, 10000).ToString(), "1Te") != "OK")); 
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
