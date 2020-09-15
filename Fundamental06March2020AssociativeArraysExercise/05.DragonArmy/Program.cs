using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragons>> dragonData = new Dictionary<string, List<Dragons>>();
            int numDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numDragons; i++)
            {
                string[] inpLine = Console.ReadLine().Split();
                string typeDrag = inpLine[0];
                string nameDrag = inpLine[1];
                int damageDrag = 45;
                if (inpLine[2] != "null") damageDrag = int.Parse(inpLine[2]);
                int healthDrag = 250;
                if (inpLine[3] != "null") healthDrag = int.Parse(inpLine[3]);
                int armorDrag = 10;
                if (inpLine[4] != "null") armorDrag = int.Parse(inpLine[4]);
                Dragons dragonObject = new Dragons(nameDrag, damageDrag, healthDrag, armorDrag);
                if (!dragonData.ContainsKey(typeDrag))
                {
                    dragonData.Add(typeDrag, new List<Dragons>());
                    dragonData[typeDrag].Add(dragonObject);
                }
                else
                {
                    if(!dragonData[typeDrag].Exists(x => x.DragonName == nameDrag))
                    {
                        dragonData[typeDrag].Add(dragonObject);
                    }
                    else
                    {
                        int indexDrag = dragonData[typeDrag].FindIndex(x => x.DragonName == nameDrag);
                        dragonData[typeDrag][indexDrag] = dragonObject;
                    }
                }
            }
            foreach (var kvp in dragonData)
            {
                double damageAverage = 1.0 * kvp.Value.Sum(x => x.DragonDamage) / kvp.Value.Count;
                double healtAverage = 1.0 * kvp.Value.Sum(x => x.DragonHealth) / kvp.Value.Count;
                double armorAverage = 1.0 * kvp.Value.Sum(x => x.DragonArmor) / kvp.Value.Count;
                Console.WriteLine($"{kvp.Key}::({damageAverage:F2}/{healtAverage:F2}/{armorAverage:F2})");
                foreach (var item in kvp.Value.OrderBy(z => z.DragonName))
                {
                    Console.WriteLine($"-{item.DragonName} -> damage: {item.DragonDamage}, health: {item.DragonHealth}, armor: {item.DragonArmor}");
                }
            }
        }
    }

    public class Dragons
    {
        public string DragonName { get; set; }
        public int DragonDamage { get; set; }
        public int DragonHealth { get; set; }
        public int DragonArmor { get; set; }

        public Dragons(string name, int damage, int health, int armor)
        {
            this.DragonName = name;
            this.DragonDamage = damage;
            this.DragonHealth = health;
            this.DragonArmor = armor;
        }
    }
}
