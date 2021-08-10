using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> tribonacciSequence = new List<int>() { 1};

            while (tribonacciSequence.Count < num)
            {
                tribonacciSequence.Add(tribonacciSequence.TakeLast(3).Sum());
            }
            Console.WriteLine(string.Join(" ", tribonacciSequence));
        }
    }
}
