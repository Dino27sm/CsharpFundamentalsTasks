using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arayNum = new int[3];
            for (int i = 0; i <= 2; i++)
            {
                arayNum[i] = int.Parse(Console.ReadLine());
            }
            int bufferNum;
            for (int i = 0; i <= 2; i++)
            {
                for (int k = i; k <= 2; k++)
                {
                    if (arayNum[i] < arayNum[k])
                    {
                        bufferNum = arayNum[k];
                        arayNum[k] = arayNum[i];
                        arayNum[i] = bufferNum;
                    }
                }
                Console.WriteLine(arayNum[i]);
            }
        }
    }
}
