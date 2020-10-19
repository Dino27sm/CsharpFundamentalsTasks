using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се реши с две Dictionary
            Dictionary<string, List<string>> sidesInfo = new Dictionary<string, List<string>>();
            string inpText;
            while ((inpText = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] currentLine = inpText.Split(new string[] {" | ", " -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string actionType = "->";
                string sideName = currentLine[1];
                string userName = currentLine[0];
                if (inpText.Contains('|'))
                {
                    actionType = "|";
                    sideName = currentLine[0];
                    userName = currentLine[1];
                }
                if (actionType == "|")
                {
                    bool flagUser = false;
                    foreach (var kvp in sidesInfo)
                        foreach (var item in kvp.Value)
                            if (item == userName)
                                flagUser = true;
                    if (!flagUser && !sidesInfo.ContainsKey(sideName))
                    {
                        sidesInfo.Add(sideName, new List<string>());
                        sidesInfo[sideName].Add(userName);
                    }
                    else if (!flagUser) sidesInfo[sideName].Add(userName);
                }
                else if (actionType == "->")
                {
                    string delUserKvp = "";
                    bool flagUser = false;
                    foreach (var kvp in sidesInfo)
                        foreach (var item in kvp.Value)
                            if (item == userName)
                            {
                                flagUser = true;
                                delUserKvp = kvp.Key;
                            }
                    if (flagUser)
                    {
                        if (delUserKvp != sideName)
                        {
                            sidesInfo[delUserKvp].Remove(userName);
                            if (sidesInfo.ContainsKey(sideName))
                            {
                                sidesInfo[sideName].Add(userName);
                                Console.WriteLine($"{userName} joins the {sideName} side!");
                            }
                            else
                            {
                                sidesInfo.Add(sideName, new List<string>());
                                sidesInfo[sideName].Add(userName);
                                Console.WriteLine($"{userName} joins the {sideName} side!");
                            }
                        }
                    }
                    else
                    {
                        if (sidesInfo.ContainsKey(sideName))
                        {
                            sidesInfo[sideName].Add(userName);
                            Console.WriteLine($"{userName} joins the {sideName} side!");
                        }
                        else
                        {
                            sidesInfo.Add(sideName, new List<string>());
                            sidesInfo[sideName].Add(userName);
                            Console.WriteLine($"{userName} joins the {sideName} side!");
                        }
                    }
                }
            }
            foreach (var item in sidesInfo.Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var element in item.Value.OrderBy(z => z))
                {
                    Console.WriteLine($"! {element}");
                }
            }
        }
    }
}
