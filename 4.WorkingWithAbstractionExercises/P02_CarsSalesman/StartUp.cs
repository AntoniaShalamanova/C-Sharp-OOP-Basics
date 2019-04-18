using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class StartUp
    {
        public static List<Car> cars;
        public static List<Engine> engines;

        static void Main(string[] args)
        {
            cars = new List<Car>();
            engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                engines.Add(Engine.MakeEngine(parameters));
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                cars.Add(Car.MakeCar(parameters, engines));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
