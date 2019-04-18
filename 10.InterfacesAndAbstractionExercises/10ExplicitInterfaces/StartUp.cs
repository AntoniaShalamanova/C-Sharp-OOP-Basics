using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen citizent = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

                IPerson person = citizent;

                Console.WriteLine(person.GetName());

                IResident resident = citizent;

                Console.WriteLine(resident.GetName());
            }
        }
    }
}

