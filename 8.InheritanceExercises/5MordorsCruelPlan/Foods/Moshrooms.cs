using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public class Moshrooms : Food
    {
        private const int happiness = -10;

        public Moshrooms() 
            : base(happiness)
        {
        }
    }
}
