using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Extensions
{
    public static class ConvertMinutesToSeconds
    {
        public static int ToSeconds(this int minutes)
        {
            return minutes * 60;
        }
    }
}
