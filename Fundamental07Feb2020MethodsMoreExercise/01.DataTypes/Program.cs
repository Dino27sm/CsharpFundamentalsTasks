using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = Console.ReadLine();
            switch (inpTxt)
            {
                case "int":
                    int intData = int.Parse(Console.ReadLine());
                    Console.WriteLine(MultiplayKoeficient(intData));
                    break;
                case "real":
                    double doubleData = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", MultiplayKoeficient(doubleData));
                    break;
                case "string":
                    string strData = Console.ReadLine();
                    Console.WriteLine(MultiplayKoeficient(strData));
                    break;
            }

        }

        static int MultiplayKoeficient(int num)
        {
            return (num * 2);
        }

        static double MultiplayKoeficient(double num)
        {
            return (num * 1.5);
        }

        static string MultiplayKoeficient(string num)
        {
            string txtOut = "$" + num + "$";
            return (txtOut);
        }
    }
}
