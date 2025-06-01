using ConsoleTableExt;

namespace Task3
{
    public class HelpTable
    {
        private static List<List<object>> CreateTable(List<List<int>> dices)
        {
            string[,] probabilities = DataHelpTable.SortOutDicesPairs();

            List<List<object>> tableData = [];

            var headerRow = new List<object> { "Dices" };

            for (int i = 0; i < dices.Count; i++)
            {
                headerRow.Add("[ " + String.Join(", ", dices[i]) + " ]");
            }

            tableData.Add(headerRow);

            for (int i = 0; i < dices.Count; i++)
            {
                var rowData = new List<object> { "[ " + String.Join(", ", dices[i]) + " ]" };

                for (int j = 0; j < dices.Count; j++)
                {
                    rowData.Add(probabilities[i, j]);
                }

                tableData.Add(rowData);
            }

            return tableData;
        }

        public static void DisplayHelpTable(List<List<int>> dices)
        {
            List<List<object>> tableData = CreateTable(dices);

            ConsoleTableBuilder.From(tableData)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }
    }
}
