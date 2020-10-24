using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userLanguagePoints = new Dictionary<string, Dictionary<string, int>>();
            SortedDictionary<string, int> languageNumUsers = new SortedDictionary<string, int>();
            string inpText = "";
            while((inpText = Console.ReadLine()) != "exam finished")
            {
                string[] commandLine = inpText.Split("-");
                string userName = commandLine[0];
                string languageName = commandLine[1];
                if (languageName != "banned")
                {
                    int pointsNum = int.Parse(commandLine[2]);
                    if (!userLanguagePoints.ContainsKey(userName))
                    {
                        userLanguagePoints.Add(userName, new Dictionary<string, int>());
                        userLanguagePoints[userName].Add(languageName, pointsNum);
                    }
                    else
                    {
                        if (!userLanguagePoints[userName].ContainsKey(languageName))
                            userLanguagePoints[userName][languageName] = pointsNum;
                        else
                        {
                            if (userLanguagePoints[userName][languageName] < pointsNum)
                                userLanguagePoints[userName][languageName] = pointsNum;
                        }
                    }
                    if (!languageNumUsers.ContainsKey(languageName))
                        languageNumUsers.Add(languageName, 1);
                    else languageNumUsers[languageName]++;
                }
                else
                {
                    if (userLanguagePoints.ContainsKey(userName))
                        userLanguagePoints.Remove(userName);
                }
            }
            Console.WriteLine("Results:");
            foreach (var kvp in userLanguagePoints.OrderByDescending(x => x.Value.Values.Max())
                .ThenBy(y => y.Key))
            {
                foreach (var item in kvp.Value.OrderByDescending(z => z.Value))
                    Console.WriteLine($"{kvp.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in languageNumUsers.OrderByDescending(x => x.Value))
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
    }
}
