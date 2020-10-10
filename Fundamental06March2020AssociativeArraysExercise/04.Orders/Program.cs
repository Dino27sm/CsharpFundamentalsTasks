using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            string[] inpText = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (inpText[0] != "buy")
            {
                string name = inpText[0];
                decimal price = decimal.Parse(inpText[1]);
                int quantity = int.Parse(inpText[2]);
                if (!productPrices.ContainsKey(name))
                {
                    productPrices.Add(name, price);
                    productQuantity.Add(name, quantity);
                }
                else
                {
                    productPrices[name] = price;
                    productQuantity[name] += quantity;
                }
                inpText = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            foreach (var item in productQuantity)
            {
                decimal totalPrice = item.Value * productPrices[item.Key];
                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
}
