using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public void Run()
        { 
            string command = Console.ReadLine();

            while (!string.IsNullOrEmpty(command) && !this.dungeonMaster.IsGameOver())
            {
                try
                {
                    string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandType = commandArgs[0];

                    commandArgs = commandArgs.Skip(1).ToArray();

                    switch (commandType)
                    {
                        case "JoinParty":
                            Console.WriteLine(this.dungeonMaster.JoinParty(commandArgs));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(this.dungeonMaster.AddItemToPool(commandArgs));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(this.dungeonMaster.PickUpItem(commandArgs));
                            break;
                        case "UseItem":
                            Console.WriteLine(this.dungeonMaster.UseItem(commandArgs));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(this.dungeonMaster.UseItemOn(commandArgs));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(this.dungeonMaster.GiveCharacterItem(commandArgs));
                            break;
                        case "GetStats":
                            Console.WriteLine(this.dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(this.dungeonMaster.Attack(commandArgs));
                            break;
                        case "Heal":
                            Console.WriteLine(this.dungeonMaster.Heal(commandArgs));
                            break;
                        case "EndTurn":
                            Console.WriteLine(this.dungeonMaster.EndTurn(commandArgs));
                            break;
                        case "IsGameOver":
                            Console.WriteLine(this.dungeonMaster.IsGameOver());
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
