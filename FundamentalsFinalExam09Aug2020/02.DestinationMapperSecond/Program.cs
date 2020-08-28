using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapperSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> destinations = new List<string>();
            string pattern = @"(\=|\/)([A-Z][a-z]{2,})\1";
            string inpText = Console.ReadLine();
            MatchCollection getMatches = Regex.Matches(inpText, pattern);
            if (getMatches.Count > 0)
            {
                for (int i = 0; i < getMatches.Count; i++)
                {
                    string getDesination = getMatches[i].Groups[2].Value;
                    destinations.Add(getDesination);
                }
            }
            string allDestinations = string.Join("", destinations);
            Console.Write($"Destinations: ");
            Console.WriteLine(string.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {allDestinations.Length}");
        }
    }
}
