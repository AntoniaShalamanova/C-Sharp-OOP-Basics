﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Make sound...");
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Gender
        {
            get { return gender; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }

                gender = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }

                age = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }

                name = value;
            }
        }
    }
}
