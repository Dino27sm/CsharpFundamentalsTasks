using System;
using System.Linq;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string textOperate = Console.ReadLine();
            string instruction = "";
            while((instruction = Console.ReadLine()) != "Travel")
            {
                string[] commandParts = instruction.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string majorCommand = commandParts[0];
                if (majorCommand == "Add Stop")
                {
                    int indexAdd = int.Parse(commandParts[1]);
                    string addString = commandParts[2];
                    if (indexAdd >= 0 && indexAdd < textOperate.Length)
                    {
                        textOperate = textOperate.Insert(indexAdd, addString).ToString();
                    }
                    Console.WriteLine(textOperate);
                }
                else if (majorCommand == "Remove Stop")
                {
                    int indexOne = int.Parse(commandParts[1]);
                    int indexTwo = int.Parse(commandParts[2]);
                    
                    if(indexOne >= 0 && indexOne <= indexTwo && indexTwo < textOperate.Length)
                    {
                        int countNum = indexTwo - indexOne + 1;
                        textOperate = textOperate.Remove(indexOne, countNum).ToString();
                    }
                    Console.WriteLine(textOperate);
                }
                else if (majorCommand == "Switch")
                {
                    string oldString = commandParts[1];
                    string newString = commandParts[2];
                    if (textOperate.IndexOf(oldString) >= 0)
                    {
                        textOperate = textOperate.Replace(oldString, newString).ToString();
                    }
                    Console.WriteLine(textOperate);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {textOperate}");
        }
    }
}
