using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cars> carsList = new List<Cars>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] inpLines = Console.ReadLine().Split();
                string carType = inpLines[0];
                int speed = int.Parse(inpLines[1]);
                int power = int.Parse(inpLines[2]);
                int weight = int.Parse(inpLines[3]);
                string cargoType = inpLines[4];
                Engine engineObject = new Engine(speed, power);
                Cargo cargoOblect = new Cargo(weight, cargoType);
                Cars carObject = new Cars(carType, engineObject, cargoOblect);
                carsList.Add(carObject);
            }
            string lastLine = Console.ReadLine();
            if (lastLine == "fragile")
            {
                foreach (var item in carsList.Where(x => x.CargoData.CargoWeight < 1000))
                    Console.WriteLine($"{item.CarModel}");
            }
            else if (lastLine == "flamable")
            {
                foreach (var item in carsList.Where(x => x.EngineData.EnginePower > 250))
                    Console.WriteLine($"{item.CarModel}");
            }
        }
    }
    public class Cars
    {
        public string CarModel { get; set; }
        public Engine EngineData { get; set; }
        public Cargo CargoData { get; set; }
        public Cars(string carModel, Engine engineInfo, Cargo cargoInfo)
        {
            this.CarModel = carModel;
            this.EngineData = engineInfo;
            this.CargoData = cargoInfo;
        }
    }
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
    }
    public class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
    }
}
