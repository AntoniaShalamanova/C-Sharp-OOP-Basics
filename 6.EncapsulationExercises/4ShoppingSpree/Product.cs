using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public decimal Cost
        {
            get { return cost; }

            set
            {
                if (value < 0)
                {
                    CoastException();
                }

                cost = value;
            }
        }

        private void CoastException()
        {
            Exception ex = new ArgumentException("Money cannot be negative");
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    NameException();
                }

                name = value;
            }
        }

        private void NameException()
        {
            Exception ex = new ArgumentException("Name cannot be empty.");
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}
