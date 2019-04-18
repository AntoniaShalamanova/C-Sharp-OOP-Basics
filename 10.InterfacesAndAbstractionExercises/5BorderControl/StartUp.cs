using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        private static object list;

        public static void Main(string[] args)
        {
            List<IIdentifiable> society = new List<IIdentifiable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    society.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else
                {
                    society.Add(new Robot(tokens[0], tokens[1]));
                }

                input = Console.ReadLine();
            }

            string fakeIdEnd = Console.ReadLine();

            Console.WriteLine(string.Join("\n", society
                .Where(x => x.Id.EndsWith(fakeIdEnd))
                .Select(x => x.Id)));
        }
    }
}
