using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Factions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (Enum.TryParse(faction, out Faction enumFaction))
            {
                switch (characterType)
                {
                    case "Warrior":
                        return new Warrior(name, enumFaction);
                    case "Cleric":
                        return new Cleric(name, enumFaction);
                    default:
                        throw new ArgumentException($"Invalid character type \"{characterType}\"!");
                }
            }

            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }
    }
}
