using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    public class FullVehicle : Vehicle
    {
        public FullVehicle()
        {
            // TODO: Inject vehicle configuration
            VehicleType = VehicleType.Full;
            NumberOfWheels = 4;
            Surcharge = 2.00M;
        }
    }
}
