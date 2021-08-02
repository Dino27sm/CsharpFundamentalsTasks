using System;

namespace _05.MessagesM2
{
    class Program
    {
        static void Main(string[] args)
        {
            string outTxt = "";
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string inpTxt = Console.ReadLine();
                int keyNum = int.Parse(inpTxt[0].ToString());
                outTxt += PhoneKeySymbol(keyNum, inpTxt.Length);
            }
            Console.WriteLine(outTxt);
        }

        static char PhoneKeySymbol(int keyNum, int timesPressed)
        {
            string outSymbol = "";
            if (keyNum == 2) outSymbol = "abc";
            else if (keyNum == 3) outSymbol = "def";
            else if (keyNum == 4) outSymbol = "ghi";
            else if (keyNum == 5) outSymbol = "jkl";
            else if (keyNum == 6) outSymbol = "mno";
            else if (keyNum == 7) outSymbol = "pqrs";
            else if (keyNum == 8) outSymbol = "tuv";
            else if (keyNum == 9) outSymbol = "wxyz";
            else if (keyNum == 0) outSymbol = " ";
            return outSymbol[timesPressed - 1];
        }
    }
}
