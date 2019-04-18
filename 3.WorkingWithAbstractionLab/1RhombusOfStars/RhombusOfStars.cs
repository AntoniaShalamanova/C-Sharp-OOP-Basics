using System;

namespace _1RhombusOfStars
{
    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int i = 1; i <= size; i++)
            {
                PrintRow(size, i);
            }

            for (int i = size - 1; i >= 1; i--)
            {
                PrintRow(size, i);
            }
        }

        private static void PrintRow(int size, int starNumber)
        {
            Console.Write(new string(' ', size - starNumber));

            for (int i = 1; i < starNumber; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
