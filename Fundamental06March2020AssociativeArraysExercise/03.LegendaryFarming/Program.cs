using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;
            SortedDictionary<string, int> junks = new SortedDictionary<string, int>();
            bool flag = true;
            string[] inpText = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (flag)
            {
                for (int i = 1; i < inpText.Length; i += 2)
                {
                    int materialValue = int.Parse(inpText[i - 1]);
                    string materialKey = inpText[i].ToLower();
                    switch (materialKey)
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                            materials[materialKey] += materialValue;
                            break;
                        default:
                            if (!junks.ContainsKey(materialKey)) junks.Add(materialKey, 0);
                            junks[materialKey] += materialValue;
                            break;
                    }
                    if (materials["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        materials["shards"] -= 250;
                        flag = false; break;
                    }
                    else if (materials["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        materials["fragments"] -= 250;
                        flag = false; break;
                    }
                    else if (materials["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        materials["motes"] -= 250;
                        flag = false; break;
                    }
                }
                if (!flag) break;
                inpText = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (var kvp in materials.OrderByDescending(x => x.Value).ThenBy(z => z.Key))
            {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvpJunk in junks)
            {
                Console.WriteLine($"{kvpJunk.Key}: {kvpJunk.Value}");
            }
        }
    }
}
