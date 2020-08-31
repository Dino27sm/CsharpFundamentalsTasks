using System;

namespace _01.SoftUniReception
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
            int remainToServe = students;
            int countHours = 0;
             if (students == 0)
            {
                Console.WriteLine("Time needed: 0h.");
                return;
            }
            while (true)
            {
                countHours++;
                if(countHours % 4 != 0)
                {
                    if (remainToServe - allCapacity > 0)
                        remainToServe -= allCapacity;
                    else break;
                }
            }
            Console.WriteLine($"Time needed: {countHours}h.");
        }
    }
}
