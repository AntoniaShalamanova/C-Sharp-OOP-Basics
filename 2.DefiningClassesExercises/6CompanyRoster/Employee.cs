using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    public class Employee
    {
        public string name { get; set; }
        public decimal salary { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public int age { get; set; }

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }
    }
}
