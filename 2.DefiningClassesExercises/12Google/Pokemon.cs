using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Pokemon
    {
        private string name;
        private string type;

        public override string ToString()
        {
            return $"{this.Name} {this.Type}\n";
        }

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
