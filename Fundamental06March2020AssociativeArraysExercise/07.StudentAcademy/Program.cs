using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentInfo = new Dictionary<string, List<double>>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());
                if (!studentInfo.ContainsKey(studentName)) studentInfo[studentName] = new List<double>();
                studentInfo[studentName].Add(studentGrade);
            }
            Dictionary<string, double> resultInfo = studentInfo
            .ToDictionary(x => x.Key, y => y.Value.Average())
            .Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, y => y.Value);
            foreach (var kvp in resultInfo)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }
    }
}
