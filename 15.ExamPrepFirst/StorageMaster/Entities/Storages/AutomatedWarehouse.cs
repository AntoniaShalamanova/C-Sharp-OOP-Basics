using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;
        private static Vehicle[] DefaultVehicles = new Vehicle[] 
        {
            new Truck(),
        };

        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, DefaultVehicles)
        {
        }
    }
}
