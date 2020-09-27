using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] star = new char[] {'s', 'S', 't', 'T', 'a', 'A', 'r', 'R' };
            List<string> decodedMessage = new List<string>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string inpText = Console.ReadLine();
                int decriptKey = 0;
                for (int k = 0; k < inpText.Length; k++)
                {
                    for (int m = 0; m < star.Length; m++)
                    {
                        if (inpText[k] == star[m]) decriptKey++;
                    }
                }
                char convertedSymbol;
                StringBuilder decodedInpText = new StringBuilder();
                for (int m = 0; m < inpText.Length; m++)
                {
                    convertedSymbol = (char)((int)inpText[m] - decriptKey);
                    decodedInpText.Append(convertedSymbol);
                }
                decodedMessage.Add(decodedInpText.ToString());
            }
            List<string> destroyedPlanets = new List<string>();
            List<string> attackedPlanets = new List<string>();
            string pattern = @"@(?<planet>[A-Za-z]+)([^@|-|!|:|>]*)\:{1}(?<population>\d+)([^@|-|!|:|>]*)\!(?<action>A|D)\!([^@|-|!|:|>]*)\-\>(?<soldiers>\d+)";
            for (int i = 0; i < decodedMessage.Count; i++)
            {
                Match regMatch = Regex.Match(decodedMessage[i], pattern);
                if (regMatch.Success)
                {
                    string planetName = regMatch.Groups["planet"].Value;
                    long populationNum = long.Parse(regMatch.Groups["population"].Value);
                    string actionType = regMatch.Groups["action"].Value;
                    long soldiersNum = long.Parse(regMatch.Groups["soldiers"].Value);
                    if (actionType == "A") attackedPlanets.Add(planetName);
                    else destroyedPlanets.Add(planetName);
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string item in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string item in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
