using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inpNum = new double[8];

            for (int i = 0; i < 8; i++)
            {
                inpNum[i] = double.Parse(Console.ReadLine());
            }

            double[] firstTwoXY = inpNum.Take(4).ToArray();
            double[] secondTwoXY = inpNum.TakeLast(4).ToArray();

            firstTwoXY = GetClosestPoint(firstTwoXY).ToArray();
            secondTwoXY = GetClosestPoint(secondTwoXY).ToArray();

            double firsLineLength = GetLineLength(firstTwoXY);
            double secondLineLength = GetLineLength(secondTwoXY);

            string printOut = string.Empty;
            if (firsLineLength >= secondLineLength)
                printOut = $"({firstTwoXY[0]}, {firstTwoXY[1]})({firstTwoXY[2]}, {firstTwoXY[3]})";
            else
                printOut = $"({secondTwoXY[0]}, {secondTwoXY[1]})({secondTwoXY[2]}, {secondTwoXY[3]})";

            Console.WriteLine(printOut);
        }

        private static double[] GetClosestPoint(double[] arr)
        {
            double x1 = arr[0]; double y1 = arr[1]; 
            double x2 = arr[2]; double y2 = arr[3];

            double[] result = { x2, y2, x1, y1};
            double calcX1Y1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double calcX2Y2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
            if (calcX1Y1 <= calcX2Y2)
            {
                result[0] = x1; result[1] = y1;
                result[2] = x2; result[3] = y2;

            }
            return result;
        }

        private static double GetLineLength(double[] arr)
        {
            double calcLength = Math.Pow((arr[0] - arr[2]), 2) + Math.Pow((arr[1] - arr[3]), 2);
            return Math.Sqrt(calcLength);
        }
    }
}
