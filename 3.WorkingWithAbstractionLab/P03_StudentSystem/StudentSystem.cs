using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public void Show(string name)
        {
            if (this.Repo.ContainsKey(name))
            {
                var student = Repo[name];
                
                Console.WriteLine(student);
            }
        }

        public void CreateSudent(string name, int age, double grade)
        {
            if (!this.Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }

        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo
        {
            get { return repo; }
            private set { repo = value; }
        }
    }
}
