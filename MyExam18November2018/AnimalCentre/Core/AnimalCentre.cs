using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Dictionary<string, IProcedure> procedures;
        private IAnimal animal;
        public Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>();
            this.owners = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    break;
            }

            this.hotel.Accommodate(animal);

            return $"Animal {((Animal)animal).Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("Chip"))
            {
                this.procedures["Chip"] = new Chip();
            }

            this.procedures["Chip"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("Vaccinate"))
            {
                this.procedures["Vaccinate"] = new Vaccinate();
            }

            this.procedures["Vaccinate"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("Fitness"))
            {
                this.procedures["Fitness"] = new Fitness();
            }

            this.procedures["Fitness"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("Play"))
            {
                this.procedures["Play"] = new Play();
            }

            this.procedures["Play"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("DentalCare"))
            {
                this.procedures["DentalCare"] = new DentalCare();
            }

            this.procedures["DentalCare"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            animal = GetAnimal(name);

            if (!this.procedures.ContainsKey("NailTrim"))
            {
                this.procedures["NailTrim"] = new NailTrim();
            }

            this.procedures["NailTrim"].DoService(animal, procedureTime);

            return $"{((Animal)animal).Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            animal = GetAnimal(animalName);

            this.hotel.Adopt(animalName, owner);

            if (!this.owners.ContainsKey(owner))
            {
                this.owners[owner] = new List<string>();
            }

            this.owners[owner].Add(((Animal)animal).Name);

            if (((Animal)animal).IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();

            Procedure procedure = (Procedure)this.procedures[type];

            sb.AppendLine(procedure.GetType().Name);

            foreach (var animal in procedure.ProcedureHistory)
            {
                Animal currentAnimal = (Animal)animal;

                sb.AppendLine($"    Animal type: {currentAnimal.GetType().Name} - {currentAnimal.Name} - Happiness: {currentAnimal.Happiness} - Energy: {currentAnimal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return this.hotel.Animals[name];
        }
    }
}
