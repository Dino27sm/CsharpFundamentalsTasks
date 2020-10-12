using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingData = new Dictionary<string, string>();
            int numCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numCommands; i++)
            {
                string[] commandLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandLine[0];
                string name = commandLine[1];
                if (command == "register")
                {
                    string license = commandLine[2];
                    if (!parkingData.ContainsKey(name))
                    {
                        parkingData[name] = license;
                        Console.WriteLine($"{name} registered {license} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingData[name]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (parkingData.ContainsKey(name))
                    {
                        parkingData.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else Console.WriteLine($"ERROR: user {name} not found");
                }
            }
            foreach (var item in parkingData)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
