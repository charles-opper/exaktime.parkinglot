using ExakTime.ParkingLot.Core.Entities.Vehicles;
using ExakTime.ParkingLot.Core.Interfaces;
using ExakTime.ParkingLot.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ExakTime.ParkingLot.Core.Tests
{
    [TestClass]
    public class ParkingLotCoreTests
    {
        [TestInitialize]
        public void InitializeParkingLot()
        {
            _vehicleFactory = new VehicleFactory();
            var parkingLotFactory = new ParkingLotFactory();

            _testVehicles = new Vehicle[] {
                _vehicleFactory.Create<CompactVehicle>(),
                _vehicleFactory.Create<FullVehicle>(),
                _vehicleFactory.Create<TruckVehicle>(),
                _vehicleFactory.Create<MotorcycleVehicle>(),
                _vehicleFactory.Create<ElectricVehicle>()
            };

            _parkingLot = parkingLotFactory.Create();

            foreach (var vehicle in _testVehicles)
            {
                _parkingLot.ParkVehicle(vehicle);
            }
        }

        [TestMethod]
        public void TotalMoneyCollected_AllVehiclesExpected()
        {
            decimal totalMoneyCollected = 0.00M;
            const decimal expectedTotalMoneyCollected = 96.00M;

            totalMoneyCollected = _parkingLot.GetTotalMoneyCollected();

            Assert.AreEqual(expectedTotalMoneyCollected, totalMoneyCollected);
        }

        [TestMethod]
        public void TotalMoneyCollectedByVehicleType_ExpectedForCompact()
        {
            decimal totalMoneyCollectedForCompact = 0.00M;
            const decimal expectedTotalMoneyCollectedForCompact = 20.00M;

            totalMoneyCollectedForCompact = _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Compact);

            Assert.AreEqual(expectedTotalMoneyCollectedForCompact, totalMoneyCollectedForCompact);
        }

        [TestMethod]
        public void TotalMoneyCollectedByVehicleType_ExpectedForFull()
        {
            decimal totalMoneyCollectedForFull = 0.00M;
            const decimal expectedTotalMoneyCollectedForFull = 22.00M;

            totalMoneyCollectedForFull = _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Full);

            Assert.AreEqual(expectedTotalMoneyCollectedForFull, totalMoneyCollectedForFull);
        }

        [TestMethod]
        public void TotalMoneyCollectedByVehicleType_ExpectedForTruck()
        {
            decimal totalMoneyCollectedForTruck = 0.00M;
            const decimal expectedTotalMoneyCollectedForTruck = 23.00M;

            totalMoneyCollectedForTruck = _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Truck);

            Assert.AreEqual(expectedTotalMoneyCollectedForTruck, totalMoneyCollectedForTruck);
        }

        [TestMethod]
        public void TotalMoneyCollectedByVehicleType_ExpectedForMotorcycle()
        {
            decimal totalMoneyCollectedForMotorcycle = 0.00M;
            const decimal expectedTotalMoneyCollectedForMotorcycle = 10.00M;

            totalMoneyCollectedForMotorcycle = _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Motorcycle);

            Assert.AreEqual(expectedTotalMoneyCollectedForMotorcycle, totalMoneyCollectedForMotorcycle);
        }

        [TestMethod]
        public void TotalMoneyCollectedByVehicleType_ExpectedForElectric()
        {
            decimal totalMoneyCollectedForElectric = 0.00M;
            const decimal expectedTotalMoneyCollectedForElectric = 21.00M;

            totalMoneyCollectedForElectric = _parkingLot.GetTotalMoneyCollectedByVehicleType(VehicleType.Electric);

            Assert.AreEqual(expectedTotalMoneyCollectedForElectric, totalMoneyCollectedForElectric);
        }

        [TestMethod]
        public void List_ExpectedCount()
        {
             int expectedListCount = _testVehicles.Count();

            var list = _parkingLot.List().ToList();

            Assert.AreEqual(expectedListCount, list.Count);
        }

        [TestMethod]
        public void ParkVehicle_Success()
        {
            var vehicle = _vehicleFactory.Create<MotorcycleVehicle>();

            _parkingLot.ParkVehicle(vehicle);

            Assert.IsTrue(_parkingLot.List().Contains(vehicle));
        }

        [TestMethod]
        public void UnParkVehicle_Success()
        {
            var vehicle = _parkingLot.List().First();

            _parkingLot.UnParkVehicle(vehicle.Id);

            Assert.IsFalse(_parkingLot.List().Contains(vehicle));
        }

        private IParkingLot _parkingLot;
        private Vehicle[] _testVehicles;
        private VehicleFactory _vehicleFactory;
    }
}
