using System;
using System.Collections.Generic;
using System.Linq;

namespace Trainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }

                trainers[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            string element = Console.ReadLine();

            while (element != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons = trainer.Pokemons
                            .Where(x => x.Health > 0)
                            .ToList();
                    }
                }

                element = Console.ReadLine();
            }

            trainers = trainers
                .OrderByDescending(t => t.Value.Badges)
                .ToDictionary(x => x.Key, y => y.Value);


            foreach (var trainer in trainers.Values)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
