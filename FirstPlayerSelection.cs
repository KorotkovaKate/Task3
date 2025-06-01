using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class FirstPlayerSelection
    {
        public static bool SelectFirstMove()
        {
            byte[] randoms = RandomGenerator.RandomGeneratorBytes();
            string key = Encrypter.CreateKey(randoms);
            int computerSelection = RandomGenerator.ChooseRandomNumber(0, 1);
            string hmac = Encrypter.CreateHMAC(key, computerSelection);
            Console.WriteLine($"Let's determine who makes the first move");
            Console.WriteLine($"I selected a random value in the range 0..1 (HMAC={hmac}). Try to guess my selection");
            Console.WriteLine("0 - 0\n1 - 1\nX - exit\n? - help");
            bool isGuess;
            while (true)
            {
                Console.Write("Your selection: ");
                string userSelection = Console.ReadLine();
                if (userSelection == "X") Environment.Exit(0);
                else if (userSelection == "?") 
                {
                    HelpTable.DisplayHelpTable(Program.dices);
                    continue;
                }
                if (userSelection == "0" || userSelection == "1")
                {
                    Console.WriteLine($"My selection: {computerSelection} (KEY={key})");
                    if (userSelection == computerSelection.ToString()) isGuess = true;
                    else isGuess = false;
                    return isGuess;
                }
                Console.WriteLine("Invalid input. Please choose 0 or 1");
            }
        }
    }
}
