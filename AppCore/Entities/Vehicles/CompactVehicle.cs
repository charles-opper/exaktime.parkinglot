using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    public class CompactVehicle : Vehicle
    {
        public CompactVehicle()
        {
            // TODO: Inject vehicle configuration
            VehicleType = VehicleType.Compact;
            NumberOfWheels = 4;
        }
    }
}
