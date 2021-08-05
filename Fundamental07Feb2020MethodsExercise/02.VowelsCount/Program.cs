using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = Console.ReadLine();
                //string inpTxt2 = Console.ReadLine().ToLower();    //Converts all big char to small
            Console.WriteLine(VowelsCount(inpTxt));
        }
        static int VowelsCount(string text)
        {
            int sumVowels = 0;
            int txtLength = text.Length;
            for (int i = 0; i < txtLength; i++)
            {
                switch (text[i])
                {
                    case 'A':
                    case 'a':
                    case 'E':
                    case 'e':
                    case 'I':
                    case 'i':
                    case 'O':
                    case 'o':
                    case 'U':
                    case 'u':
                        sumVowels++;
                        break;
                }
            }
            return sumVowels;
        }
    }
}
