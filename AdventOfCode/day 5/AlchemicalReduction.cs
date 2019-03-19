using System;
using System.Linq;

namespace AdventOfCode.day_5
{
    public class AlchemicalReduction
    {
        public static int GetPolymerUnits(string input)
        {
            string polymer = GetPolymer(input);
            return polymer.Length;
        }

        public static string GetPolymer(string input)
        {
            var result = string.Empty;
            for (var i = 0; i < input.Length; i++)
            {
                if (i < input.Length - 1 && AreReactive(input[i], input[i + 1]))
                {
                    i++;
                }
                else
                {
                    result += input[i];
                }
            }

            if (input != result)
            {
                return GetPolymer(result);
            }
            return input;
        }
        
        public static int GetShortestPolymer(string input)
        {
            var min = int.MaxValue;
            var alphabet = Enumerable.Range('a', 'z' - 'a' + 1);
            foreach (var letter in alphabet)
            {
                var c = (char)letter;
                var newInput = input.Replace(char.ToLower(c).ToString(), string.Empty);
                newInput = newInput.Replace(char.ToUpper(c).ToString(), string.Empty);
                var length = GetPolymerUnits(newInput);
                if (length < min)
                {
                    min = length;
                }
            }

            return min;
        }

        private static bool AreReactive(char a, char b)
        {
            return char.ToLower(a) == char.ToLower(b) && (char.IsLower(a) && char.IsUpper(b) || char.IsUpper(a) && char.IsLower(b));
        }
    }
}
