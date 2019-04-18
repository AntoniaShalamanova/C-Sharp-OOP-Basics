using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private const double DefaultHeal = 0.2;

        private string name;
        public double BaseHealth { get; private set; }
        private double health;
        public double BaseArmor { get; private set; }
        private double armor;
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public Faction Faction { get; private set; }
        public bool IsAlive { get; set; }
        public virtual double RestHealMultiplier { get; private set; }

        protected Character(string name, double health, double armor,
            double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = DefaultHeal;
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureIsAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double reminder = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= reminder;
            }
        }

        public void Rest()
        {
            this.EnsureIsAlive();

            this.Health += this.BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.EnsureIsAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureIsAlive();
            character.EnsureIsAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureIsAlive();
            character.EnsureIsAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.EnsureIsAlive();

            this.Bag.AddItem(item);
        }

        public void EnsureIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
