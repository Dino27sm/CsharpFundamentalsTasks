using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> familiData = new Dictionary<string, int>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] enterLines = Console.ReadLine().Split().ToArray();
                string name = enterLines[0];
                int age = int.Parse(enterLines[1]);
                if (!familiData.ContainsKey(name))
                    familiData.Add(name, age);
            }
            KeyValuePair<string, int> printOut = familiData.OrderByDescending(x => x.Value).First();
            //var printOut = familiData.OrderByDescending(x => x.Value).First();
            Console.WriteLine($"{printOut.Key} {printOut.Value}");
        }
    }
}
