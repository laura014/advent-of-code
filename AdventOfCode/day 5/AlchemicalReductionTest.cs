using System;
using System.Collections;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode.day_5
{
    [TestFixture]
    public class AlchemicalReductionTest
    {
        [TestCase("dabAcCaCBAcCcaDA", ExpectedResult = "dabCBAcaDA")]
        [TestCase("aA", ExpectedResult = "")]
        [TestCase("abBA", ExpectedResult = "")]
        [TestCase("aabAAB", ExpectedResult = "aabAAB")]
        public string Test_GetPolymer(string input)
        {
            return AlchemicalReduction.GetPolymer2(input);
        }

        [TestCaseSource(nameof(GetInputFromFile))]
        public int Test_GetPolymerUnits(string input)
        {
            return AlchemicalReduction.GetPolymerUnits(input);
        }

        
        [TestCase("dabAcCaCBAcCcaDA", ExpectedResult = 4)]
        [TestCaseSource(nameof(GetInputFromFile))]
        public int Test_GetShortestPolymer(string input)
        {
            return AlchemicalReduction.GetShortestPolymer(input);
        }

        public static IEnumerable GetInputFromFile()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"day 5\input.txt");
            yield return new TestCaseData(File.ReadAllText(path)).Returns(9202);
        }
    }
}
