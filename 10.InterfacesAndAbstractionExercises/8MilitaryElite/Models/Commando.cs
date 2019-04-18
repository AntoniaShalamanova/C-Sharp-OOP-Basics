using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {Corps}");
            builder.Append($"Missions:");

            builder.Append(Missions.Count == 0 ? "" : "\n");
            builder.Append(string.Join("\n", Missions));

            return builder.ToString();
        }

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }
    }
}
