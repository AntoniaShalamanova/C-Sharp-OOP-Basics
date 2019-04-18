using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public override string ToString()
        {
            if (this.Products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", this.Products.Select(x=>x.Name))}";
            }
        }

        public void AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.Money -= product.Cost;
                this.Products.Add(product);
            }
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        internal List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public decimal Money
        {
            get { return money; }

            set
            {
                if (value < 0)
                {
                    MoneyException();
                }

                money = value;
            }
        }

        private void MoneyException()
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
