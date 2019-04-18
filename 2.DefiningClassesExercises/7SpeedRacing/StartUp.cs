using System;
using System.Collections.Generic;

namespace Car
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                double km = double.Parse(tokens[2]);

                cars[model].MoveCar(km);

                input = Console.ReadLine();
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.model} {car.fuelAmount:F2} {car.traveledDistance}");
            }
        }
    }
}
