using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;

        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public override string ToString()
        {
            string result = "";

            result += $"Company:\n";
            result += $"{this.Company}";

            result += $"Car:\n";
            result += $"{this.Car}";

            result += $"Pokemon:\n";
            foreach (var pokemon in this.Pokemons)
            {
                result += $"{pokemon}";
            }

            result += $"Parents:\n";
            foreach (var parent in this.Parents)
            {
                result += $"{parent}";
            }

            result += $"Children:\n";
            foreach (var child in this.Children)
            {
                result += $"{child}";
            }

            return result;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }
    }
}
