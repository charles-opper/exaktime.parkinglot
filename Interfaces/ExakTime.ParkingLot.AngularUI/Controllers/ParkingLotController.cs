using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExakTime.ParkingLot.Core.Entities.Vehicles;
using ExakTime.ParkingLot.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ExakTime.ParkingLot.AngularUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        public ParkingLotController(IMemoryCache memoryCache, IParkingLotFactory parkingLotFactory, IVehicleFactory vehicleFactory)
        {
            _memoryCache = memoryCache;
            _parkingLotFactory = parkingLotFactory;
            _vehicleFactory = vehicleFactory;

            // Load up some test data using MemoryCache for demonstration
            _parkingLot = _memoryCache.GetOrCreate<IParkingLot>("ParkingLot", entry =>
            {
                var parkingLot = _parkingLotFactory.Create();
                parkingLot.ParkVehicle(_vehicleFactory.Create<CompactVehicle>());
                parkingLot.ParkVehicle(_vehicleFactory.Create<TruckVehicle>());

                return parkingLot;
            });
        }

        // GET: api/ParkingLot
        [HttpGet]
        public Models.ParkingLot Get()
        {
            return BuildParkingLotModel();
        }

        // GET: api/ParkingLot/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Vehicle> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Vehicle Id");
            }

            var vehicle = _parkingLot.List().Where(v => v.Id == id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound(id);
            }

            return vehicle;
        }

        // POST: api/ParkingLot
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Models.Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newVehicle = CreateVehicleForType(vehicle.VehicleType);

                _parkingLot.ParkVehicle(newVehicle);

                return CreatedAtAction(nameof(Get), newVehicle);
            }
            catch (ArgumentException ae)
            {
                return BadRequest($"Invalid Vehicle: { ae.Message }");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Vehicle Id");
            }

            if (!_parkingLot.List().Select(v => v.Id).Contains(id))
            {
                return NotFound(id);
            }

            return _parkingLot.UnParkVehicle(id);
        }


        private Vehicle CreateVehicleForType(string vehicleTypeString)
        {
            Vehicle vehicle = null;

            if (!Enum.TryParse(typeof(VehicleType), vehicleTypeString, out var vehicleType))
            {
                throw new ArgumentException("Invalid Vehicle Type");
            }

            switch (vehicleType)
            {
                case VehicleType.Compact:

                    vehicle = _vehicleFactory.Create<CompactVehicle>();
                    break;

                case VehicleType.Full:

                    vehicle = _vehicleFactory.Create<FullVehicle>();
                    break;

                case VehicleType.Truck:

                    vehicle = _vehicleFactory.Create<TruckVehicle>();
                    break;

                case VehicleType.Motorcycle:

                    vehicle = _vehicleFactory.Create<MotorcycleVehicle>();
                    break;

                case VehicleType.Electric:

                    vehicle = _vehicleFactory.Create<ElectricVehicle>();
                    break;

                default:
                    throw new ArgumentException("Invalid Vehicle Type");
            }

            return vehicle;
        }

        private Models.ParkingLot BuildParkingLotModel()
        {
            var model = new Models.ParkingLot()
            {
                TotalMoneyCollected = _parkingLot.GetTotalMoneyCollected()
            };

            _parkingLot.List().ToList().ForEach(v => model.Vehicles.Add(new Models.Vehicle(v)));

            model.TotalMoneyCollectedByVehicleType[VehicleType.Compact.ToString()] =
                _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Compact);
            model.TotalMoneyCollectedByVehicleType[VehicleType.Electric.ToString()] =
                _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Electric);
            model.TotalMoneyCollectedByVehicleType[VehicleType.Full.ToString()] =
                _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Full);
            model.TotalMoneyCollectedByVehicleType[VehicleType.Motorcycle.ToString()] =
                _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Motorcycle);
            model.TotalMoneyCollectedByVehicleType[VehicleType.Truck.ToString()] =
                _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Truck);

            return model;
        }

        private readonly IParkingLotFactory _parkingLotFactory;
        private readonly IVehicleFactory _vehicleFactory;
        private readonly IMemoryCache _memoryCache;
        private readonly IParkingLot _parkingLot;
    }
}
