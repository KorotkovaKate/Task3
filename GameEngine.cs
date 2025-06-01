using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class GameEngine
    {
        public static void OutputGeneralData(string hmac)
        {
            Console.WriteLine($"I selected a random value in the range 0..5");
            Console.WriteLine($"(HMAC = {hmac})");
            Console.WriteLine("Add your number modulo 6");
            Console.WriteLine("0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
            Console.Write("Your selection: ");
        }
        public static string UserSelect()
        {
            while (true)
            {
                string userSelection = Console.ReadLine();
                if (userSelection == "X") Environment.Exit(0);
                if (userSelection == "?")
                {
                    HelpTable.DisplayHelpTable(Program.dices);
                    continue;
                }
                else if (!int.TryParse(userSelection, out int userNumber) || userNumber < 0 || userNumber > 5)
                {
                    Console.WriteLine("Invalid choice, select a valid one");
                }
                else return userSelection;
            }
        }
        public static int Roll()
        {
            int randomIndex = RandomGenerator.ChooseRandomNumber(0, 5);
            byte[] randomBytes = RandomGenerator.RandomGeneratorBytes();
            string key = Encrypter.CreateKey(randomBytes);
            string hmac = Encrypter.CreateHMAC(key, randomIndex);
            OutputGeneralData(hmac);
            string userSelection = UserSelect();
            int userNumber = Convert.ToInt32(userSelection);
            Console.WriteLine($"My number is {randomIndex} (KEY={key})");
            int result = (randomIndex + userNumber) % 6;
            Console.WriteLine($"The fair number generation result is {randomIndex} + {userNumber} = {result} (mod 6)");
            return result;
        }
        public static int ComputerMove(List<int> computerDice)
        {
            int computerRoll = Roll();
            int computerRollResult = computerDice[computerRoll];
            Console.WriteLine($"My roll result is {computerRollResult}");
            return computerRollResult;
        }
        public static int UserMove(List<int> userDice)
        {
            int userRoll = Roll();
            int userRollResult = userDice[userRoll];
            Console.WriteLine($"Your roll result is {userRollResult}");
            return userRollResult;
        }
        public static void DefineWinner(int userResult, int computerResult)
        {
            if (userResult > computerResult) Console.WriteLine($"You won ({userResult}>{computerResult})");
            else if (userResult < computerResult) Console.WriteLine($"I won ({userResult}<{computerResult})");
            else Console.WriteLine($"Draw ({userResult}={computerResult})");
        }

        public static void StartGame(List<List<int>> dices)
        {
            bool isUserGuess = FirstPlayerSelection.SelectFirstMove();
            Console.WriteLine(isUserGuess ? "You start first" : "I start first");

            if (isUserGuess)
            {
                (List<int>, List<int>) userAndComputerDice = ChooseDices.StartWithUser(dices);
                List<int> userDice = userAndComputerDice.Item1;
                List<int> computerDice = userAndComputerDice.Item2;

                int userResult = UserMove(userDice);
                int computerResult = ComputerMove(computerDice);
                DefineWinner(userResult, computerResult);
            }
            else
            {
                (List<int>, List<int>) userAndComputerDice = ChooseDices.StartWithComputer(dices);
                List<int> userDice = userAndComputerDice.Item1;
                List<int> computerDice = userAndComputerDice.Item2;

                int computerResult = ComputerMove(computerDice);
                int userResult = UserMove(userDice);
                DefineWinner(userResult, computerResult);
            }
        }
    }
}
