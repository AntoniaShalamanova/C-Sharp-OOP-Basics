using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    Console.WriteLine("Expected upper case letter! Argument: lastName");
                    Environment.Exit(0);
                }

                if (value.Length < 3)
                {
                    Console.WriteLine("Expected length at least 3 symbols! Argument: lastName");
                    Environment.Exit(0);
                }

                lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    Console.WriteLine("Expected upper case letter!Argument: firstName");
                    Environment.Exit(0);
                }

                if (value.Length <= 3)
                {
                    Console.WriteLine("Expected length at least 4 symbols! Argument: firstName");
                    Environment.Exit(0);
                }

                firstName = value;
            }
        }
    }
}
