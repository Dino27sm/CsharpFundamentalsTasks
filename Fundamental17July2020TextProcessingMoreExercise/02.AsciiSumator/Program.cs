using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstChar = Console.ReadLine().ToCharArray();
            char[] secondChar = Console.ReadLine().ToCharArray();
            string textLine = Console.ReadLine();
            if (firstChar[0] > secondChar[0])
            {
                char temp = firstChar[0];
                firstChar[0] = secondChar[0];
                secondChar[0] = temp;
            }
            int sumChar = 0;
            for (int i = 0; i < textLine.Length; i++)
            {
                if (textLine[i] > firstChar[0] && textLine[i] < secondChar[0])
                    sumChar += textLine[i];
            }
            Console.WriteLine(sumChar);
        }
    }
}
