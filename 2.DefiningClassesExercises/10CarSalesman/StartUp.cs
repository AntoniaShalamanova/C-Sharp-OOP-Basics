using System;
using System.Collections.Generic;
using System.Linq;

namespace Car
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                string power = engineInfo[1];

                Engine engine = new Engine(model, power);

                FillEngine(engine, engineInfo);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                Car car = new Car(model, engine);

                FillCar(car, carInfo);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void FillCar(Car car, string[] carInfo)
        {
            if (carInfo.Length == 4)
            {
                string weight = carInfo[2];
                string color = carInfo[3];

                car.Weight = weight;
                car.Color = color;
            }
            else if (carInfo.Length == 3)
            {
                if (double.TryParse(carInfo[2], out double result))
                {
                    car.Weight = result.ToString();
                }
                else
                {
                    car.Color = carInfo[2];
                }
            }
        }

        private static void FillEngine(Engine engine, string[] engineInfo)
        {
            if (engineInfo.Length == 4)
            {
                string displacement = engineInfo[2];
                string efficiency = engineInfo[3];

                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
            }
            else if (engineInfo.Length == 3)
            {
                if (double.TryParse(engineInfo[2], out double result))
                {
                    engine.Displacement = result.ToString();
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }
            }
        }
    }
}
