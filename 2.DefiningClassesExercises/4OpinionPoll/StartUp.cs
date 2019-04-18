using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> students = new List<Person>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input =Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                students.Add(person);
            }

            students = students.Where(x => x.Age > 30).ToList();

            foreach (var student in students.OrderBy(x=>x.Name))
            {
                Console.WriteLine(student);
            }
        }
    }
}
