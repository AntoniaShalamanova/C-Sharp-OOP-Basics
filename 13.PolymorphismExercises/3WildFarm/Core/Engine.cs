﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Animals.Birds.Factory;
using WildFarm.Animals.Felines;
using WildFarm.Animals.Mammals.Factory;
using WildFarm.Foods;
using WildFarm.Foods.Factory;

namespace WildFarm.Core
{
    public class Engine
    {
        private BirdFactory birdFactory;
        private FelineFactory felineFactory;
        private MammalFactory mammalFactory;
        private FoodFactory foodFactory;
        private List<Animal> animals;
        private Animal animal;
        private Food food;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.felineFactory = new FelineFactory();
            this.mammalFactory = new MammalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string[] foodInfo = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string animalType = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    if (animalType == "Hen" || animalType == "Owl")
                    {
                        double wingSize = double.Parse(animalInfo[3]);

                        animal = this.birdFactory.CreateBird(animalType,
                            name, weight, wingSize);
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = animalInfo[3];

                        animal = this.mammalFactory.CreateMammal(animalType,
                            name, weight, livingRegion);
                    }
                    else if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];

                        animal = this.felineFactory.CreateFeline(animalType,
                            name, weight, livingRegion, breed);
                    }

                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);

                    food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    animal.ProduceSound();
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}