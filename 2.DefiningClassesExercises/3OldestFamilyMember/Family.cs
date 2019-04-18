using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Family
{
    public class Family
    {
        private List<Person> people = new List<Person>();

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = new List<Person>(); }
        }

        public void AddMember(string name, int age)
        {
            Person person = new Person(name, age);

            this.people.Add(person);
        }

        public string GetOldestMember()
        {
            Person oldestMember = people.OrderByDescending(x => x.Age).FirstOrDefault();

            return $"{oldestMember.Name} {oldestMember.Age}";
        }
    }
}
