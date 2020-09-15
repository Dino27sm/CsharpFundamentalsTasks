using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, int>> playerData = new Dictionary<string, SortedDictionary<string, int>>();
            string inpText = "";
            while((inpText = Console.ReadLine()) != "Season end")
            {
                string[] decodeLine = inpText
                    .Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (decodeLine.Length == 3)
                {
                    string player = decodeLine[0];
                    string position = decodeLine[1];
                    int skill = int.Parse(decodeLine[2]);
                    if (!playerData.ContainsKey(player))
                    {
                        playerData.Add(player, new SortedDictionary<string, int>());
                        playerData[player].Add(position, skill);
                    }
                    else
                    {
                        if (!playerData[player].ContainsKey(position))
                            playerData[player].Add(position, skill);
                        else
                        {
                            if (playerData[player][position] < skill)
                                playerData[player][position] = skill;
                        }
                    }
                }
                else if (decodeLine.Length == 2)
                {
                    string playerOne = decodeLine[0];
                    string playerTwo = decodeLine[1];
                    if (playerData.ContainsKey(playerOne) && playerData.ContainsKey(playerTwo))
                    {
                        bool flag = false;
                        foreach (var itemOne in playerData[playerOne])
                        {
                            foreach (var itemTwo in playerData[playerTwo])
                            {
                                if (itemOne.Key == itemTwo.Key)
                                {
                                    if (playerData[playerOne].Values.Sum() > playerData[playerTwo].Values.Sum())
                                        playerData.Remove(playerTwo);
                                    else if (playerData[playerOne].Values.Sum() < playerData[playerTwo].Values.Sum())
                                        playerData.Remove(playerOne);
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag) break;
                        }
                    }
                }
            }
            foreach (var kvp in playerData
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");
                foreach (var item in kvp.Value.OrderByDescending(z => z.Value))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
