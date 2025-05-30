using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class RandomGenerator
    {
        public static byte[] RandomGeneratorBytes()
        {
            byte[] randomBytes = new byte[32];
            RandomNumberGenerator.Fill(randomBytes);
            return randomBytes;
        }
        public static int ChooseRandomNumber(int min, int max)
        {
            return RandomNumberGenerator.GetInt32(min, max + 1);
        }
    }
}
