using System;
using System.Text.RegularExpressions;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternText = @"(@(?<name>[A-Za-z]+)\|{1})|(\#{1}(?<age>\d+)\*{1})";
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numLines; i++)
            {
                string inpText = Console.ReadLine();
                MatchCollection twoMatches = Regex.Matches(inpText, patternText);
                string getName = "";
                string getAge = "";
                for (int k = 0; k < twoMatches.Count; k++)
                {
                    if (twoMatches[k].Groups["name"].Success)
                        getName = twoMatches[k].Groups["name"].Value;
                    else if (twoMatches[k].Groups["age"].Success)
                        getAge = twoMatches[k].Groups["age"].Value;
                }
                Console.WriteLine($"{getName} is {getAge} years old.");
            }
        }
    }
}
