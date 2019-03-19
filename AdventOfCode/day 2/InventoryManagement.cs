using System.Linq;

namespace AdventOfCode.day_2
{
    public static class InventoryManagement
    {
        public static int CountMultipleOccurencies(string[] input)
        {
            int countOfTwoOccurencies = 0;
            int countOfThreeOccurencies = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var occurencies = line.ToCharArray()
                    .GroupBy(c => c)
                    .Where(c => c.Count() == 2 || c.Count() == 3)
                    .Select(c => c.Count()).ToList();

                countOfTwoOccurencies += occurencies.Any(o => o == 2) ? 1 : 0;
                countOfThreeOccurencies += occurencies.Any(o => o == 3) ? 1 : 0;
            }

            return countOfTwoOccurencies * countOfThreeOccurencies;
        }

        public static string GetCommonLetters(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var searchArray = input[i].ToCharArray();
                foreach (var line in input)
                {
                    var currentLine = line.ToCharArray();
                    if (searchArray.Length != currentLine.Length)
                    {
                        continue;
                    }

                    var diff = searchArray.Where((current, index) => current != currentLine[index]).Count();

                    if (diff == 1)
                    {
                        var result = searchArray.Where((current, index) => current == currentLine[index]).ToArray();
                        return new string(result);
                    }
                }
            }

            return string.Empty;
        }
    }
}
