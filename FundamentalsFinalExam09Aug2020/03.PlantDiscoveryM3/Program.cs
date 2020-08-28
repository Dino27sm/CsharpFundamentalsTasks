using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscoveryM3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PlantData> plantsDict = new Dictionary<string, PlantData>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] rarityInfo = Console.ReadLine().Split("<->");
                string plantName = rarityInfo[0];
                int plantRarity = int.Parse(rarityInfo[1]);
                if (!plantsDict.ContainsKey(plantName))
                {
                    PlantData getPlantOject = new PlantData(plantRarity);
                    plantsDict.Add(plantName, getPlantOject);
                }
                else plantsDict[plantName].PlantRarity = plantRarity;
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
                    if (plantsDict.ContainsKey(namePlant))
                        plantsDict[namePlant].RateList.Add(ratingPlant);
                    else Console.WriteLine("error");
                }
                else if (majorCommand == "Update")
                {
                    int newRarity = int.Parse(commandParts[2]);
                    if (plantsDict.ContainsKey(namePlant))
                        plantsDict[namePlant].PlantRarity = newRarity;
                    else Console.WriteLine("error");
                }
                else if (majorCommand == "Reset")
                {
                    if (plantsDict.ContainsKey(namePlant))
                        plantsDict[namePlant].RateList.Clear();
                    else Console.WriteLine("error");
                }
                else Console.WriteLine("error");
            }
            foreach (var kvp in plantsDict)
            {
                if (kvp.Value.RateList.Count != 0)
                    kvp.Value.AverageRate = kvp.Value.RateList.Average();
                else kvp.Value.AverageRate = 0.0;
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plantsDict.OrderByDescending(x => x.Value.PlantRarity)
                .ThenByDescending(y => y.Value.AverageRate))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.PlantRarity}; Rating: {item.Value.AverageRate:F2}");
            }
        }
    }

    public class PlantData
    {
        public int PlantRarity { get; set; }
        public List<int> RateList { get; set; } = new List<int>();
        public double AverageRate { get; set; }
        public PlantData(int rarity)
        {
            this.PlantRarity = rarity;
            //this.RateList = new List<int>();
        }
    }
}
