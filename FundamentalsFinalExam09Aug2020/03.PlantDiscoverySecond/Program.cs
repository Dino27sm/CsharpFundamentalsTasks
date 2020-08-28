using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.PlantDiscoverySecond
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plants> plantsData = new Dictionary<string, Plants>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] plantInfoParts = Console.ReadLine().Split("<->");
                string plantName = plantInfoParts[0];
                int plantRarity = int.Parse(plantInfoParts[1]);
                if (!plantsData.ContainsKey(plantName))
                {
                    plantsData.Add(plantName, new Plants(plantRarity));
                }
                else plantsData[plantName].PlantRarity = plantRarity; 
            }
            string instruction = "";
            while((instruction = Console.ReadLine()) != "Exhibition")
            {
                string[] commandParts = instruction
                    .Split(new string[] { ": ", " - ", " " }, StringSplitOptions.RemoveEmptyEntries);
                string majorCommand = commandParts[0];
                string namePlant = commandParts[1];
                if(majorCommand == "Rate")
                {
                    int ratingPlant = int.Parse(commandParts[2]);
                    if (plantsData.ContainsKey(namePlant))
                        plantsData[namePlant].PlantRating.Add(ratingPlant);
                    else Console.WriteLine("error");
                }
                else if (majorCommand == "Update")
                {
                    int newRarity = int.Parse(commandParts[2]);
                    if (plantsData.ContainsKey(namePlant))
                        plantsData[namePlant].PlantRarity = newRarity;
                    else Console.WriteLine("error");

                }
                else if (majorCommand == "Reset")
                {
                    if (plantsData.ContainsKey(namePlant))
                        plantsData[namePlant].PlantRating.Clear();
                    else Console.WriteLine("error");
                }
                else Console.WriteLine("error");
            }
            foreach (var kvp in plantsData)
            {
                if (kvp.Value.PlantRating.Count == 0) kvp.Value.AverageRating = 0.0;
                else kvp.Value.AverageRating = kvp.Value.PlantRating.Average();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in plantsData.OrderByDescending(x => x.Value.PlantRarity)
                .ThenByDescending(y => y.Value.AverageRating))
            {
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.PlantRarity}; Rating: {kvp.Value.AverageRating:F2}");
            }
        }
    }

    public class Plants
    {
        public int PlantRarity { get; set; }
        public double AverageRating { get; set; }
        public List<int> PlantRating { get; set; } = new List<int>();
        public Plants(int plantRarity)
        {
            this.PlantRarity = plantRarity;
        }
    }
}
