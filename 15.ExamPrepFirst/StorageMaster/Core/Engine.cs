using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandArgs = command
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandType = commandArgs[0];
                    string[] parameters = commandArgs.Skip(1).ToArray();

                    string type = string.Empty;
                    string storageName = string.Empty;
                    int garageSlot;

                    switch (commandType)
                    {
                        case "AddProduct":
                            type = parameters[0];
                            double price = double.Parse(parameters[1]);
                            Console.WriteLine(this.storageMaster.AddProduct(type, 
                                price));
                            break;

                        case "RegisterStorage":
                            type = parameters[0];
                            string name = parameters[1];
                            Console.WriteLine(this.storageMaster
                                .RegisterStorage(type, name));
                            break;

                        case "SelectVehicle":
                            storageName = parameters[0];
                            garageSlot = int.Parse(parameters[1]);
                            Console.WriteLine(this.storageMaster
                                .SelectVehicle(storageName, garageSlot));
                            break;

                        case "LoadVehicle":
                            Console.WriteLine(this.storageMaster
                                .LoadVehicle(parameters));
                            break;

                        case "SendVehicleTo":
                            string sourceName = parameters[0];
                            int sourceGarageSlot = int.Parse(parameters[1]);
                            string destinationName = parameters[2];
                            Console.WriteLine(this.storageMaster
                                .SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                            break;

                        case "UnloadVehicle":
                            storageName = parameters[0];
                            garageSlot = int.Parse(parameters[1]);
                            Console.WriteLine(this.storageMaster
                                .UnloadVehicle(storageName, garageSlot));
                            break;

                        case "GetStorageStatus":
                            storageName = parameters[0];
                            Console.WriteLine(this.storageMaster
                                .GetStorageStatus(storageName));
                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }
    }
}
