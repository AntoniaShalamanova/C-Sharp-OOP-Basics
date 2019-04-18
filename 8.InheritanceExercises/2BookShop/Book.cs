using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Price not valid!");
                    Environment.Exit(0);
                }

                price = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                string secondName = value.Split()[1];

                if (Char.IsDigit(secondName[0]))
                {
                    Console.WriteLine("Author not valid!");
                    Environment.Exit(0);
                }

                author = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Title not valid!");
                    Environment.Exit(0);
                }

                title = value;
            }
        }
    }
}
