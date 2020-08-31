using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> integerData = Console.ReadLine().Split().Select(long.Parse).ToList();
            string instructText = "";
            while ((instructText = Console.ReadLine()) != "end")
            {
                string[] instructions = instructText.Split();
                string command = instructions[0];
                if (command == "swap")
                {
                    int indexOne = int.Parse(instructions[1]);
                    int indexTwo = int.Parse(instructions[2]);
                    if (indexOne >= 0 && indexOne < integerData
                        .Count && indexTwo >= 0 && indexTwo < integerData.Count)
                    {
                        long temp = integerData[indexOne];
                        integerData[indexOne] = integerData[indexTwo];
                        integerData[indexTwo] = temp;
                    }
                }
                else if (command == "multiply")
                {
                    int indexOneMult = int.Parse(instructions[1]);
                    int indexTwoMult = int.Parse(instructions[2]);
                    if (indexOneMult >= 0 && indexOneMult < integerData
                        .Count && indexTwoMult >= 0 && indexTwoMult < integerData.Count)
                    {
                        integerData[indexOneMult] *= integerData[indexTwoMult];
                    }
                }
                else if (command == "decrease")
                {
                    integerData = integerData.Select(x => x - 1).ToList();
                }
            }
            Console.WriteLine(string.Join(", ", integerData));
        }
    }
}
