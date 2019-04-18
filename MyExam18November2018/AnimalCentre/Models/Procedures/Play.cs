using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public Play()
            : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal currentAnimal = (Animal)animal;

            if (currentAnimal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            currentAnimal.ProcedureTime -= procedureTime;

            currentAnimal.Happiness += 12;
            currentAnimal.Energy -= 6;

            this.ProcedureHistory.Add(currentAnimal);
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var currentAnimal in this.ProcedureHistory)
            {
                Animal animal = (Animal)currentAnimal;

                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
