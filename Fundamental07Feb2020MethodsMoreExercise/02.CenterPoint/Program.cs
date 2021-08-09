using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintCenterPoint(x1, y1, x2, y2);
        }

        private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
        {
            double calcX1Y1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double calcX2Y2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
            if (calcX1Y1 <= calcX2Y2) Console.WriteLine($"({x1}, {y1})");
            else Console.WriteLine($"({x2}, {y2})");
        }
    }
}
