using ExakTime.ParkingLot.Core.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Interfaces
{
    public interface IParkingLot
    {
        decimal GetTotalMoneyCollected();

        decimal GetTotalMoneyCollectedByVehicleType(VehicleType vehicleType);

        IEnumerable<Vehicle> List();

        void ParkVehicle(Vehicle vehicle);

        Vehicle UnParkVehicle(int vehicleId);
    }
}
