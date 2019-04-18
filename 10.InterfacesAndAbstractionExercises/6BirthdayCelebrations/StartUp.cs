using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<INameable> society = new List<INameable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    society.Add(new Citizen(tokens[1], int.Parse(tokens[2]),
                        tokens[3], tokens[4]));

                }
                else if (tokens[0] == "Pet")
                {
                    society.Add(new Pet(tokens[1], tokens[2]));
                }
                else if (tokens[0] == "Robot")
                {
                    Robot robot = new Robot(tokens[1], tokens[2]);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            Console.WriteLine(string.Join("\n", society
                .Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)));
        }
    }
}
