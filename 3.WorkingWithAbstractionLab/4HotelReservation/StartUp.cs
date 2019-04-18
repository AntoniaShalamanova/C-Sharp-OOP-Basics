using System;

namespace PriceCalculator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(input[0]);
            int daysCount = int.Parse(input[1]);
            Season season = Enum.Parse<Season>(input[2]);
            Discount discount = Discount.None;

            if (input.Length == 4)
            {
                discount = Enum.Parse<Discount>(input[3]);
            }

            decimal result = PriceCalculator
                .Calculate(pricePerDay, daysCount, season, discount);

            Console.WriteLine($"{result:F2}");
        }
    }
}
