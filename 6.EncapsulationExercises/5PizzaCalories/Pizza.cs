using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza
{
    public class Pizza
    {
        private string name;
        private Dough dought;
        private List<Topping> toppings;

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():F2} Calories.";
        }

        public Pizza(string name, Dough dought)
        {
            this.Name = name;
            this.Dought = dought;
            this.Toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                Exception ex = new ArgumentException("Number of toppings should be in range [0..10].");
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            this.Toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.Dought.GetCalories() + this.Toppings.Sum(t => t.GetCalories());
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set
            {
                toppings = value;
            }
        }

        public Dough Dought
        {
            get { return dought; }
            set { dought = value; }
        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value) ||
                    value.Length < 1 ||
                    value.Length > 15)
                {
                    Exception ex = new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                name = value;
            }
        }
    }
}
