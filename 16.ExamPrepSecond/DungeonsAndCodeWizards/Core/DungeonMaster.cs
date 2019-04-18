using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private List<Character> characters;
        private Stack<Item> items;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.items.Pop();
            character.Bag.AddItem(item);
               
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health))
            {
                sb.Append($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, ");
                sb.Append($"AP: {character.Armor}/{character.BaseArmor}, ");
                sb.AppendLine($"Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);

            Warrior warrior = attacker as Warrior;

            if (warrior == null)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            warrior.Attack(receiver);

            sb.Append($"{attackerName} attacks {receiverName} ");
            sb.Append($"for {attacker.AbilityPoints} hit points! ");

            sb.Append($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} ");
            sb.AppendLine($"HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(healingReceiverName);

            Cleric cleric = healer as Cleric;

            if (cleric == null)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            cleric.Heal(receiver);

            sb.Append($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! ");
            sb.AppendLine($"{receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var aliveCharacters = this.characters.Where(c => c.IsAlive);

            foreach (var character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;

                character.Rest();

                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (aliveCharacters.Count() == 1 || aliveCharacters.Count() == 0)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRounds > 1)
            {
                return true;
            }

            return false;
        }

        private Character GetCharacter(string characterName)
        {
            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
