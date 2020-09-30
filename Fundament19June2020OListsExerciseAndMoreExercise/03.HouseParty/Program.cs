using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestsList = new List<string>();
            int numEntries = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numEntries; i++)
            {
                List<string> infoLines = Console.ReadLine().Split().ToList();
                string name = infoLines[0];
                bool notGoing = infoLines[1] == "is" && infoLines[2] == "not";
                if (notGoing)
                {
                    if (guestsList.Contains(name)) guestsList.Remove(name);
                    else Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    if (!guestsList.Contains(name)) guestsList.Add(name);
                    else Console.WriteLine($"{name} is already in the list!");
                }
            }
            foreach (var guest in guestsList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
