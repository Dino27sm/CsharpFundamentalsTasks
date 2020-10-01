using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                if (firstDeck[0] > secondDeck[0])
                {
                    int temp1 = firstDeck[0];
                    int temp2 = secondDeck[0];
                    firstDeck.Add(temp1);
                    firstDeck.Add(temp2);
                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                }
                else if(firstDeck[0] < secondDeck[0])
                {
                    int temp1 = secondDeck[0];
                    int temp2 = firstDeck[0];
                    secondDeck.Add(temp1);
                    secondDeck.Add(temp2);
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if (firstDeck[0] == secondDeck[0])
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }
            if (firstDeck.Count > 0 && secondDeck.Count <= 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
            else if (firstDeck.Count <= 0 && secondDeck.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
        }
    }
}
