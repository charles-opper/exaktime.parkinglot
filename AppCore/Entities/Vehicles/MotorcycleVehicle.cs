using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    public class MotorcycleVehicle : Vehicle
    {
        public MotorcycleVehicle()
        {
            // TODO: Inject vehicle configuration
            VehicleType = VehicleType.Motorcycle;
            NumberOfWheels = 2;
        }
    }
}
