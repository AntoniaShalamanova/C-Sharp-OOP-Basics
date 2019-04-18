using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new Exception("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
