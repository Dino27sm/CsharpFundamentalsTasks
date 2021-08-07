using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"{1.0 * NumFactorial(firstNum) / NumFactorial(secondNum):F2}");
        }
        
        static long NumFactorial(int num)
        {
            long resultOut = 1L;
            if (num > 0)
            {
                for (int i = 1; i <= num; i++) resultOut *= i;
            }
            else resultOut = 1L;
            return resultOut;
        }
    }
}
