using System;

namespace StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            string input = Console.ReadLine();

            while (input!= "Exit")
            {
                string[] args = input.Split();

                if (args[0] == "Create")
                {
                    var name = args[1];
                    var age = int.Parse(args[2]);
                    var grade = double.Parse(args[3]);

                    studentSystem.CreateSudent(name, age, grade);
                }
                else if (args[0] == "Show")
                {
                    var name = args[1];

                    studentSystem.Show(name);
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
