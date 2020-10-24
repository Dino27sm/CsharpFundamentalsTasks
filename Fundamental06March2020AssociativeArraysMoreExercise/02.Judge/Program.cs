using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestDictUserPoints
                = new Dictionary<string, Dictionary<string, int>>();
            string inpText = string.Empty;
            while ((inpText = Console.ReadLine()) != "no more time")
            {
                string[] commandData = inpText.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string userName = commandData[0];
                string contest = commandData[1];
                int contestPoints = int.Parse(commandData[2]);
                if (!contestDictUserPoints.ContainsKey(contest))
                {
                    contestDictUserPoints.Add(contest, new Dictionary<string, int>());
                    contestDictUserPoints[contest].Add(userName, contestPoints);
                }
                else
                {
                    if (!contestDictUserPoints[contest].ContainsKey(userName))
                        contestDictUserPoints[contest].Add(userName, contestPoints);
                    else
                    {
                        if (contestDictUserPoints[contest][userName] < contestPoints)
                            contestDictUserPoints[contest][userName] = contestPoints;
                    }
                }
            }
            Dictionary<string, int> userPointsDict = new Dictionary<string, int>();
            foreach (var kvp in contestDictUserPoints)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                int counter = 0;
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                    if (!userPointsDict.ContainsKey(item.Key))
                        userPointsDict.Add(item.Key, item.Value);
                    else userPointsDict[item.Key] += item.Value;
                }
            }
            int countUsers = 0;
            Console.WriteLine("Individual standings:");
            foreach (var kvp in userPointsDict.OrderByDescending(x => x.Value).ThenBy(z => z.Key))
            {
                countUsers++;
                Console.WriteLine($"{countUsers}. {kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
