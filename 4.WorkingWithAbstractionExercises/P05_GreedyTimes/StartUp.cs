using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Bag bag = new Bag();

            for (int i = 0; i < items.Length; i += 2)
            {
                string item = items[i];
                long amount = long.Parse(items[i + 1]);

                string type = GetType(item);

                if (type == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.GetBagAmount() + amount)
                {
                    continue;
                }

                bag.GetItem(item, amount, type);
            }

            Console.WriteLine(bag.ToString());
        }

        private static string GetType(string item)
        {
            string type = string.Empty;

            if (item.Length == 3)
            {
                type = "Cash";
            }
            else if (item.ToLower().EndsWith("gem"))
            {
                type = "Gem";
            }
            else if (item.ToLower() == "gold")
            {
                type = "Gold";
            }

            return type;
        }
    }
}