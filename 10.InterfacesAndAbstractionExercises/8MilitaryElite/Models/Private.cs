using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}";
        }

        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary
        {
            get => salary;
            private set => salary = value;
        }
    }
}
