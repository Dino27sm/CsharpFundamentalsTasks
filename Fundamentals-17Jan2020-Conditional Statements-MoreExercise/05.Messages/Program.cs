using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string outTxt = "";
            int massageLeng = int.Parse(Console.ReadLine());
            for (int i = 1; i <= massageLeng; i++)
            {
                string inpNums = Console.ReadLine();
                int strLength = inpNums.Length;
                int numValue = int.Parse(inpNums[0].ToString());
                if (numValue != 0)
                {
                    int offcet = (numValue - 2) * 3;
                    if (numValue == 8 || numValue == 9) offcet++;
                    int symbolIndex = offcet + strLength - 1;
                    outTxt += (char)(97 + symbolIndex);
                }
                else outTxt += (char)32;
            }
            Console.WriteLine(outTxt);
        }
    }
}
