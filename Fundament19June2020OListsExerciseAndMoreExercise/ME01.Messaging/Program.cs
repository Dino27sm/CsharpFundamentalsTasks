using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOut = new List<string>();
            List<int> numInp = Console.ReadLine().Split().Select(int.Parse).ToList();
            string inpTxt = Console.ReadLine();
            List<string> listInpTxt = new List<string>();
            for (int i = 0; i < inpTxt.Length; i++)
            {
                listInpTxt.Add(inpTxt[i].ToString());
            }
            for (int i = 0; i < numInp.Count; i++)
            {
                int sumDigits = 0;
                while (numInp[i] > 0)
                {
                    sumDigits += numInp[i] % 10;
                    numInp[i] /= 10;
                }
                sumDigits %= listInpTxt.Count;
                listOut.Add(listInpTxt[sumDigits]);
                listInpTxt.RemoveAt(sumDigits);
            }
            Console.WriteLine(string.Join("", listOut));
        }
    }
}
