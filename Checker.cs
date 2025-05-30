using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Checker
    {
        public static void CheckDiceCount(int count) 
        {
            if (count < 3)
            {
                Console.WriteLine("You must provide at least 3 dice configurations");
                Environment.Exit(0);
            }
        }
        public static void CheckDiceFaces(string arg, string[] values)
        {
            if (values.Length < 2)
            {
                Console.WriteLine($"Invalid dice configuration {arg} Each dice must have at least two faces");
                Environment.Exit(0);
            }
            foreach (var value in values)
            {
                if (!int.TryParse(value, out _))
                {
                    Console.WriteLine($"Invalid dice value {value} in {arg} It must be only integers");
                    Environment.Exit(0);
                }
            }
        }
    }
}
