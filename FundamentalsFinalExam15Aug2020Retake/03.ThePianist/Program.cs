using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Composers> musicData = new Dictionary<string, Composers>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] readInfo = Console.ReadLine().Split("|");
                string pieceName = readInfo[0];
                string composerName = readInfo[1];
                string keyName = readInfo[2];
                if (!musicData.ContainsKey(pieceName))
                    musicData.Add(pieceName, new Composers(composerName, keyName));
            }
            string instruction = "";
            while((instruction = Console.ReadLine()) != "Stop")
            {
                string[] commandParts = instruction.Split("|");
                string majorCommand = commandParts[0];
                if (majorCommand == "Add")
                {
                    string getPiece = commandParts[1];
                    string getComposer = commandParts[2];
                    string getKey = commandParts[3];
                    if (!musicData.ContainsKey(getPiece))
                    {
                        musicData.Add(getPiece, new Composers(getComposer, getKey));
                        Console.WriteLine($"{getPiece} by {getComposer} in {getKey} added to the collection!");
                    }
                    else
                        Console.WriteLine($"{getPiece} is already in the collection!");
                }
                else if (majorCommand == "Remove")
                {
                    string pieceRemove = commandParts[1];
                    if (musicData.ContainsKey(pieceRemove))
                    {
                        musicData.Remove(pieceRemove);
                        Console.WriteLine($"Successfully removed {pieceRemove}!");
                    }
                    else
                        Console.WriteLine($"Invalid operation! {pieceRemove} does not exist in the collection.");
                }
                else if (majorCommand == "ChangeKey")
                {
                    string pieceChange = commandParts[1];
                    string keyChange = commandParts[2];
                    if (musicData.ContainsKey(pieceChange))
                    {
                        musicData[pieceChange].KeyType = keyChange;
                        Console.WriteLine($"Changed the key of {pieceChange} to {keyChange}!");
                    }
                    else
                        Console.WriteLine($"Invalid operation! {pieceChange} does not exist in the collection.");
                }
            }
            foreach (var kvp in musicData.OrderBy(x => x.Key).ThenBy(y => y.Value.NameComposer))
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.NameComposer}, Key: {kvp.Value.KeyType}");
            }
        }
    }
    public class Composers
    {
        public string NameComposer { get; set; }
        public string KeyType { get; set; }
        public Composers(string nameComposer, string keyType)
        {
            this.NameComposer = nameComposer;
            this.KeyType = keyType;
        }
    }
}
