using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier firstDate = new DateModifier(Console.ReadLine());
            DateModifier secondDate = new DateModifier(Console.ReadLine());

            Console.WriteLine(firstDate.PrintDifference(secondDate));
        }
    }
}
