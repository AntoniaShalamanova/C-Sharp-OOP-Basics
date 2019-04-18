using System;
using System.Collections.Generic;

namespace Pizza
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughtInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dough dought = new Dough(doughtInfo[1],
                doughtInfo[2],
                double.Parse(doughtInfo[3]));

            Pizza pizza = new Pizza(pizzaName, dought);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] toppingInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                pizza.AddTopping(topping);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{pizzaName} - {pizza.GetCalories():F2} Calories.");
        }
    }
}