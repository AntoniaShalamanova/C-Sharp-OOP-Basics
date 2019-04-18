using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public abstract void AffectCharacter(Character character);
    }
}
