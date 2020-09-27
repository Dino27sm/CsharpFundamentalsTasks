using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%\.]*?<(?<product>\w+)>[^|$%\.]*?\|(?<items>\d+)\|[^|$%\.]*?(?<price>\d+\.?\d*)\${1}";
            Regex regInstance = new Regex(pattern);
            decimal totalIncome = 0;
            string inpText = "";
            while ((inpText = Console.ReadLine()) != "end of shift")
            {
                Match oneMatch = regInstance.Match(inpText);
                if (oneMatch.Success)
                {
                    string customerName = oneMatch.Groups["customer"].Value;
                    string productName = oneMatch.Groups["product"].Value;
                    long itemNum = long.Parse(oneMatch.Groups["items"].Value);
                    decimal priceRead = decimal.Parse(oneMatch.Groups["price"].Value);
                    decimal totalPrice = priceRead * itemNum;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:F2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
