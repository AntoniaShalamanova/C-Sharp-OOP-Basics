using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    class StartUp
    {
        static List<Person> peoples;
        static List<string> relationships;

        static void Main(string[] args)
        {
            peoples = new List<Person>();
            relationships = new List<string>();

            string searchedPersonInfo = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!input.Contains("-"))
                {
                    AddPerson(input);
                }
                else
                {
                    relationships.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var info in relationships)
            {
                string[] peoplesInfo = info.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                Person parent = GetPerson(peoplesInfo[0]);
                Person child = GetPerson(peoplesInfo[1]);

                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }
                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }

            Console.WriteLine(GetPerson(searchedPersonInfo));
        }

        private static Person GetPerson(string info)
        {
            if (info.Contains("/"))
            {
                return peoples.FirstOrDefault(x => x.Birthday == info);
            }
            else
            {
                return peoples.FirstOrDefault(x => x.Name == info);
            }
        }

        private static void AddPerson(string input)
        {
            string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0] + " " + tokens[1];
            string birthday = tokens[2];

            Person person = new Person(name, birthday);
            peoples.Add(person);
        }
    }
}
