using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExakTime.ParkingLot.AngularUI.Models
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            TotalMoneyCollectedByVehicleType = new Dictionary<string, decimal>();
            Vehicles = new List<Vehicle>();
        }

        public decimal TotalMoneyCollected { get; set; }

        public Dictionary<string, decimal> TotalMoneyCollectedByVehicleType { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
