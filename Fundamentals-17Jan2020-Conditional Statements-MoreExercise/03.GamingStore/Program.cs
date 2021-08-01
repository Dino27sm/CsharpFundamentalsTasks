using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyBuy = double.Parse(Console.ReadLine());
            double moneySpend = 0;
            double moneyRemain = moneyBuy;
            string gameName = string.Empty;

            while ((gameName = Console.ReadLine()) != "Game Time")
            {
                switch (gameName)
                {
                    case "OutFall 4": moneySpend = 39.99; break;
                    case "CS: OG": moneySpend = 15.99; break;
                    case "Zplinter Zell": moneySpend = 19.99; break;
                    case "Honored 2": moneySpend = 59.99; break;
                    case "RoverWatch": moneySpend = 29.99; break;
                    case "RoverWatch Origins Edition": moneySpend = 39.99; break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
                if ((moneyRemain - moneySpend) == 0)
                {
                    Console.WriteLine($"Bought {gameName}");
                    Console.WriteLine("Out of money!");
                    return;
                }
                else if ((moneyRemain - moneySpend) < 0)
                {
                    Console.WriteLine("Too Expensive");
                    moneySpend = 0;
                }
                else if ((moneyRemain - moneySpend) > 0)
                {
                    Console.WriteLine($"Bought {gameName}");
                    moneyRemain -= moneySpend;
                }
            }
            Console.WriteLine($"Total spent: ${moneyBuy - moneyRemain:F2}. Remaining: ${moneyRemain:F2}");
        }
    }
}
