using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentInfo = new Dictionary<string, List<string>>();
            string textEnter;
            while((textEnter = Console.ReadLine()) != "end")
            {
                string[] inpText = textEnter
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string course = inpText[0];
                string student = inpText[1];
                if (!studentInfo.ContainsKey(course))
                {
                    studentInfo[course] = new List<string>();
                }
                studentInfo[course].Add(student);
            }
            foreach (var kvp in studentInfo.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(z => z))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
