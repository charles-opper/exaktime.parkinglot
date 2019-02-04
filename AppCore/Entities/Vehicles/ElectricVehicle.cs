using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    public class ElectricVehicle : Vehicle
    {
        public ElectricVehicle()
        {
            // TODO: Inject vehicle configuration
            VehicleType = VehicleType.Electric;
            NumberOfWheels = 4;
            Surcharge = 1.00M;
        }
    }
}
