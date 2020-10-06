using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumLeft = 0;
            double sumRight = 0;
            List<double> numInp = Console.ReadLine().Split().Select(x => double.Parse(x)).ToList();
            if (numInp.Count % 2 == 1)
            {
                for (int i = 0; i < numInp.Count / 2; i++)
                {
                    sumLeft += numInp[i];
                    if (numInp[i] == 0) sumLeft *= 0.8;
                    sumRight += numInp[numInp.Count - 1 - i];
                    if (numInp[numInp.Count - 1 - i] == 0) sumRight *= 0.8;
                }
                if (sumLeft < sumRight) Console.WriteLine($"The winner is left with total time: {(decimal)sumLeft}");
                else if (sumRight < sumLeft) Console.WriteLine($"The winner is right with total time: {(decimal)sumRight}");
            }
        }
    }
}
