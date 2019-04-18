using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double GetCalories()
        {
            double calories = 2 * this.Weight;

            double modifier = this.Type.ToLower() == "meat" ? 1.2 :
               this.Type.ToLower() == "veggies" ? 0.8 :
               this.Type.ToLower() == "cheese" ? 1.1 : 0.9;

            return calories * modifier;
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string tupe = char.ToUpper(this.Type[0]) +
                        this.Type.Substring(1);
                    Exception ex = new ArgumentException($"{type} weight should be in the range[1..50].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                weight = value;
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    Exception ex = new ArgumentException($"Cannot place {value} on top of your pizza.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                type = value;
            }
        }
    }
}
