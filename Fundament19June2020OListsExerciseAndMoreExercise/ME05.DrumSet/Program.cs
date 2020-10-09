using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());
            List<int> drumInitialState = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> drumCurrentState = drumInitialState.ToList();
            string inpText;
            while ((inpText = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(inpText);
                for (int i = 0; i < drumCurrentState.Count; i++)
                {
                    if (drumCurrentState[i] - hitPower > 0) drumCurrentState[i] -= hitPower;
                    else
                    {
                        if(savings - drumInitialState[i] * 3 >= 0)
                        {
                            savings -= drumInitialState[i] * 3;
                            drumCurrentState[i] = drumInitialState[i];
                        }
                        else
                        {
                            drumCurrentState.RemoveAt(i);
                            drumInitialState.RemoveAt(i--);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumCurrentState));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
