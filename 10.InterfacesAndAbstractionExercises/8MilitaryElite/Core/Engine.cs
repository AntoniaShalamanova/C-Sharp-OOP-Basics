using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;
        private object corps;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string type = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    soldier = GetLieutenantGeneral(id, firstName, lastName,
                        salary, tokens);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    soldier = GetEngineer(id, firstName, lastName,
                        salary, tokens);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    soldier = GetCommmando(id, firstName, lastName,
                        salary, tokens);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetCommmando(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            string corpsAsString = tokens[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName,
                salary, corps);

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string codeName = tokens[i];
                string stateAsString = tokens[i + 1];

                if (!Enum.TryParse(stateAsString,out State state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);

                commando.Missions.Add(mission);
            }

            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            string corpsAsString = tokens[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            IEngineer engneer = new Engineer(id, firstName, lastName,
                salary, corps);

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string partName = tokens[i];
                int workedHours = int.Parse(tokens[i + 1]);

                IRepair repair = new Repair(partName, workedHours);

                engneer.Repairs.Add(repair);
            }

            return engneer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName,
            string lastName, decimal salary, string[] tokens)
        {
            ILieutenantGeneral soldier = new LieutenantGeneral(id, firstName,
                lastName, salary);

            for (int i = 5; i < tokens.Length; i++)
            {
                int privateId = int.Parse(tokens[i]);

                IPrivate privateSoldier = (IPrivate)soldiers
                    .FirstOrDefault(x => x.Id == privateId);

                soldier.Privates.Add(privateSoldier);
            }

            return soldier;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName,
            string lastName, decimal salary)
        {
            IPrivate soldier = new Private(id, firstName, lastName, salary);

            return soldier;
        }
    }
}
