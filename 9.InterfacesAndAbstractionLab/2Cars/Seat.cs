using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{Color} Seat {Model}");
            builder.AppendLine(this.Start());
            builder.Append(this.Stop());

            return builder.ToString();
        }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Car started";
        }

        public string Stop()
        {
            return "Car stopped";
        }
    }
}
