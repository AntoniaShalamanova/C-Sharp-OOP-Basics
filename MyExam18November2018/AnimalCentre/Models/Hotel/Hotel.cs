using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        public int Capacity { get; set; }
        private Dictionary<string, IAnimal> animals;

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public Hotel()
        {
            this.Capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            Animal currentAnimal = (Animal)animal;

            if (this.Animals.ContainsKey(currentAnimal.Name))
            {
                throw new ArgumentException($"Animal {currentAnimal.Name} already exist");
            }

            this.animals[currentAnimal.Name] = currentAnimal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            ((Animal)this.Animals[animalName]).Owner = owner;
            ((Animal)this.Animals[animalName]).IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}
