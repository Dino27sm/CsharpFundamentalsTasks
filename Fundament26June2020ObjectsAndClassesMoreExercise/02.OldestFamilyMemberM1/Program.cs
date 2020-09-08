using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMemberM1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            int numEntries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numEntries; i++)
            {
                string[] lineEnter = Console.ReadLine().Split().ToArray();
                Person newPerson = new Person(lineEnter[0], int.Parse(lineEnter[1]));
                personList.Add(newPerson);
            }
            Person memberToPrint = personList.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"{memberToPrint.Name} {memberToPrint.Age}");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string personName, int personAge)
        {
            this.Name = personName;
            this.Age = personAge;
        }
    }
}
