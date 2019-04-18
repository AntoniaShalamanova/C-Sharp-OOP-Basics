using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        public int Happiness { get; }

        public Food(int happiness)
        {
            this.Happiness = happiness;
        }
    }
}
