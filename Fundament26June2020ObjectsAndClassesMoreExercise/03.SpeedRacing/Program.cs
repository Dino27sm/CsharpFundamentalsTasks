using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cars> carsList = new List<Cars>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] inpCars = Console.ReadLine().Split();
                string carModel = inpCars[0];
                double fuel = double.Parse(inpCars[1]);
                double fuelConsume = double.Parse(inpCars[2]);
                Cars carObject = new Cars(carModel, fuel, fuelConsume);
                carsList.Add(carObject);
            }
            string commands = "";
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] comandLine = commands.Split();
                string model = comandLine[1];
                double kilometers = double.Parse(comandLine[2]);
                Cars drivenCar = carsList.Find(x => x.CarModel == model);
                drivenCar.DriveCar(model, kilometers);
            }
            for (int m = 0; m < carsList.Count; m++)
            {
                Console.WriteLine($"{carsList[m].CarModel} {carsList[m].FuelAmount:F2} {carsList[m].TravelDistance}");
            }
        }
    }
    public class Cars
    {
        public string CarModel { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsuptionPerKm { get; set; }
        public double TravelDistance { get; set; }

        public Cars(string carModel, double fuelAmount, double fuelConsuption)
        {
            this.CarModel = carModel;
            this.FuelAmount = fuelAmount;
            this.FuelConsuptionPerKm = fuelConsuption;
            this.TravelDistance = 0;
        }

        public void DriveCar(string model, double drivenKm)
        {
            if (this.FuelAmount - this.FuelConsuptionPerKm * drivenKm >= 0)
            {
                this.FuelAmount -= this.FuelConsuptionPerKm * drivenKm;
                this.TravelDistance += drivenKm;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
