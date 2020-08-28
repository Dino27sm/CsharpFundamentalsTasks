using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscoveryM2
{
    class Program
    {
        static void Main(string[] args)
        {
			int inputCount = int.Parse(Console.ReadLine());
			string[] InputSeparator = { "<->" };
			string[] InputSeparatorCommand = { " - " };

			var plants = new Dictionary<string, Plant>();

			//Collect plants data
			for (int i = 0; i < inputCount; i++)
			{
				var line = Console.ReadLine();
				string[] inputParams = line.Split(InputSeparator, StringSplitOptions.RemoveEmptyEntries);
				string plantName = inputParams[0];
				int rarity = int.Parse(inputParams[1]);
				if (plants.ContainsKey(plantName))
					plants[plantName].Rarity = rarity;
				else
					plants.Add(plantName, new Plant(plantName, rarity));
			}
			//Collect and apply commands
			string instruction;
			while ((instruction = Console.ReadLine()) != "Exhibition")
			{
				string[] commandParts = instruction.Split(':');
				string majorCommand = commandParts[0];
				if (majorCommand == "Rate")
				{
					var commandInfo = commandParts[1].Split(InputSeparatorCommand, StringSplitOptions.RemoveEmptyEntries);
					string plantName = commandInfo[0].Trim();
					int rating = int.Parse(commandInfo[1]);
					if (plants.ContainsKey(plantName))
						plants[plantName].Ratings.Add(rating);
					else
						Console.WriteLine("error");
				}
				else if (majorCommand == "Update")
				{
					var commandInfo = commandParts[1].Split(InputSeparatorCommand, StringSplitOptions.RemoveEmptyEntries);
					string plantName = commandInfo[0].Trim();
					int rarity = int.Parse(commandInfo[1]);
					if (plants.ContainsKey(plantName))
						plants[plantName].Rarity = rarity;
					else
						Console.WriteLine("error");
				}
				else if (majorCommand == "Reset")
				{
					string plantName = commandParts[1].Trim();
					if (plants.ContainsKey(plantName))
						plants[plantName].Ratings.Clear();
					else
						Console.WriteLine("error");
				}
			}
			var results = plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.AverageRating);
			Console.WriteLine("Plants for the exhibition:");
			foreach (var p in results)
			{
				Console.WriteLine($"- {p.Key}; Rarity: {p.Value.Rarity}; Rating: {p.Value.AverageRating:0.00}");
			}
		}
    }
	class Plant
	{
		public string Name { get; set; }
		public int Rarity { get; set; }
		public List<int> Ratings { get; set; } = new List<int>();
		public double AverageRating { get { return Ratings.Count != 0 ? Ratings.Average() : 0; } }
		public Plant(string name, int ratity)
		{
			this.Name = name;
			this.Rarity = ratity;
		}
	}
}
