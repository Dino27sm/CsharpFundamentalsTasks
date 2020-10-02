using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inpList = Console.ReadLine()
                .Split('|').ToList();
            for (int i = 0; i < inpList.Count / 2; i++)
            {
                string temp = inpList[i];
                inpList[i] = inpList[inpList.Count - 1 - i];
                inpList[inpList.Count - 1 - i] = temp;
            }
            string txtOut = string.Join(" ", inpList);
            string[] txtPrint = txtOut.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Console.WriteLine(string.Join(" ", txtPrint));
        }
    }
}
