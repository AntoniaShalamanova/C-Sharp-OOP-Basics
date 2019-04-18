using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public override string ToString()
        {
            string result = $"{this.Name} {this.Birthday}\n";

            result += "Parents:\n";
            foreach (var parent in this.Parents)
            {
                result += $"{parent.Name} {parent.Birthday}\n";
            }

            result += "Children:\n";
            foreach (var child in this.Children)
            {
                result += $"{child.Name} {child.Birthday}\n";
            }

            return result;
        }

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public List<Person> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
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
