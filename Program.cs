using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] values = ["1,2,3,4,5,6", "1,2,3,4,5,6", "1,2,3,4,5,6"];
            var dices = DiceParser.Parse(values);
            foreach (var arg in values)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
