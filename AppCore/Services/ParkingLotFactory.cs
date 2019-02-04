using ExakTime.ParkingLot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotEntities = ExakTime.ParkingLot.Core.Entities.ParkingLot;

namespace ExakTime.ParkingLot.Core.Services
{
    public class ParkingLotFactory : IParkingLotFactory
    {
        public IParkingLot Create()
        {
            return new ParkingLotEntities.ParkingLot();
        }
    }
}
