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
            Checker.CheckDiceCount(args.Length);
            var dices = new List<List<int>>();
            var dice = new List<int>();
            foreach (var arg in args)
            {
                string[] values = arg.Split(',');
                Checker.CheckDiceFaces(arg, values);
                foreach (var value in values)
                {
                        dice.Add(Convert.ToInt32(value));
                }
                dices.Add(dice);
                dice = [];
            }
            return dices;
        }
    }
}
