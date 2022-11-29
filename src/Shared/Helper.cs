using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Shared
{
    public static class Helper
    {
        public static int LastDigit(int number) => number % 10;
        public static int RemoveLastDigit(int number) => number / 10;
    }
}
