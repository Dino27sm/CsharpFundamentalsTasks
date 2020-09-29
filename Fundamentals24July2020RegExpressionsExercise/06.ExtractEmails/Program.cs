using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string mailPattern = @"(?<=\s|^)(?<user>[A-Za-z0-9]+([._-]?[A-Za-z0-9]+)+)\@{1}(?<host>([A-Za-z0-9]+[_.-]?[A-Za-z0-9]+)+\.([A-Za-z0-9]+[_.-]?[A-Za-z0-9]+)+)";
            string inpText = Console.ReadLine();
            MatchCollection mailAddresses = Regex.Matches(inpText, mailPattern);
            if(mailAddresses.Count > 0)
            {
                for (int i = 0; i < mailAddresses.Count; i++)
                {
                    string mailUser = mailAddresses[i].Groups["user"].Value;
                    string mailHost = mailAddresses[i].Groups["host"].Value;
                    Console.WriteLine($"{mailUser}@{mailHost}");
                }
            }
        }
    }
}
