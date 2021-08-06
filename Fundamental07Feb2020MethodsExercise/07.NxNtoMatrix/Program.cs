using System;

namespace _07.NxNtoMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            NxNprintMatrix(matrixSize);
        }

        private static void NxNprintMatrix(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int k = 1; k <= size; k++) Console.Write($"{size} ");
                Console.WriteLine();
            }
        }
    }
}
