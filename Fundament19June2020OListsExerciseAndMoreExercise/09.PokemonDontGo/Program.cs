using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexRem;
            long sumRemovedElements = 0;
            List<int> inpNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (inpNumbers.Count > 0)
            {
                int removedElement = 0;
                indexRem = int.Parse(Console.ReadLine());
                if (indexRem < 0)
                {
                    removedElement = inpNumbers[0];
                    inpNumbers[0] = inpNumbers[inpNumbers.Count - 1];
                }
                else if (indexRem >= inpNumbers.Count)
                {
                    removedElement = inpNumbers[inpNumbers.Count - 1];
                    inpNumbers[inpNumbers.Count - 1] = inpNumbers[0];
                }
                else
                {
                    removedElement = inpNumbers[indexRem];
                    inpNumbers.RemoveAt(indexRem);
                }
                for (int i = 0; i < inpNumbers.Count; i++)
                {
                    if (inpNumbers[i] <= removedElement) inpNumbers[i] += removedElement;
                    else inpNumbers[i] -= removedElement;
                }
                sumRemovedElements += removedElement;
            }
            Console.WriteLine(sumRemovedElements);
        }
    }
}
