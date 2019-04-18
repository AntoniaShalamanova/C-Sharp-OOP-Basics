using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new Dictionary<string, IBuyer>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    people.Add(input[0],
                        new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else
                {
                    people.Add(input[0],
                        new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }

            string name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                IBuyer buyer = people.FirstOrDefault(x => x.Key == name).Value;

                if (buyer != null)
                {
                    buyer.Buy();
                }
            }

            Console.WriteLine(people.Sum(x=>x.Value.Food));
        }
    }
}
