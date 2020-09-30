using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inpList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> commandLine = Console.ReadLine().Split().ToList();
            while(commandLine[0] != "End")
            {
                switch (commandLine[0])
                {
                    case "Add":
                        int addNum = int.Parse(commandLine[1]);
                        inpList.Add(addNum);
                        break;
                    case "Insert":
                        int insertNum = int.Parse(commandLine[1]);
                        int insertIndex = int.Parse(commandLine[2]);
                        if (insertIndex < 0 || insertIndex >= inpList.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        inpList.Insert(insertIndex, insertNum);
                        break;
                    case "Remove":
                        int removeAtIndex = int.Parse(commandLine[1]);
                        if (removeAtIndex < 0 || removeAtIndex >= inpList.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        inpList.RemoveAt(removeAtIndex);
                        break;
                    case "Shift":
                        int numToShift = int.Parse(commandLine[2]);
                        if (commandLine[1] == "left")
                        {
                            inpList = ShiftToLeft(inpList, numToShift).ToList();
                        }
                        else if (commandLine[1] == "right")
                        {
                            inpList = ShiftToRight(inpList, numToShift).ToList();
                        }
                        break;
                }
                commandLine = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(string.Join(" ", inpList));
        }

        static List<int> ShiftToLeft(List<int> listName, int shiftNum)
        {
            List<int> outList = listName.ToList();
            shiftNum = shiftNum % outList.Count;
            for (int i = 0; i < shiftNum; i++)
            {
                int temp = outList[0];
                outList.RemoveAt(0);
                outList.Add(temp);
            }
            return outList;
        }

        static List<int> ShiftToRight(List<int> listName, int shiftNum)
        {
            List<int> outList = listName.ToList();
            shiftNum = shiftNum % outList.Count;
            for (int i = 0; i < shiftNum; i++)
            {
                int temp = outList[outList.Count - 1];
                outList.RemoveAt(outList.Count - 1);
                outList.Insert(0, temp);
            }
            return outList;
        }
    }
}
