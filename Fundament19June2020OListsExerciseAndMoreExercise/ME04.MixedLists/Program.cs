using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.MixedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            int[] borders = new int[2];
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            listTwo.Reverse();
            if (listOne.Count > listTwo.Count)
            {
                borders = listOne.TakeLast(2).OrderBy(x => x).ToArray();
                listOne.RemoveRange(listOne.Count - 2, 2);
            }
            else
            {
                borders = listTwo.TakeLast(2).OrderBy(x => x).ToArray();
                listTwo.RemoveRange(listTwo.Count - 2, 2);
            }
            for (int i = 0; i < listOne.Count; i++)
            {
                result.Add(listOne[i]);
                result.Add(listTwo[i]);
            }
            List<int> listToPrint = result.Where(x => x > borders[0] && x < borders[1])
                .OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(" ", listToPrint));
        }
    }
}
