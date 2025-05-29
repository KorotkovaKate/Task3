using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DiceParser
    {
        public static List<List<int>> Parse(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("You must provide at least 3 dice configurations");
                Environment.Exit(0);
            }
            var dices = new List<List<int>>();
            var faces = new List<int>();
            foreach (var arg in args)
            {
                string[] values = arg.Split(',');
                if (values.Length < 2)
                {
                    Console.WriteLine($"Invalid dice configuration: {arg}. Each dice must have at least two faces");
                    Environment.Exit(0);
                }
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int face))
                    {
                        faces.Add(face);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid dice value: {value} in {arg}. It must be only integers");
                        Environment.Exit(0);
                    }
                }
                dices.Add(faces);
            }
            return dices;
        }
    }
}
