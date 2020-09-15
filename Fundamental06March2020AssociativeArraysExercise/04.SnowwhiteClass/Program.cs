using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.SnowwhiteClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarft> dwarftDataList = new List<Dwarft>();
            string inpText = "";
            while ((inpText = Console.ReadLine()) != "Once upon a time")
            {
                string[] infoLine = inpText.Split(" <:> ");
                string name = infoLine[0];
                string colour = infoLine[1];
                int physics = int.Parse(infoLine[2]);
                Dwarft dwarftObject = new Dwarft(name, colour, physics);
                if (dwarftDataList.Exists(x => x.DwarftName == name && x.DwarftColour == colour))
                {
                    Dwarft temp = dwarftDataList.Find(x => x.DwarftName == name && x.DwarftColour == colour);
                    temp.DwarftPhysics = Math.Max(temp.DwarftPhysics, physics);
                }
                else dwarftDataList.Add(dwarftObject);
            }
            foreach (var item in dwarftDataList.OrderByDescending(x => x.DwarftPhysics)
                .ThenByDescending(y => dwarftDataList.Count(z => z.DwarftColour == y.DwarftColour)))
            {
                Console.WriteLine($"({item.DwarftColour}) {item.DwarftName} <-> {item.DwarftPhysics}");
            }
        }
    }

    public class Dwarft
    {
        public string DwarftName { get; set; }
        public string DwarftColour { get; set; }
        public int DwarftPhysics { get; set; }

        public Dwarft(string name, string colour, int physics)
        {
            this.DwarftName = name;
            this.DwarftColour = colour;
            this.DwarftPhysics = physics;
        }
    }
}
