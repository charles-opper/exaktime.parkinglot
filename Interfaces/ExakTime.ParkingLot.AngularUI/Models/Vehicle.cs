using Entities = ExakTime.ParkingLot.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExakTime.ParkingLot.AngularUI.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        public Vehicle(Entities.Vehicles.Vehicle entity)
        {
            Id = entity.Id;
            VehicleType = entity.VehicleType.ToString();
            NumberOfWheels = entity.NumberOfWheels;
            Surcharge = entity.Surcharge;
        }

        public int? Id { get; set; }

        public string VehicleType { get; set; }

        public int? NumberOfWheels { get; set; }

        public decimal? Surcharge { get; set; }
    }
}
