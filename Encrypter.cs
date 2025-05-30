using SHA3.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Encrypter
    {
        public static string CreateKey(byte[] keyBytes)
        {
            byte[] hashedBytes = Sha3.Sha3256().ComputeHash(keyBytes);
            string key = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return key;
        }
        public static string CreateHMAC(string key, int number)
        {
            byte[] combinedBytes = Encoding.UTF8.GetBytes(key + number);
            byte[] hashedBytes = Sha3.Sha3256().ComputeHash(combinedBytes);
            string hmac = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hmac;
        }
    }
}
