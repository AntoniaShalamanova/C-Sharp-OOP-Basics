using System;

namespace CustomException
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "Gin4o_G");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
