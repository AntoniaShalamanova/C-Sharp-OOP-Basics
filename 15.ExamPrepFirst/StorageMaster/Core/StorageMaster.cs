using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> productPool;
        private ProductFactory productFactory;
        private Dictionary<string, Storage> storageRegistry;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productPool = new Dictionary<string, Stack<Product>>();
            this.productFactory = new ProductFactory();
            this.storageRegistry = new Dictionary<string, Storage>();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            if (!this.productPool.ContainsKey(type))
            {
                this.productPool[type] = new Stack<Product>();
            }

            this.productPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(name, storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry[storageName];

            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.productPool.ContainsKey(productName) ||
                    this.productPool[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.productPool[productName].Pop();

                this.currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = this.storageRegistry[sourceName];
            Storage destinationStorage = this.storageRegistry[destinationName];

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage
                .SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry[storageName];

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();

            Storage storage = this.storageRegistry[storageName];

            double productsWeightSum = storage.Products.Sum(p => p.Weight);

            var productsAndCount = new Dictionary<string, int>();

            foreach (var product in storage.Products)
            {
                string productType = product.GetType().Name;

                if (!productsAndCount.ContainsKey(productType))
                {
                    productsAndCount.Add(productType, 0);
                }

                productsAndCount[productType]++;
            }

            string[] sortedProducts = productsAndCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(kvp=>$"{kvp.Key} ({kvp.Value})")
                .ToArray();

            sb.AppendLine($"Stock ({productsWeightSum}/{storage.Capacity}): [{string.Join(", ", sortedProducts)}]");

            string[] garageToString = storage.Garage.
                Select(g => g == null ? "empty" : g.GetType().Name)
                .ToArray();

            sb.Append($"Garage: [{string.Join("|", garageToString)}]");

            return sb.ToString();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storageRegistry
                .Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                double totalMoney = storage.Products.Sum(p => p.Price);

                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString();
        }
    }
}
