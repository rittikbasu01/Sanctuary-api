using IBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanctuary.BusinessLayerTest.FakeBusinessLayer;
using Sanctuary.BusinessLayerTest.FakeDataLayer;
using Sanctuary.Entities;


namespace Sanctuary.BusinessLayerTest
{
    [TestClass]
    public class LocationManagerTest
    {
        /// <summary>
        /// interface of location manager
        /// </summary>
        ILocationManager locationManager;

        /// <summary>
        /// Constructor for the class locationManagerTest
        /// </summary>
        public LocationManagerTest()
        {
            locationManager = new FakeLocationManager(new FakeLocationService());
        }


        #region Unit test methods for CreateUser() method

        /// <summary>
        /// Unit test method for adding a location with valid data
        /// </summary>
        [TestMethod]
        public void LocationManager_AddLocation_ValidTest()
        {
            var result = locationManager.AddLocation(new Location() { LocationId = 1, LocationCity = "Perth", LocationCountry = "Austrailia" }).Result;
            Assert.IsTrue(result.Status);
        }

        /// <summary>
        /// Unit test method for adding a location with invalid id
        /// </summary>
        [TestMethod]
        public void LocationManager_AddLocation_InvalidId_Test()
        {
            var result = locationManager.AddLocation(new Location() { LocationId = 0 }).Result;
            Assert.IsFalse(result.Status);
        }

        /// <summary>
        /// Unit test method for adding a location with invalid city
        /// </summary>
        [TestMethod]
        public void LocationManager_AddLocation_InvalidCity_Test()
        {
            var result = locationManager.AddLocation(new Location() { LocationId = 1 }).Result;
            Assert.IsFalse(result.Status);

            result = locationManager.AddLocation(new Location() { LocationId = 1, LocationCity = "" }).Result;
            Assert.IsFalse(result.Status);

        }

        /// <summary>
        /// Unit test method for adding a location with invalid country
        /// </summary>
        [TestMethod]
        public void LocationManager_AddLocation_InvalidCountry_Test()
        {
            var result = locationManager.AddLocation(new Location() { LocationId = 1 }).Result;
            Assert.IsFalse(result.Status);

            result = locationManager.AddLocation(new Location() { LocationId = 1, LocationCity = "Perth" }).Result;
            Assert.IsFalse(result.Status);

            result = locationManager.AddLocation(new Location() { LocationId = 1, LocationCity = "Perth", LocationCountry = "" }).Result;
            Assert.IsFalse(result.Status);

        }

        #endregion
    }
}
