using ExakTime.ParkingLot.Core.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle Create<T>() where T : Vehicle, new();
    }
}
