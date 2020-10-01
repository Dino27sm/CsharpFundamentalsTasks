using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inpList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombInfo = Console.ReadLine().Split().Select(int.Parse).ToList();
            int listLength = inpList.Count;
            int counter = 0;
            while(counter < inpList.Count)
            {
                if (inpList[counter] == bombInfo[0])
                {
                    int leftIndex = 0;
                    int rightIndex = inpList.Count - 1;
                    if (counter - bombInfo[1] > 0) leftIndex = counter - bombInfo[1];
                    if (counter + bombInfo[1] < inpList.Count) rightIndex = counter + bombInfo[1];
                    int numToRemove = (rightIndex - leftIndex) + 1;
                    inpList.RemoveRange(leftIndex, numToRemove);
                    counter = 0;
                }
                else counter++;
            }
            Console.WriteLine(inpList.Sum());
        }
    }
}
