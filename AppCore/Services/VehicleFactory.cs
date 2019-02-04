using ExakTime.ParkingLot.Core.Entities.Vehicles;
using ExakTime.ParkingLot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Services
{
    /// <summary>
    /// Factory class for creating a vehicle instance of any derived vehicle type T.
    /// </summary>
    public class VehicleFactory : IVehicleFactory
    {
        /// <summary>
        /// Create a new vehicle instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of vehicle to create.</typeparam>
        /// <returns>A new vehicle of type T.</returns>
        public Vehicle Create<T>() where T : Vehicle, new()
        {
            return new T();
        }
    }
}
