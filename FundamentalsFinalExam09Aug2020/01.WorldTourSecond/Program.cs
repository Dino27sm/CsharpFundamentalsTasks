using System;

namespace _01.WorldTourSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            string textOperate = Console.ReadLine();
            string instructLine = "";
            while((instructLine = Console.ReadLine()) != "Travel")
            {
                string[] commandParts = instructLine.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string majorCommand = commandParts[0];
                if (majorCommand == "Add Stop")
                {
                    int indexAdd = int.Parse(commandParts[1]);
                    string insertText = commandParts[2];
                    if (indexAdd >= 0 && indexAdd < textOperate.Length)
                        textOperate = textOperate.Insert(indexAdd, insertText).ToString();
                }
                else if (majorCommand == "Remove Stop")
                {
                    int indexOne = int.Parse(commandParts[1]);
                    int indexTwo = int.Parse(commandParts[2]);
                    if (indexOne >= 0 && indexOne <= indexTwo && indexTwo < textOperate.Length)
                    {
                        int countDelete = indexTwo - indexOne + 1;
                        textOperate = textOperate.Remove(indexOne, countDelete).ToString();
                    }
                }
                else if (majorCommand == "Switch")
                {
                    string oldText = commandParts[1];
                    string newText = commandParts[2];
                    if (textOperate.Contains(oldText))
                         textOperate = textOperate.Replace(oldText, newText).ToString();
                }
                Console.WriteLine(textOperate);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {textOperate}");
        }
    }
}
