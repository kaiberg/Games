using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Games.Shared
{
    public static class Helper
    {
        public static int LastDigit(int number) => number % 10;
        public static int RemoveLastDigit(int number) => number / 10;
        public static string GetRandomString()
        {
            var date = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            var random = SHA512.Create().ComputeHash(date);
            return BitConverter.ToString(random).Replace("-","");
        }
    }
}
