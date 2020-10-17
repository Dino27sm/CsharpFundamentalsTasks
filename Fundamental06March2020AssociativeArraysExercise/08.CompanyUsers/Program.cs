using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> firmInfo = new SortedDictionary<string, List<string>>();
            string inpText;
            while ((inpText = Console.ReadLine()) != "End")
            {
                string[] currentLine = inpText.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string companyName = currentLine[0];
                string employeeId = currentLine[1];

                if (!firmInfo.ContainsKey(companyName))
                {
                    firmInfo.Add(companyName, new List<string>());
                    firmInfo[companyName].Add(employeeId);
                }
                else
                {
                    if (!firmInfo[companyName].Contains(employeeId))
                    {
                        firmInfo[companyName].Add(employeeId);
                    }
                }
            }
            foreach (var kvp in firmInfo)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (string item in kvp.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
