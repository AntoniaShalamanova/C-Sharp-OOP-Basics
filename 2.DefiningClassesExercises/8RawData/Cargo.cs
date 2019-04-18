using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Cargo
    {
        private int weight;
        private string type;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Cargo(int weigt, string type)
        {
            this.Weight = weigt;
            this.Type = type;
        }
    }
}
