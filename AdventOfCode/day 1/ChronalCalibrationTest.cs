using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.day_1
{
    [TestFixture]
    public class ChronalCalibrationTest
    {
        public static int GetFrequency(string[] lines)
        {
            var sum = 0;
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var value))
                {
                    sum += value;
                }
            }

            return sum;
        }

        public static int GetFirstDuplicatedFrequency(string[] lines)
        {
            var currentFrequency = 0;
            var frequencies = new HashSet<int>{currentFrequency};
            var i = 0;
            while (true)
            {
                if (i >= lines.Length)
                {
                    i = 0;
                }

                if (int.TryParse(lines[i], out var value))
                {
                    currentFrequency += value;
                    if (!frequencies.Add(currentFrequency))
                    {
                        return currentFrequency;
                    }
                }

                i++;
            }
        }
    }
}
