using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> uniqueSymbols = new List<char>();
            string inpText = Console.ReadLine();
            string textToLower = inpText.ToLower();
            for (int i = 0; i < textToLower.Length; i++)
            {
                if (char.IsSymbol(textToLower[i]) || char.IsLetter(textToLower[i]))
                    if (!uniqueSymbols.Contains(textToLower[i]))
                        uniqueSymbols.Add(textToLower[i]);
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(string.Join("", uniqueSymbols));
            //----------------------------------------------------
            // Pattern to get Int Numbers:  @"(?<=[^0-9])[0-9]+"
            // Pattern to get Strings before any Numbers:  @"(?<getstr>\D+(?=[0-9]))"
            // Pattern to get Strings and any Numbers:  @"(?<textdig>\D+\d+)"
            string patternTxtDig = @"(?<textdig>\D+\d+)";
            List<string> textAndDigits = new List<string>();
            MatchCollection matchArr = Regex.Matches(inpText, patternTxtDig);
            for (int i = 0; i < matchArr.Count; i++)
            {
                string getMatch = matchArr[i].Groups["textdig"].Value;
                textAndDigits.Add(getMatch);
            }
            string patternStr = @"(?<getstr>\D+(?=[0-9]))";
            string patternDig = @"(?<=[^0-9])[0-9]+";
            Regex regStr = new Regex(patternStr);
            Regex regDig = new Regex(patternDig);
            StringBuilder tempText = new StringBuilder();
            StringBuilder finalText = new StringBuilder();
            for (int i = 0; i < textAndDigits.Count; i++)
            {
                string getText = regStr.Match(textAndDigits[i]).Value;
                int getNum = int.Parse(regDig.Match(textAndDigits[i]).Value);
                for (int k = 1; k <= getNum; k++)
                {
                    tempText.Append(getText);
                }
                string textSave = tempText.ToString().ToUpper();
                finalText.Append(textSave);
                tempText.Clear();
            }
            Console.WriteLine(finalText.ToString());
        }
    }
}
