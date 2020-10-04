using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> inpCources = Console.ReadLine().Split(", ").ToList();
            string inpCommand = "";
            while ((inpCommand = Console.ReadLine()) != "course start")
            {
                List<string> commands = inpCommand.Split(":").ToList();
                switch (commands[0])
                {
                    case "Add":
                        if (!inpCources.Contains(commands[1]))
                            inpCources.Add(commands[1]);
                        break;
                    case "Insert":
                        if (!inpCources.Contains(commands[1]))
                            inpCources.Insert(int.Parse(commands[2]), commands[1]);
                        break;
                    case "Remove":
                        if (inpCources.Contains(commands[1]))
                            inpCources.Remove(commands[1]);
                        if (inpCources.Contains(commands[1] + "-Exercise"))
                            inpCources.Remove(commands[1] + "-Exercise");
                        break;
                    case "Swap":
                        if (inpCources.Contains(commands[1]) && inpCources.Contains(commands[2]))
                        {
                            if (!inpCources.Contains(commands[1] + "-Exercise")
                                && !inpCources.Contains(commands[2] + "-Exercise"))
                            {
                                int indexCourse = inpCources.IndexOf(commands[2]);
                                inpCources[inpCources.IndexOf(commands[1])] = commands[2];
                                inpCources[indexCourse] = commands[1];
                            }
                            else if (inpCources.Contains(commands[1] + "-Exercise")
                                && !inpCources.Contains(commands[2] + "-Exercise"))
                            {
                                inpCources.RemoveAt(inpCources.IndexOf(commands[1] + "-Exercise"));
                                int indexCourse = inpCources.IndexOf(commands[2]);
                                inpCources[inpCources.IndexOf(commands[1])] = commands[2];
                                inpCources[indexCourse] = commands[1];
                                inpCources.Insert(inpCources.IndexOf(commands[1]) + 1, commands[1] + "-Exercise");
                            }
                            else if (!inpCources.Contains(commands[1] + "-Exercise")
                                && inpCources.Contains(commands[2] + "-Exercise"))
                            {
                                inpCources.RemoveAt(inpCources.IndexOf(commands[2] + "-Exercise"));
                                int indexCourse = inpCources.IndexOf(commands[2]);
                                inpCources[inpCources.IndexOf(commands[1])] = commands[2];
                                inpCources[indexCourse] = commands[1];
                                inpCources.Insert(inpCources.IndexOf(commands[2]) + 1, commands[2] + "-Exercise");
                            }
                            else if (inpCources.Contains(commands[1] + "-Exercise")
                                && inpCources.Contains(commands[2] + "-Exercise"))
                            {
                                inpCources.RemoveAt(inpCources.IndexOf(commands[1] + "-Exercise"));
                                inpCources.RemoveAt(inpCources.IndexOf(commands[2] + "-Exercise"));
                                int indexCourse = inpCources.IndexOf(commands[2]);
                                inpCources[inpCources.IndexOf(commands[1])] = commands[2];
                                inpCources[indexCourse] = commands[1];
                                inpCources.Insert(inpCources.IndexOf(commands[1]) + 1, commands[1] + "-Exercise");
                                inpCources.Insert(inpCources.IndexOf(commands[2]) + 1, commands[2] + "-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        if (!inpCources.Contains(commands[1]))
                        {
                            inpCources.Add(commands[1]);
                            inpCources.Add(commands[1] + "-Exercise");
                        }
                        else
                        {
                            if (!inpCources.Contains(commands[1] + "-Exercise"))
                                inpCources.Insert(inpCources.IndexOf(commands[1]) + 1, commands[1] + "-Exercise");
                        }
                        break;
                }
            }
            for (int i = 0; i < inpCources.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{inpCources[i]}");
            }
        }
    }
}
