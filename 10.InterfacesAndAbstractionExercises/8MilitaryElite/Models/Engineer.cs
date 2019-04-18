using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {Corps}");
            builder.Append($"Repairs:");

            builder.Append(Repairs.Count == 0 ? "" : "\n");
            builder.Append(string.Join("\n", Repairs));

            return builder.ToString();
        }

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }
    }
}
