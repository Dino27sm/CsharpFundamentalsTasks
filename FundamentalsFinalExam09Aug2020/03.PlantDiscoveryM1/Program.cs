using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.PlantDiscoveryM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plantRarity = new Dictionary<string, int>();
            Dictionary<string, List<int>> plantRating = new Dictionary<string, List<int>>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] getRarity = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = getRarity[0];
                int valueRarity = int.Parse(getRarity[1]);
                if (!plantRarity.ContainsKey(plantName))
                {
                    plantRarity.Add(plantName, valueRarity);
                    plantRating.Add(plantName, new List<int>());
                }
                else
                    plantRarity[plantName] = valueRarity;
            }

            string commText = "";
            while ((commText = Console.ReadLine()) != "Exhibition")
            {
                string[] commandParts = commText
                    .Split(new string[] { ": ", " - ", " " }, StringSplitOptions.RemoveEmptyEntries);
                string majorCommand = commandParts[0];
                string plant = commandParts[1];
                if (majorCommand == "Rate")
                {
                    int ratingNum = int.Parse(commandParts[2]);
                    if (plantRating.ContainsKey(plant))
                        plantRating[plant].Add(ratingNum);
                    else Console.WriteLine("error");
                }
                else if (majorCommand == "Update")
                {
                    int newRarity = int.Parse(commandParts[2]);
                    if (plantRarity.ContainsKey(plant))
                        plantRarity[plant] = newRarity;
                    else Console.WriteLine("error");
                }
                else if (majorCommand == "Reset")
                    if (plantRating.ContainsKey(plant))
                        plantRating[plant] = new List<int>();
                    else Console.WriteLine("error");
                else Console.WriteLine("error");
            }
            Dictionary<string, double> averagePlantRating = new Dictionary<string, double>();
            foreach (var kvp in plantRating)
            {
                if (kvp.Value.Count != 0)
                    averagePlantRating.Add(kvp.Key, kvp.Value.Average());
                else averagePlantRating.Add(kvp.Key, 0.0);
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in plantRarity.OrderByDescending(x => x.Value)
                .ThenByDescending(y => averagePlantRating[y.Key]))
            {
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value}; Rating: {averagePlantRating[kvp.Key]:F2}");
            }
        }
    }
}
