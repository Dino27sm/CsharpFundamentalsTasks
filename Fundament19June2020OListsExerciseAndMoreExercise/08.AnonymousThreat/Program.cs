using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inpString = Console.ReadLine().Split().ToList();
            List<string> commandLine = Console.ReadLine().Split().ToList();

            while (commandLine[0] != "3:1")
            {
                if (commandLine[0] == "merge")
                {
                    int indexOne = int.Parse(commandLine[1]);
                    int indexTwo = int.Parse(commandLine[2]);
                    if (indexTwo >= inpString.Count) indexTwo = inpString.Count - 1;
                    if (indexOne < 0) indexOne = 0;
                    else if (indexOne >= inpString.Count) indexOne = inpString.Count - 1;
                    for (int i = indexOne + 1; i <= indexTwo; i++)
                    {
                        inpString[indexOne] += inpString[i];
                    }
                    inpString.RemoveRange(indexOne + 1, (indexTwo - indexOne));
                }
                else if (commandLine[0] == "divide")
                {
                    int indexDiv = int.Parse(commandLine[1]);
                    int numParts = int.Parse(commandLine[2]);
                    string temp = inpString[indexDiv];
                    inpString.RemoveAt(indexDiv);
                    foreach (var item in StringSplitInPortions(temp, numParts))
                    {
                        inpString.Insert(indexDiv++, item);
                    }
                }
                commandLine = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(string.Join(" ", inpString));
        }

        static List<string> StringSplitInPortions(string inpText, int numParts)
        {
            List<string> listOut = new List<string>();
            List<string> inSymbols = new List<string>();
            foreach (var item in inpText)
            {
                inSymbols.Add(item.ToString());
            }
            int inSymolsLength = inSymbols.Count;
            if (numParts <= 0) numParts = 1;
            int numInPart = inSymolsLength / numParts;
            int countSplit = 1;
            while (inSymbols.Count > 0)
            {
                if (countSplit == numInPart || inSymbols.Count == 1)
                {
                    listOut.Add(inSymbols[0]);
                    inSymbols.RemoveAt(0);
                    countSplit = 1;
                }
                else
                {
                    inSymbols[0] += inSymbols[1];
                    inSymbols.RemoveAt(1);
                    countSplit++;
                }
            }
            if (listOut.Count % numParts != 0 && listOut.Count > numParts && listOut.Count > 1)
            {
                int countAdd = listOut.Count - numParts;
                int addAtIndex = listOut.Count - 1 - countAdd;
                for (int i = 1; i <= countAdd; i++)
                {
                    listOut[addAtIndex] += listOut[addAtIndex + 1];
                    listOut.RemoveAt(addAtIndex + 1);
                }
            }
            return listOut;
        }
    }
}
