using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            string[] numbers = Console.ReadLine()
                    .Split(" ");

            foreach (var number in numbers)
            {
                try
                {
                    smartphone.Call(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string[] sites = Console.ReadLine()
                                .Split(" ");

            foreach (var site in sites)
            {
                try
                {
                    smartphone.Browse(site);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
