using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Company
    {
        private string name;
        private string department;
        private double salary;

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:F2}\n";
        }

        public Company(string name, string department, double salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
