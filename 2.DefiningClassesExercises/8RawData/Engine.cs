using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Engine
    {
        private int speed;
        private int power;

        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}
