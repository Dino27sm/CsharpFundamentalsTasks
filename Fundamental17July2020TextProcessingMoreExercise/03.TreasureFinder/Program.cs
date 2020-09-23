using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternCheck = @".*[&](?<name>[\w]+)[&].*[<](?<place>.*)[>].*";
            int[] keyNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string inpText = "";
            while((inpText = Console.ReadLine()) != "find")
            {
                char[] charText = inpText.ToCharArray();
                int indexKey = 0;
                for (int i = 0; i < charText.Length; i++)
                {
                    indexKey = i % keyNum.Length;
                    charText[i] = (char)(inpText[i] - keyNum[indexKey]);
                }
                string dataText = string.Join("",charText);
                Regex regObject = new Regex(patternCheck);
                Match getInfo = regObject.Match(dataText);
                if (getInfo.Success)
                    Console.WriteLine($"Found {getInfo.Groups["name"]} at {getInfo.Groups["place"]}");
            }
        }
    }
}
