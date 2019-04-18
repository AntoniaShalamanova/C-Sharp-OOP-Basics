using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Car
    {
        public string model { get; set; }
        public double fuelAmount { get; set; }
        public double fuelConsumption { get; set; }
        public double traveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumption = fuelConsumption;
            this.traveledDistance = 0;
        }

        public void MoveCar(double km)
        {
            double neededFuel = km * this.fuelConsumption;

            if (neededFuel <= this.fuelAmount)
            {
                this.fuelAmount -= neededFuel;
                this.traveledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
