using System;

namespace Family
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input =Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                family.AddMember(name, age);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
