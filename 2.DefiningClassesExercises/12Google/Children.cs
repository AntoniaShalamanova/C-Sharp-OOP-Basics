using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child
    {
        private string name;
        private string birthday;

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}\n";
        }

        public Child(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
