using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfsData = new Dictionary<string, int>();
            string inpText = "";
            while((inpText = Console.ReadLine()) != "Once upon a time")
            {
                string[] commandLine = inpText.Split(" <:> ");
                string name = commandLine[0];
                string colour = commandLine[1];
                string nameColour = string.Join(" ", name, colour);
                int physics = int.Parse(commandLine[2]);
                if (!dwarfsData.ContainsKey(nameColour))
                    dwarfsData.Add(nameColour, physics);
                else
                {
                    if (dwarfsData[nameColour] < physics)
                        dwarfsData[nameColour] = physics;
                }
            }
            foreach (var kvp in dwarfsData.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfsData.Keys.Count(y => y.Split()[1] == x.Key.Split()[1])))
            {
                Console.WriteLine($"({kvp.Key.Split()[1]}) {kvp.Key.Split()[0]} <-> {kvp.Value}");
            }
        }
    }
}
