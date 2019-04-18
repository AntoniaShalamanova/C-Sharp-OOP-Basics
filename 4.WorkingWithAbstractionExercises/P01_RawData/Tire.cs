using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    class Tire
    {
        private double pressure { get; set; }
        private int age { get; set; }

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
