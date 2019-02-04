using ExakTime.ParkingLot.Core.Entities.Vehicles;
using ExakTime.ParkingLot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.ParkingLot
{
    /// <summary>
    /// The parking lot class used for managing parking of vehicles.
    /// </summary>
    public class ParkingLot : IParkingLot
    {
        /// <summary>
        /// Get total money collected for all vehicles.
        /// </summary>
        /// <returns>A decimal value representing the total money collected.</returns>
        public decimal GetTotalMoneyCollected()
        {
            decimal totalMoneyCollected = 0.00M;

            _parkedVehicles.Select(v => v.VehicleType).Distinct().ToList()
                .ForEach(vt => totalMoneyCollected += GetTotalMoneyCollectedByVehicleType(vt));

            return totalMoneyCollected;
        }

        /// <summary>
        /// Get total money collected by vehicle type.
        /// </summary>
        /// <param name="vehicleType">The vehicle type.</param>
        /// <returns>A decimal value representing the total money collected for the vehicle type.</returns>
        public decimal GetTotalMoneyCollectedByVehicleType(VehicleType vehicleType)
        {
            var vehicles = _parkedVehicles.Where(v => v.VehicleType == vehicleType).ToList();

            decimal totalWheelAmt = 0.00M;
            decimal totalSurchargeAmt = 0.00M;
            vehicles.ForEach(v =>
            {
                totalWheelAmt += v.NumberOfWheels * WheelRate;
                totalSurchargeAmt += v.Surcharge;
            });

            return totalWheelAmt + totalSurchargeAmt;
        }

        /// <summary>
        /// List all vehicles in the parking lot.
        /// </summary>
        /// <returns>A list of all vehicles in the parking lot.</returns>
        public IEnumerable<Vehicle> List()
        {
            return _parkedVehicles;
        }

        /// <summary>
        /// Park a vehicle in the parking lot.
        /// </summary>
        /// <param name="vehicle">The vehicle to be parked.</param>
        public void ParkVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("vehicle");
            }

            _parkedVehicles.Add(vehicle);
        }

        /// <summary>
        /// Unpark a vehicle from the parking lot.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to be unparked.</param>
        /// <returns>The removed vehicle instance.</returns>
        public Vehicle UnParkVehicle(int vehicleId)
        {
            if (vehicleId <= 0)
            {
                throw new ArgumentException("Invalid value for vehicleId");
            }

            var vehicle = _parkedVehicles.Where(v => v.Id == vehicleId).FirstOrDefault();
            if (vehicle != null)
            {
                _parkedVehicles.Remove(vehicle);
            }

            return vehicle;
        }

        private List<Vehicle> _parkedVehicles = new List<Vehicle>();

        /// <summary>
        /// The wheel rate for total money collected. 
        /// </summary>
        // TODO: WheelRate should be loaded at runtime instead of hard coding.
        private static readonly decimal WheelRate = 5.00M;
    }
}
