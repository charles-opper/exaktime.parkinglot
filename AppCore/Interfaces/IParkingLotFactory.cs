using System;
using System.Collections.Generic;
using System.Text;

namespace ExakTime.ParkingLot.Core.Interfaces
{
    public interface IParkingLotFactory
    {
        IParkingLot Create();
    }
}
