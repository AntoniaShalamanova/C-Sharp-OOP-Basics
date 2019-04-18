using System;

namespace Fixing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] weeekdeys = new string[5];
            weeekdeys[0] = "Sunday";
            weeekdeys[1] = "Monday";
            weeekdeys[2] = "Tuesday";
            weeekdeys[3] = "Wednesday";
            weeekdeys[4] = "Thursday";
            
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weeekdeys[i]);
                }

                Console.ReadLine();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
