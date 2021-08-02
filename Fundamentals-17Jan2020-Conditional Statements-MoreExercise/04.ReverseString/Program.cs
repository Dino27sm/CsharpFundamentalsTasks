using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = Console.ReadLine();
            int inpTxtLength = inpTxt.Length;
            for (int i = inpTxtLength - 1; i >= 0; i--)
            {
                Console.Write(inpTxt[i]);
            }
        }
    }
}
