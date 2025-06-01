using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DataHelpTable
    {
        private static List<List<int>> _dices = [];

        private static void InitializeDices()
        {
            _dices = Program.dices;
        }

        public static string[,] SortOutDicesPairs()
        {
            InitializeDices();

            int countOfDices = _dices.Count;

            string[,] probabilityOfVictory = new string[countOfDices, countOfDices];

            for (int i = 0; i < countOfDices; i++)
            {
                for (int j = 0; j < countOfDices; j++)
                {
                    if (i == j)
                    {
                        probabilityOfVictory[i, j] = "-";
                        continue;
                    }

                    probabilityOfVictory[i, j] = GetProbabilityOfVictory(_dices[i], _dices[j]).ToString();
                }
            }

            return probabilityOfVictory;
        }

        private static double GetProbabilityOfVictory(List<int> dice1, List<int> dice2)
        {
            int aWins = 0;

            int bWins = 0;

            int draws = 0;

            foreach (int faceDice1 in dice1)
            {
                foreach (int faceDice2 in dice2)
                {
                    if (faceDice1 > faceDice2) aWins++;

                    else if (faceDice1 < faceDice2) bWins++;

                    else draws++;
                }
            }

            int totalPairs = dice1.Count * dice2.Count;   //always 36

            return (double)aWins / totalPairs;
        }
    }
}
