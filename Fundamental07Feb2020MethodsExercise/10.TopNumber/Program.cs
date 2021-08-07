using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int inpIntNum = int.Parse(Console.ReadLine());
            for (int i = 1; i <= inpIntNum; i++)
            {
                if (IsTopNumber(i)) Console.WriteLine(i);
            }
        }
        //-------------------------------------------------------------
        static bool IsTopNumber(int num)
        {
            bool oddDigit = false;
            int sumDigits = 0;
            while(num > 0)
            {
                int digit = num % 10;
                if (digit % 2 == 1) oddDigit = true;
                sumDigits += digit;
                num /= 10;
            }
            return (sumDigits % 8 == 0 && oddDigit);
        }
    }
}
