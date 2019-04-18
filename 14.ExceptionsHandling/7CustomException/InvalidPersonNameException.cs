using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message = "The name cannot have special characters ot numbers!")
            : base(message)
        {
        }
    }
}
