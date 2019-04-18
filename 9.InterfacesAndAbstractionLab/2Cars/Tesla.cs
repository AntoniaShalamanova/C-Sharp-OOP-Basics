using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{Color} Tesla {Model} with {Batteries} Batteries");
            builder.AppendLine(this.Start());
            builder.Append(this.Stop());

            return builder.ToString();
        }

        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Batteries { get; private set; }

        public string Start()
        {
            return "Tesla started";
        }

        public string Stop()
        {
            return "Tesla stopped";
        }
    }
}
