using System;

namespace _01.SoftUniReceptionM2
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
            int hoursToRest = 0;
            if (students == 0)
            {
                Console.WriteLine("Time needed: 0h.");
                return;
            }
            int hoursToServe = (int)Math.Ceiling(1.0 * students / allCapacity);
            if (hoursToServe % 3 == 0)
                hoursToRest = hoursToServe / 3 - 1;
            else hoursToRest = hoursToServe / 3;
            int totalHours = hoursToServe + hoursToRest;
            Console.WriteLine($"Time needed: {totalHours}h.");
        }
    }
}
