namespace _6.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfEmployees = new List<Employee>();
            var numberOfEmplyees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmplyees; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
               
                    var name = tokens[0];
                    var salary = decimal.Parse(tokens[1]);
                    var position = tokens[2];
                    var department = tokens[3];
                    var employee = new Employee(name, salary, position, department);

               
                if (tokens.Length > 4 )
                {
                    var ageOrEmail = tokens[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.Email = ageOrEmail;
                    }
                    else
                    {
                        employee.Age = int.Parse(ageOrEmail);
                    }         
                }

                if (tokens.Length > 5)
                {
                    employee.Age = int.Parse(tokens[5]);
                }

                listOfEmployees.Add(employee);
            }

           var result = listOfEmployees.GroupBy(x => x.Department)
                .Select(x => new
                {
                    Department = x.Key,
                    AverageSalary = x.Average(emp => emp.Salary),
                    Employees = x.OrderByDescending(emp => emp.Salary)
                })
                .OrderByDescending(x => x.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");
            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
