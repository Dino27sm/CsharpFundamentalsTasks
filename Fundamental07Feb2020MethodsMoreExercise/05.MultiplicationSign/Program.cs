using System;
using System.Linq;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inpNum = new double[3];
            for (int i = 0; i < 3; i++)
            {
                inpNum[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(GetProductType(inpNum));
        }

        private static string GetProductType(double[] arr)
        {
            if(arr.Any(x => x == 0))
                return "zero";

            if(arr.Count(x => x < 0) == 1 || arr.Count(x => x < 0) == 3)
                return "negative";

            return "positive ";
        }
    }
}
