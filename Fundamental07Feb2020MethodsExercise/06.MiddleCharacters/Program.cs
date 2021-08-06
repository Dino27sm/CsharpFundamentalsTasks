using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = Console.ReadLine();
            PrintMidChar(inpTxt);

        }
        static void PrintMidChar(string text)
        {
            int lengthText = text.Length;
            int halfLength = lengthText / 2;
            if (lengthText % 2 == 0) Console.WriteLine($"{text[halfLength - 1]}{text[halfLength]}");
            else Console.WriteLine($"{text[halfLength]}");
        }
    }
}
