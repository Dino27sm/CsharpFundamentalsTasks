using System;

namespace _01.SmallestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int minNum = SmollestOfThreeNum(firstNum, secondNum, thirdNum);
            Console.WriteLine(minNum);
        }
        static int SmollestOfThreeNum(int a, int b, int c)
        {
            int smollestNum = Math.Min(a, Math.Min(b, c));
            return smollestNum;
        }
    }
}
