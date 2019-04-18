using AnimalCentre.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandType = commandArgs[0];

                    commandArgs = commandArgs.Skip(1).ToArray();

                    string name = "";
                    int procedureTime = 0;

                    switch (commandType)
                    {
                        case "RegisterAnimal":
                            string type = commandArgs[0];
                            name = commandArgs[1];
                            int energy = int.Parse(commandArgs[2]);
                            int happiness = int.Parse(commandArgs[3]);
                            procedureTime = int.Parse(commandArgs[4]);

                            Console.WriteLine(this.animalCentre.RegisterAnimal(type, name, energy,
                                happiness, procedureTime));
                            break;

                        case "Chip":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.Chip(name, procedureTime));
                            break;

                        case "Vaccinate":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.Vaccinate(name, procedureTime));
                            break;

                        case "Fitness":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.Fitness(name, procedureTime));
                            break;

                        case "Play":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.Play(name, procedureTime));
                            break;

                        case "DentalCare":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.DentalCare(name, procedureTime));
                            break;

                        case "NailTrim":
                            name = commandArgs[0];
                            procedureTime = int.Parse(commandArgs[1]);

                            Console.WriteLine(this.animalCentre.NailTrim(name, procedureTime));
                            break;

                        case "Adopt":
                            string animalName = commandArgs[0];
                            string owner = commandArgs[1];

                            Console.WriteLine(this.animalCentre.Adopt(animalName, owner));
                            break;

                        case "History":
                            string procedureType = commandArgs[0];
                            Console.WriteLine(this.animalCentre.History(procedureType));
                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }

                command = Console.ReadLine();
            }

            var owners = this.animalCentre.owners.OrderBy(x => x.Key);

            foreach (var owner in owners)
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"   - Adopted animals: {string.Join(" ", owner.Value)}");
            }
        }
    }
}
