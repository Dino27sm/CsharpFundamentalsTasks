using System;

namespace _03.CharactersRange
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbolOne = Console.ReadLine();
            string symbolTwo = Console.ReadLine();
            CharInRange(symbolOne[0], symbolTwo[0]);
        }

        static void CharInRange(char firstChar, char secondCHar)
        {
            for (int i = Math.Min(firstChar, secondCHar) + 1; i < Math.Max(firstChar, secondCHar); i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
