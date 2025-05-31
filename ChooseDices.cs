using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class ChooseDices
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
        public static void UserSelect(string userSelection, List<List<int>> dices)
        {
            while (true) 
            {
                if (userSelection == "X") Environment.Exit(0);
                if (userSelection == "?") Console.WriteLine("Table");//To do later
                if (!int.TryParse(userSelection, out int chosenIndex) || chosenIndex < 0 || chosenIndex >= dices.Count)
                {
                    Console.WriteLine("Invalid choice, select a valid one");
                }
                else return;
            }

        }
        public static void StartWithUser(List<List<int>> dices)
        {
            OutputGeneralData(dices);
            string userSelection = Console.ReadLine();
            UserSelect(userSelection, dices);
            List<int> userDice = dices[Convert.ToInt32(userSelection)];
            Console.WriteLine($"You choose the [{string.Join(",", userDice)}] dice");
            dices.Remove(userDice);
            int randomIndex = RandomGenerator.ChooseRandomNumber(0, dices.Count - 1);
            List<int> computerDice = dices[randomIndex];
            Console.WriteLine($"I make my choice and select the [{string.Join(",", computerDice)}] dice");
            Console.WriteLine("It's time for your roll!");
        }
        public static void StartWithComputer(List<List<int>> dices) 
        {
            int randomIndex = RandomGenerator.ChooseRandomNumber(0, dices.Count - 1);
            List<int> computerDice = dices[randomIndex];
            Console.WriteLine($"I make the first move and choose the [{string.Join(",", computerDice)}] dice");
            dices.Remove(computerDice);
            OutputGeneralData(dices);
            string userSelection = Console.ReadLine();
            UserSelect(userSelection, dices);
            List<int> userDice = dices[Convert.ToInt32(userSelection)];
            Console.WriteLine($"You choose the [{string.Join(",", userDice)}] dice");
            Console.WriteLine("It's time for my roll!");
        }
    }
}