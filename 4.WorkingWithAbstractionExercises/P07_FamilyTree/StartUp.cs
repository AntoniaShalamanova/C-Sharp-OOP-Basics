using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    public class StartUp
    {
        public static List<Person> familyTree;
        static List<string> relationships;

        static void Main(string[] args)
        {
            familyTree = new List<Person>();
            relationships = new List<string>();

            string mainPerson = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    relationships.Add(command);
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    Person person = new Person(name, birthday);

                    familyTree.Add(person);
                }
            }

            foreach (var info in relationships)
            {
                string[] tokens = info.Split(" - ");

                string parentInfo = tokens[0];
                string childInfo = tokens[1];

                MakeRelation(parentInfo, childInfo);
            }

            Person searchedPerson = MakePerson(mainPerson);

            Console.WriteLine(searchedPerson);
            Console.WriteLine("Parents:");
            foreach (var p in searchedPerson.Parents)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Children:");
            foreach (var c in searchedPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static void MakeRelation(string parentInfo, string childInfo)
        {
            Person parent = MakePerson(parentInfo);

            Person child = MakePerson(childInfo);

            parent.Children.Add(child);
            child.Parents.Add(parent);
        }

        static Person MakePerson(string input)
        {
            Person person = familyTree
                .FirstOrDefault(x => x.Name == input ||
                x.Birthday == input);

            return person;
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
