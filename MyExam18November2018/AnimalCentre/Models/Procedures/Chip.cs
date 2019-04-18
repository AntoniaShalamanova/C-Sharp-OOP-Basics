using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
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

            currentAnimal.Happiness -= 5;

            if (currentAnimal.IsChipped == true)
            {
                throw new ArgumentException($"{currentAnimal.Name} is already chipped");
            }

            currentAnimal.IsChipped = true;

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
