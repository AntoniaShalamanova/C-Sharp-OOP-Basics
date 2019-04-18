using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    public class StartUp
    {
        static new Dictionary<string, Person> people;

        static void Main(string[] args)
        {
            people = new Dictionary<string, Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = tokens[0];

                if (!people.ContainsKey(personName))
                {
                    people[personName] = new Person(personName);
                }

                FillPerson(tokens);

                input = Console.ReadLine();
            }

            string searchedPerson = Console.ReadLine();

            Console.WriteLine(searchedPerson);
            Console.Write(people[searchedPerson]);
        }

        private static void FillPerson(string[] tokens)
        {
            string personName = tokens[0];
            string info = tokens[1];

            switch (info)
            {
                case "company":
                    string companyName = tokens[2];
                    string department = tokens[3];
                    double salary = double.Parse(tokens[4]);

                    people[personName].Company = new Company(companyName, department, salary);
                    break;

                case "car":
                    string carModel = tokens[2];
                    string carSpeed = tokens[3];

                    people[personName].Car = new Car(carModel, carSpeed);
                    break;

                case "pokemon":
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];

                    people[personName].Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                    break;

                case "parents":
                    string parentName = tokens[2];
                    string parentBirthday = tokens[3];

                    people[personName].Parents.Add(new Parent(parentName, parentBirthday));
                    break;

                case "children":
                    string childName = tokens[2];
                    string childrenBirthday = tokens[3];

                    people[personName].Children.Add(new Child(childName, childrenBirthday));
                    break;
                default:
                    break;
            }
        }
    }
}
