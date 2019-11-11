using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWPF.Helpers
{
    public static class PasswordHash
    {
        //This should be updated with https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
        public static string Hash (string password)
            {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Convert.FromBase64String(password);
            var sha1data = sha1.ComputeHash(data);
            return  System.Text.Encoding.UTF8.GetString(sha1data);
        }
    }
}
