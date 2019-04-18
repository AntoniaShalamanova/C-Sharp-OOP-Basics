﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public override string ToString()
        {
            string result = $"{this.Model}:\n";
            result += $"{this.engine}";
            result += $"  Weight: {this.Weight}\n";
            result += $"  Color: {this.Color}";

            return result;
        }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}