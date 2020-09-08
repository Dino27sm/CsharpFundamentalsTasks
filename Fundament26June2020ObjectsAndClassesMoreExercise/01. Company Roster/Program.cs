using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listOfEmployees = new List<Employee>();
            int linesNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNum; i++)
            {
                List<string> currentLine = Console.ReadLine().Split().ToList();
                string employeeName = currentLine[0];
                double employeeSalary = double.Parse(currentLine[1]);
                string departmentName = currentLine[2];
                Employee employeeObject = new Employee(employeeName, employeeSalary, departmentName);
                listOfEmployees.Add(employeeObject);
            }
            List<string> differDepartments = new List<string>();
            for (int k = 0; k < listOfEmployees.Count; k++)
            {
                if (!differDepartments.Contains(listOfEmployees[k].DepartmentName))
                    differDepartments.Add(listOfEmployees[k].DepartmentName);
            }
            string maxDepartment = "";
            double maxAverageSalary = 0;
            for (int i = 0; i < differDepartments.Count; i++)
            {
                double tempSum = 0;
                double tempMaxAverage = 0;
                int counter = 0;
                for (int k = 0; k < listOfEmployees.Count; k++)
                {
                    if (differDepartments[i] == listOfEmployees[k].DepartmentName)
                    {
                        tempSum += listOfEmployees[k].SalaryEmloyee;
                        counter++;
                    }
                }
                if (counter > 0) tempMaxAverage = tempSum / counter;
                else Console.WriteLine("Error ! - devision by zero");
                if (maxAverageSalary < tempMaxAverage)
                {
                    maxAverageSalary = tempMaxAverage;
                    maxDepartment = differDepartments[i];
                }
            }
            Console.WriteLine($"Highest Average Salary: {maxDepartment}");
            foreach (var item in listOfEmployees.Where(x => x.DepartmentName == maxDepartment)
                .OrderByDescending(x => x.SalaryEmloyee))
            {
                Console.WriteLine($"{item.NameEmloyee} {item.SalaryEmloyee:F2}");
            }
        }
    }
    public class Employee
    {
        public string NameEmloyee { get; set; }
        public double SalaryEmloyee { get; set; }
        public string DepartmentName { get; set; }
        public Employee(string name, double salary, string department)
        {
            this.NameEmloyee = name;
            this.SalaryEmloyee = salary;
            this.DepartmentName = department;
        }
    }
}
