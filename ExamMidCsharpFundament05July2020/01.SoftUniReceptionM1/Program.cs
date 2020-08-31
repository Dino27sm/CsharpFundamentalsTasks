using System;

namespace _01.SoftUniReceptionM1
{
    class Program
    {
        static void Main(string[] args)
        {
            int employOne = int.Parse(Console.ReadLine());
            int employTwo = int.Parse(Console.ReadLine());
            int employThree = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int allCapacity = employOne + employTwo + employThree;
            int totalHours = 0;
            int hoursToRest = 0;
            if (students == 0)
            {
                Console.WriteLine("Time needed: 0h.");
                return;
            }
            if (students % allCapacity == 0)
            {
                int hoursToServe = students / allCapacity;
                if (hoursToServe % 3 == 0)
                    hoursToRest = hoursToServe / 3 - 1;
                else hoursToRest = hoursToServe / 3;
                totalHours = hoursToServe + hoursToRest;
            }
            else
            {
                int hoursToServe = students / allCapacity;
                if (hoursToServe % 3 == 0)
                    hoursToRest = hoursToServe / 3 - 1;
                else hoursToRest = hoursToServe / 3;
                totalHours = hoursToServe + hoursToRest + 1;
            }
            Console.WriteLine($"Time needed: {totalHours}h.");
        }
    }
}
