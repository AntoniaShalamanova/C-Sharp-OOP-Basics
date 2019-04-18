using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.LastName}")
                .AppendLine($"Faculty number: {this.FacultyNumber}");

            return builder.ToString();
        }

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                string pattern = @"^[A-z0-9]{5,10}\Z";

                if (!Regex.IsMatch(value, pattern))
                {
                    Console.WriteLine("Invalid faculty number!");
                    Environment.Exit(0);
                }

                facultyNumber = value;
            }
        }
    }
}
