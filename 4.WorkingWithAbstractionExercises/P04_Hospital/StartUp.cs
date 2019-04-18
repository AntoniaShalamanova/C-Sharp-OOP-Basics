using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Program
    {
        static List<Department> departments;
        static List<Doctor> doctors;

        public static void Main()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();

                var departmentName = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var doctorName = firstName + " " + lastName;
                var patientName = tokens[3];

                Department department = GetDepartment(departmentName);
                Doctor doctor = GetDoctor(doctorName);

                bool containsFreeSpace = department.Rooms.Sum(x => x.Patients.Count) < 60;

                if (containsFreeSpace)
                {
                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            department.Rooms[room].Patients.Add(patientName);
                            doctor.Patients.Add(patientName);
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length == 1)
                {
                    Department department = GetDepartment(commandArgs[0]);

                    foreach (var room in department.Rooms.Where(r => r.Patients.Count > 0))
                    {
                        Console.WriteLine(string.Join("\n", room.Patients));
                    }
                }
                else if (commandArgs.Length == 2 && int.TryParse(commandArgs[1], out int roomNumber))
                {
                    Department department = GetDepartment(commandArgs[0]);

                    Console.WriteLine(string.Join("\n", department.Rooms[roomNumber - 1]
                        .Patients
                        .OrderBy(x => x)));
                }
                else
                {
                    string doctorName = commandArgs[0] + " " + commandArgs[1];

                    Doctor doctor = GetDoctor(doctorName);

                    Console.WriteLine(string.Join("\n", doctor.Patients.OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }

        private static Doctor GetDoctor(string doctorName)
        {
            Doctor doctor = doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                doctor = new Doctor(doctorName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        private static Department GetDepartment(string departmentName)
        {
            Department department = departments
                .FirstOrDefault(d => d.Name == departmentName);

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);
            }

            return department;
        }
    }
}
