using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MessagesM1
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
                PhoneKey pressedKey = new PhoneKey(keyNum);
                outTxt += pressedKey.KeySymbols[inpTxt.Length - 1];
            }
             Console.WriteLine(outTxt);
        }
    }
    class PhoneKey
    {
        public PhoneKey(int keyNum)
        {
            this.KeyNumber = keyNum;
        }
        public int KeyNumber { get; set; }
        public string KeySymbols 
        {
            get
            {
                if (KeyNumber == 2) return "abc";
                else if (KeyNumber == 3) return "def";
                else if (KeyNumber == 4) return "ghi";
                else if (KeyNumber == 5) return "jkl";
                else if (KeyNumber == 6) return "mno";
                else if (KeyNumber == 7) return "pqrs";
                else if (KeyNumber == 8) return "tuv";
                else if (KeyNumber == 9) return "wxyz";
                else if (KeyNumber == 0) return " ";
                else return "";
            }
        }
    }
}
