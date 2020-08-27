using System;
using System.Linq;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string getMessage = Console.ReadLine();
            string instruction = "";
            while((instruction = Console.ReadLine()) != "Decode")
            {
                string[] commandParts = instruction.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string majorCommand = commandParts[0];
                if(majorCommand == "Move")
                {
                    int numLetters = int.Parse(commandParts[1]);
                    if (numLetters >= 0 && numLetters <= getMessage.Length)
                    {
                        string tempFirst = getMessage.Substring(0, numLetters).ToString();
                        string tempTwo = getMessage.Remove(0, numLetters).ToString();
                        getMessage = string.Join("", tempTwo, tempFirst).ToString();
                    }
                }
                else if (majorCommand == "Insert")
                {
                    int indexInsert = int.Parse(commandParts[1]);
                    string valueInsert = commandParts[2];
                    if (indexInsert >= 0 && indexInsert <= getMessage.Length)
                    {
                        getMessage = getMessage.Insert(indexInsert, valueInsert).ToString();
                    }
                }
                else if (majorCommand == "ChangeAll")
                {
                    string textOne = commandParts[1];
                    string textTwo = commandParts[2];
                    if (getMessage.Contains(textOne))
                    {
                        getMessage = getMessage.Replace(textOne, textTwo).ToString();
                    }
                }
            }
            Console.WriteLine($"The decrypted message is: {getMessage}");
        }
    }
}
