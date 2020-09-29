using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<double>> demonData = new SortedDictionary<string, List<double>>();
            string charPattern = @"[^0-9+-\.*\/]+";
            string numPattern = @"(\-?\d+\.?\d+)|(\+\d+\.?\d+)|(\-\d+)|(\+\d+)|(\d+)";
            string multiplayDevide = @"\/|\*";
            List<string> demonNames = Console.ReadLine()
                .Split(new string[] {", ", " ", ",", " , " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            for (int i = 0; i < demonNames.Count; i++)
            {
                string nameDemon = demonNames[i];
                StringBuilder nameChars = new StringBuilder();
                MatchCollection regChars = Regex.Matches(nameDemon, charPattern);
                for (int k = 0; k < regChars.Count; k++)
                {
                    if (regChars[k].Success)
                        nameChars.Append(regChars[k].Value).ToString();
                }
                int sumAscii = nameChars.ToString().Select(x => (int)x).ToArray().Sum();
                double asciiDecimal = (double)sumAscii;
                MatchCollection regNumbers = Regex.Matches(nameDemon, numPattern);
                double sumNumbers = 0.0;
                for (int k = 0; k < regNumbers.Count; k++)
                {
                    if (regNumbers[k].Success)
                        sumNumbers += double.Parse(regNumbers[k].Value);
                }
                MatchCollection regMultiDevide = Regex.Matches(nameDemon, multiplayDevide);
                for (int k = 0; k < regMultiDevide.Count; k++)
                {
                    if (regMultiDevide[k].Success)
                    {
                        if (regMultiDevide[k].Value == "*") sumNumbers *= 2.0;
                        else if (regMultiDevide[k].Value == "/") sumNumbers /= 2.0;
                    }
                }
                if (!demonData.ContainsKey(nameDemon))
                {
                    demonData.Add(nameDemon, new List<double>());
                    demonData[nameDemon].Add(asciiDecimal);
                    demonData[nameDemon].Add(sumNumbers);
                }
            }
            foreach (var kvp in demonData)
                Console.WriteLine($"{kvp.Key} - {kvp.Value[0]} health, {kvp.Value[1]:F2} damage");
        }
    }
}
