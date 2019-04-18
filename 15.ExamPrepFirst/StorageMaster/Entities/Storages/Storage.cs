using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];

            this.FillGarage(vehicles);

            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            int foundFreeSlot = deliveryLocation.AddVehicleToGarage(vehicle);

            this.garage[garageSlot] = null;

            return foundFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int unloadedProductsCount = 0;

            while (!this.IsFull && !vehicle.IsEmpty)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloadedProductsCount++;
            }

            return unloadedProductsCount;
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeSlot = Array.IndexOf(this.garage, null);

            if (freeSlot == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[freeSlot] = vehicle;

            return freeSlot;
        }

        private void FillGarage(IEnumerable<Vehicle> vehicles)
        {
            int i = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[i] = vehicle;
                i++;
            }
        }
    }
}
