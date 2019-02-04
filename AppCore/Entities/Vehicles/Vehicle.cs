using ExakTime.ParkingLot.Core.Services;
using System;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    /// <summary>
    /// A simple enumeration for the vehicle types. 
    /// TODO: Will need to replace this with a type-safe enumeration pattern.
    /// </summary>
    public enum VehicleType
    {
        Compact,
        Full,
        Truck,
        Motorcycle,
        Electric
    }

    /// <summary>
    /// A base class entity implementation for all vehicles.
    /// Each derived class will supply vehicle type specific concrete data/config.
    /// </summary>
    public abstract class Vehicle
    {
        public Vehicle()
        {
            Id = AutoIdGenerator.Instance.GetNextId();
        }

        public int Id { get; protected set; }

        public VehicleType VehicleType { get; protected set; }

        public int NumberOfWheels { get; protected set; }

        public decimal Surcharge { get; protected set; }
    }
}
