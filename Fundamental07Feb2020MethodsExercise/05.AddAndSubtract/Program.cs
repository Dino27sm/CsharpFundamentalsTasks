using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int result = SubtractTwoNumb(SumTwoNum(num1, num2), num3);
            Console.WriteLine(result);
        }

        static int SumTwoNum(int addend1, int addend2)
        {
            return (addend1 + addend2);
        }

        static int SubtractTwoNumb(int deducted, int deductor)
        {
            return (deducted - deductor);
        }
    }
}
