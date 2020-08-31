using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerData = Console.ReadLine().Split().Select(int.Parse).ToList();
            double averageNum = (double)integerData.Sum();
            averageNum /= integerData.Count;
            List<int> selectedList = integerData.Where(x => x > averageNum)
                .OrderByDescending(x => x).ToList();
            selectedList = selectedList.Take(5).ToList();
            if(selectedList.Count > 0) Console.WriteLine(string.Join(" ", selectedList));
            else Console.WriteLine("No");
        }
    }
}
