using System;

namespace EnterNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            bool IsValid = false;

            while (IsValid == false)
            {
                try
                {
                    ReadNumber(1, 100);
                    IsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ReadNumber(int start, int end)
        {
            int lastNumber = start;
            int currentNumber;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    currentNumber = int.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
                catch (OverflowException oe)
                {
                    throw oe;
                }

                if (currentNumber <= start)
                {
                    throw new ArgumentOutOfRangeException(nameof(start),
                        currentNumber,
                        $"Input number must be between [{start}...{end}]!");
                }
                else if (currentNumber >= end)
                {
                    throw new ArgumentOutOfRangeException(nameof(end),
                        currentNumber,
                        $"Input number must be between [{start}...{end}]!");
                }

                if (currentNumber <= lastNumber)
                {
                    throw new Exception(
                        $"Input number must be greater than last one!");
                }

                lastNumber = currentNumber;
            }
        }
    }
}
