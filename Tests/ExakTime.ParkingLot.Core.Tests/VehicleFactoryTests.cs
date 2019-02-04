using ExakTime.ParkingLot.Core.Entities.Vehicles;
using ExakTime.ParkingLot.Core.Interfaces;
using ExakTime.ParkingLot.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExakTime.ParkingLot.Core.Tests
{
    [TestClass]
    public class VehicleFactoryTests
    {
        [ClassInitialize]
        public static void InitializeVehicleFactory(TestContext testContext)
        {
            VehicleFactory = new VehicleFactory();
        }

        [TestMethod]
        public void Create_Compact_ValidVehicle()
        {
            var vehicle = VehicleFactory.Create<CompactVehicle>();

            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Id > 0);
            Assert.AreEqual(VehicleType.Compact, vehicle.VehicleType);
        }

        [TestMethod]
        public void Create_Electric_ValidVehicle()
        {
            var vehicle = VehicleFactory.Create<ElectricVehicle>();

            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Id > 0);
            Assert.AreEqual(VehicleType.Electric, vehicle.VehicleType);
        }

        [TestMethod]
        public void Create_Full_ValidVehicle()
        {
            var vehicle = VehicleFactory.Create<FullVehicle>();

            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Id > 0);
            Assert.AreEqual(VehicleType.Full, vehicle.VehicleType);
        }

        [TestMethod]
        public void Create_Motorcycle_ValidVehicle()
        {
            var vehicle = VehicleFactory.Create<MotorcycleVehicle>();

            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Id > 0);
            Assert.AreEqual(VehicleType.Motorcycle, vehicle.VehicleType);
        }

        [TestMethod]
        public void Create_Truck_ValidVehicle()
        {
            var vehicle = VehicleFactory.Create<TruckVehicle>();

            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Id > 0);
            Assert.AreEqual(VehicleType.Truck, vehicle.VehicleType);
        }

        private static IVehicleFactory VehicleFactory;
    }
}
