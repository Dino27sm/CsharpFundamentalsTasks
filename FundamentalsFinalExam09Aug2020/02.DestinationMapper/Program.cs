using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            int travelPoints = 0;
            List<string> placesList = new List<string>();
            string pattern = @"(\=|\/)([A-Z][A-Za-z]{2,})\1";
            string inpText = Console.ReadLine();
            MatchCollection getPlaces = Regex.Matches(inpText, pattern);
            if (getPlaces.Count > 0)
            {
                for (int i = 0; i < getPlaces.Count; i++)
                {
                    placesList.Add(getPlaces[i].Groups[2].Value);
                }
            }
            for (int k = 0; k < placesList.Count; k++)
            {
                int countChar = placesList[k].Length;
                travelPoints += countChar;
            }
            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", placesList));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
