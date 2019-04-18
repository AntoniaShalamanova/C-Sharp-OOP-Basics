using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    class StartUp
    {
        static List<Person> people;
        static List<Product> products;

        static void Main(string[] args)
        {
            people = new List<Person>();
            products = new List<Product>();

            string[] peopleInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

            string[] productsInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] tokens = peopleInfo[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] tokens = productsInfo[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = tokens[0];
                string productName = tokens[1];

                Product product = products.FirstOrDefault(p => p.Name == productName);
                Person person = people.FirstOrDefault(p => p.Name == personName);

                person.AddProduct(product);

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
