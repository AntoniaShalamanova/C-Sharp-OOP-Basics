using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double GetCalories()
        {
            double flourModifier =
                this.FlourType.ToLower() == "white" ? 1.5 : 1.0;

            double bakingModifier =
                this.BakingTechnique.ToLower() == "crispy" ? 0.9 :
                this.BakingTechnique.ToLower() == "chewy" ? 1.1 : 1.0;

            double calories = this.Weight * 2;

            return calories * flourModifier * bakingModifier;
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                weight = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" &&
                    value.ToLower() != "wholegrain")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                flourType = value;
            }
        }
    }
}
