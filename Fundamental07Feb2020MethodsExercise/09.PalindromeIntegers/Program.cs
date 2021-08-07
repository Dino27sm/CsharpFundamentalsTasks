using System;
using System.Text;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = "";
            while((inpTxt = Console.ReadLine()) != "END")
            {
                if (CheckPalindromeIntegers(inpTxt)) Console.WriteLine("true");
                else Console.WriteLine("false");
            }
        }

        static bool CheckPalindromeIntegers(string inputTxt)
        {
            bool flag = true;
            for (int i = 0; i < inputTxt.Length / 2; i++)
            {
                if (inputTxt[i] != inputTxt[inputTxt.Length - 1 - i]) flag = false;
            }
            return flag;
        }
    }
}
