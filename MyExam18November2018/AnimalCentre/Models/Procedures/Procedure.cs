using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure:IProcedure
    {
        public List<IAnimal> ProcedureHistory;

        protected ICollection<IAnimal> procedureHistory => this.ProcedureHistory.AsReadOnly();

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public abstract string History();

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}
