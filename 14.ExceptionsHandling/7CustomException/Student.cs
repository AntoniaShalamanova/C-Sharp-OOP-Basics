using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                string namePattenrn = @"^[A-z]{3,120}\Z";

                if (!Regex.IsMatch(value,namePattenrn))
                {
                    throw new InvalidPersonNameException();
                }

                name = value;
            }
        }
    }
}
