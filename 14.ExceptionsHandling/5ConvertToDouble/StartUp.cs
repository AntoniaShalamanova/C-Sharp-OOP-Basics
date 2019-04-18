using System;

namespace ConvertToDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                Console.WriteLine(Convert(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static double Convert(string number)
        {
            try
            {
                return System.Convert.ToDouble(number);
            }
            catch (FormatException fe)
            {
                throw new Exception("Invalid format!", fe);
            }
            catch (OverflowException oe)
            {
                throw new Exception("Overflow!", oe);
            }
        }
    }
}
