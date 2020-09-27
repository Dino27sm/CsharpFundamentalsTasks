using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbolsWin = {"@@@@@@", "######", "$$$$$$", "^^^^^^"};
            List<string> inpText = Console.ReadLine()
                .Split(new string[] { ", ", " , ", ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            for (int i = 0; i < inpText.Count; i++)
            {
                if (inpText[i].Length == 20)
                {
                    string leftHalfe = inpText[i].Substring(0, 10);
                    string rightHalfe = inpText[i].Substring(10, 10);
                    bool checkMatch = false;
                    for (int k = 0; k < symbolsWin.Length; k++)
                    {
                        if (leftHalfe.Contains(symbolsWin[k]) && rightHalfe.Contains(symbolsWin[k]))
                        {
                            int diffLeftIndexes = leftHalfe.LastIndexOf(symbolsWin[k]) - leftHalfe.IndexOf(symbolsWin[k]);
                            int diffRightIndexes = rightHalfe.LastIndexOf(symbolsWin[k]) - rightHalfe.IndexOf(symbolsWin[k]);
                            int minLingth = Math.Min(diffLeftIndexes, diffRightIndexes);
                            int matchLength = minLingth + symbolsWin[k].Length;
                            if (matchLength == 10)
                            {
                                Console.WriteLine($"ticket \"{inpText[i]}\" - {matchLength}{symbolsWin[k][0]} Jackpot!");
                                checkMatch = true;
                                break;
                            }
                            Console.WriteLine($"ticket \"{inpText[i]}\" - {matchLength}{symbolsWin[k][0]}");
                            checkMatch = true;
                            break;
                        }
                    }
                    if (checkMatch == false) Console.WriteLine($"ticket \"{inpText[i]}\" - no match");
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
            }
        }
    }
}
