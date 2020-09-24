using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder buildWords = new StringBuilder();
            List<string> wordsOut = new List<string>();
            List<string> morseTab = new List<string>()
                {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..",
                 "--", "-.","---", ".--.", "--.-", ".-.","...", "-", "..-", "...-",".--", "-..-", "-.--", "--.." };
            string[] inpWords = Console.ReadLine().Split("|");
            for (int i = 0; i < inpWords.Length; i++)
            {
                string[] oneWord = inpWords[i].Split(new string[] {" ", "  " }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < oneWord.Length; k++)
                {
                    int indexChar = morseTab.IndexOf(oneWord[k]);
                    char oneChar = (char)(65 + indexChar);
                    buildWords.Append(oneChar);
                }
                string saveWord = buildWords.ToString();
                wordsOut.Add(saveWord);
                buildWords.Clear();
            }
            Console.WriteLine(string.Join(" ", wordsOut));
        }
    }
}
