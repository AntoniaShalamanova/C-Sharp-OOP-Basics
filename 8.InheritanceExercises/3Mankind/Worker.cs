using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hoursPerDay;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.LastName}")
                .AppendLine($"Week Salary: {this.WeekSalary:F2}")
                .AppendLine($"Hours per day: {this.HoursPerDay:F2}")
                .AppendLine($"Salary per hour: {this.MoneyByHour:F2}");


            return builder.ToString();
        }

        public decimal MoneyByHour
        {
            get
            {
                decimal hoursPerWeek = this.HoursPerDay * 5;

                return this.weekSalary / hoursPerWeek;
            }
        }

        public Worker(string firstName, string lastName,
            decimal weekSalary, decimal hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public decimal HoursPerDay
        {
            get { return hoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    Console.WriteLine("Expected value mismatch! Argument: workHoursPerDay");
                    Environment.Exit(0);
                }

                hoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value < 11)
                {
                    Console.WriteLine("Expected value mismatch! Argument: weekSalary");
                    Environment.Exit(0);
                }

                weekSalary = value;
            }
        }
    }
}
