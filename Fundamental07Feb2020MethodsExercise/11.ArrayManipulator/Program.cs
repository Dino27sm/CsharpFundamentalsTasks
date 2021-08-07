using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inpArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrLength = inpArr.Length;
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "exchange":
                        int index = int.Parse(command[1]);
                        if (index < 0 || index > (arrLength - 1)) Console.WriteLine("Invalid index");
                        else
                        {
                            inpArr = Exchange(inpArr, index); // write a Method "Exchange(string num)"
                        }
                        break;
                    case "max":
                        int maxIndex = MaxEvenOdd(inpArr, command[1]);
                        if (maxIndex == -1) Console.WriteLine("No matches");
                        else Console.WriteLine(maxIndex);
                        break;
                    case "min":
                        int minIndex = MinEvenOdd(inpArr, command[1]); // write a Method "MinEvenOdd(string text)"
                        if (minIndex == -1) Console.WriteLine("No matches");
                        else Console.WriteLine(minIndex);
                        break;
                    case "first":
                        int[] arrPrintFirst = InArrayCountEvenOdd(inpArr, command[2]);
                        int numToPrint = int.Parse(command[1]);
                        if (numToPrint < 0 || numToPrint > arrLength) Console.WriteLine("Invalid count");
                        else
                        {
                            List<int> printList = arrPrintFirst.ToList();
                            printList = printList.Take(numToPrint).ToList();
                            Console.Write($"[{string.Join(", ", printList)}]\n");
                        }
                        break;
                    case "last":
                        int[] arrPrintLast = InArrayCountEvenOdd(inpArr, command[2]);
                        int numPrint = int.Parse(command[1]);
                        if (numPrint < 0 || numPrint > arrLength) Console.WriteLine("Invalid count");
                        else
                        {
                            List<int> printListLast = arrPrintLast.ToList();
                            printListLast = printListLast.TakeLast(numPrint).ToList();
                            Console.Write($"[{string.Join(", ", printListLast)}]\n");
                        }
                        break;
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.Write($"[{string.Join(", ", inpArr)}]\n");
        }
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        private static int[] Exchange(int[] arrInt, int index)  // Method OK!
        {
            index += 1;
            int[] arrOut = arrInt[index..^0].Concat(arrInt[0..index]).ToArray();
            return arrOut;
        }
        //------------------------------------------------------------------------------
        private static int MaxEvenOdd(int[] arrInt, string evenOdd)
        {
            List<int> inpList = arrInt.ToList();
            int indexOut = -1;
            int indexMaxEven = -1;
            int indexMaxOdd = -1;
            if (!inpList.All(x => x % 2 != 0))
                indexMaxEven = inpList.FindLastIndex(x => x == inpList.Where(y => y % 2 == 0).Max());
            if (!inpList.All(x => x % 2 == 0))
                indexMaxOdd = inpList.FindLastIndex(x => x == inpList.Where(y => y % 2 == 1).Max());
            if (evenOdd == "even") indexOut = indexMaxEven;
            else if (evenOdd == "odd") indexOut = indexMaxOdd;
            return indexOut;
        }
        //----------------------------------------------------------------------
        private static int MinEvenOdd(int[] arrInt, string evenOdd)
        {
            List<int> inpList = arrInt.ToList();
            int indexOut = -1;
            int indexMinEven = -1;
            int indexMinOdd = -1;
            if (!inpList.All(x => x % 2 != 0))
                indexMinEven = inpList.FindLastIndex(x => x == inpList.Where(y => y % 2 == 0).Min());
            if (!inpList.All(x => x % 2 == 0))
                indexMinOdd = inpList.FindLastIndex(x => x == inpList.Where(y => y % 2 == 1).Min());
            if (evenOdd == "even") indexOut = indexMinEven;
            else if (evenOdd == "odd") indexOut = indexMinOdd;
            return indexOut;
        }
        //-----------------------------------------------------------------------------
        private static int[] InArrayCountEvenOdd(int[] arrInt, string evenOdd)
        {
            List<int> inpList = arrInt.ToList();
            List<int> resultList = arrInt.ToList();
            List<int> outListEven = new List<int>();
            List<int> outListOdd = new List<int>();
            outListEven = inpList.Where(x => x % 2 == 0).ToList();
            outListOdd = inpList.Where(x => x % 2 == 1).ToList();
            if (evenOdd == "even")
                resultList = outListEven.ToList();
            else if (evenOdd == "odd")
                resultList = outListOdd.ToList();
            return resultList.ToArray();
        }
    }
}
