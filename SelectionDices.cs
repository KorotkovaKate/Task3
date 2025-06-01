using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class SelectionDices
    {
        public static void OutputGeneralData(List<List<int>> dices)
        {
            Console.WriteLine("Choose your dice:");
            for (int i = 0; i < dices.Count; i++)
            {
                Console.WriteLine($"{i} - {string.Join(",", dices[i])}");
            }
            Console.WriteLine("X - exit\n? - help");
            Console.Write("Your selection: ");
        }
        public static string UserSelect (List<List<int>> dices)
        {
            while (true) 
            {
                string userSelection = Console.ReadLine().ToLower();
                if (userSelection == "x") Environment.Exit(0);
                if (userSelection == "?")
                {
                    HelpTable.DisplayHelpTable(Program.dices);
                    continue;
                }
                else if (!int.TryParse(userSelection, out int chosenIndex) || chosenIndex < 0 || chosenIndex >= dices.Count)
                {
                    Console.WriteLine("Invalid choice, select a valid one");
                }
                else return userSelection;
            }
        }
        public static List<int> UserChooseDice(List<List<int>> dices)
        {
            string userSelection = UserSelect(dices);
            List<int> userDice = dices[Convert.ToInt32(userSelection)];
            return userDice;
        }
        public static List<int> ComputerChooseDice(List<List<int>> dices)
        {
            int randomIndex = RandomGenerator.ChooseRandomNumber(0, dices.Count - 1);
            List<int> computerDice = dices[randomIndex];
            return computerDice;
        }
        public static (List<int>, List<int>) StartWithUser(List<List<int>> dices)
        {
            OutputGeneralData(dices);
            List<int> userDice = UserChooseDice(dices);
            Console.WriteLine($"You choose the [{string.Join(",", userDice)}] dice");
            dices.Remove(userDice);
            List<int> computerDice = ComputerChooseDice(dices);
            Console.WriteLine($"I make my choice and select the [{string.Join(",", computerDice)}] dice");
            Console.WriteLine("It's time for your roll!");
            return (userDice, computerDice);
        }
        public static (List<int>, List<int>) StartWithComputer(List<List<int>> dices) 
        {
            List<int> computerDice = ComputerChooseDice(dices);
            Console.WriteLine($"I make the first move and choose the [{string.Join(",", computerDice)}] dice");
            dices.Remove(computerDice);
            OutputGeneralData(dices);
            List<int> userDice = UserChooseDice(dices);
            Console.WriteLine($"You choose the [{string.Join(",", userDice)}] dice");
            Console.WriteLine("It's time for my roll!");
            return (userDice, computerDice);
        }
    }
}