using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                string email = "";
                int age = 0;

                Employee employee = new Employee(name, salary, position, department);

                switch (input.Length)
                {
                    case 6:
                        employee.email = input[4];
                        employee.age = int.Parse(input[5]);
                        break;

                    case 5:
                        if (int.TryParse(input[4], out int result))
                        {
                            employee.age = result;
                        }
                        else
                        {
                            employee.email = input[4];
                        }
                        break;

                    default:
                        break;
                }

                employees.Add(employee);
            }

            var topDepartment = employees.GroupBy(x => x.department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x=>x.Value.Average(s=>s.salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var employee in topDepartment.Value.OrderByDescending(x=>x.salary))
            {
                Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
            }
        }
    }
}
