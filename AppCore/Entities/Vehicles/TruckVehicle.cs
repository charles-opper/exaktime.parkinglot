using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Entities.Vehicles
{
    public class TruckVehicle : Vehicle
    {
        public TruckVehicle()
        {
            // TODO: Inject vehicle configuration
            VehicleType = VehicleType.Truck;
            NumberOfWheels = 4;
            Surcharge = 3.00M;
        }
    }
}
