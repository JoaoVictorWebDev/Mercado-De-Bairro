using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Crypt
{
    public static class SuperMarketCrypt
    {
        public static string HashPassword(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value); 
        }

        public static bool Verify(string  value , string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(value, passwordHash);
        }
    }
}
