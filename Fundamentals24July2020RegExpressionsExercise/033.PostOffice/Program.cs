using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pattern to mach proper numbers:   @"(?<numbers>[0-9]{2}:[0-9]{2})"
            // Pattern to check surrounded capital letters - #, $, %, *, &.
            string lettersIsolate = @"([#][A-Z]+[#])|([$][A-Z]+[$])|([%][A-Z]+[%])|([*][A-Z]+[*])|([&][A-Z]+[&])";
            string numberPattern = @"(?<numbers>[0-9]{2}:[0-9]{2})";

            string[] inpText = Console.ReadLine().Split("|");
            string partOne = inpText[0];
            string partTwo = inpText[1];
            string partThree = inpText[2];
            Regex regLetters = new Regex(lettersIsolate);
            Match matchLetters = regLetters.Match(partOne);
            string capitalLetters = "";
            if (matchLetters.Success) capitalLetters = matchLetters.Value;

            Regex regNumbers = new Regex(numberPattern);
            MatchCollection matchNumbers = regNumbers.Matches(partTwo);
            List<int> asciiNum = new List<int>();
            List<int> countSymbols = new List<int>();
            for (int i = 0; i < matchNumbers.Count; i++)
            {
                string[] getNumbers = matchNumbers[i].Value.Split(":");
                if (capitalLetters.Contains((char)int.Parse(getNumbers[0])))
                {
                    if (!asciiNum.Contains(int.Parse(getNumbers[0])))
                    {
                        asciiNum.Add(int.Parse(getNumbers[0]));
                        countSymbols.Add(int.Parse(getNumbers[1]));
                    }
                    else
                    {
                        int indexMatch = asciiNum.IndexOf(int.Parse(getNumbers[0]));
                        if (countSymbols[indexMatch] != int.Parse(getNumbers[1]))
                        {
                            asciiNum.Add(int.Parse(getNumbers[0]));
                            countSymbols.Add(int.Parse(getNumbers[1]));
                        }
                    }
                }
            }
            string[] namesNum = partThree.Split();
            for (int i = 0; i < namesNum.Length; i++)
            {
                string takeName = namesNum[i];
                for (int k = 0; k < asciiNum.Count; k++)
                {
                    if (capitalLetters.Contains((char)asciiNum[k]))
                    {
                        if(takeName[0] == (char)asciiNum[k] && takeName.Length == countSymbols[k] + 1)
                        {
                            Console.WriteLine(takeName);
                        }
                    }
                }
            }
        }
    }
}
