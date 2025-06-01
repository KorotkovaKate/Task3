using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static List<List<int>> dices = [];

        static void Main(string[] args)
        {
            dices = DiceParser.Parse(args);
            GameEngine.StartGame(dices);
        }
    }
}
