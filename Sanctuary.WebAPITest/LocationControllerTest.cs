using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanctuary.ApiControllers;
using Sanctuary.BusinessLayerTest.FakeBusinessLayer;
using Sanctuary.BusinessLayerTest.FakeDataLayer;
using Sanctuary.Entities;

namespace Sanctuary.WebAPITest
{
    [TestClass]
    public class LocationControllerTest
    {
        /// <summary>
        /// interface of location controller
        /// </summary>
        LocationController locationController;

        /// <summary>
        /// Constructor for the class location controller test class
        /// </summary>
        public LocationControllerTest()
        {
            locationController = new LocationController(new FakeLocationManager(new FakeLocationService()));
        }


        #region Unit test methods for GetUser() method

        /// <summary>
        /// Unit test method for add a location detail for valid condition
        /// </summary>
        [TestMethod]
        public void LocationController_AddLocation_ValidTest()
        {
            var result = locationController.AddLocation(new TblLocation()
            {
                LocationId = 10,
                LocationCity = "Queenstown",
                LocationCountry = "New Zealand"
            }).Result;
            Assert.IsTrue(result.Status);
        }

        /// <summary>
        /// Unit test method for add a location detail for invalid location id
        /// </summary>
        [TestMethod]
        public void LocationController_AddLocation_InvalidId_Test()
        {
            var result = locationController.AddLocation(new TblLocation()).Result;
            Assert.IsFalse(result.Status);
        }

        /// <summary>
        /// Unit test method for add a location detail for invalid location city
        /// </summary>
        [TestMethod]
        public void LocationController_AddLocation_InvalidLocationCity_Test()
        {
            var result = locationController.AddLocation(new TblLocation()).Result;
            Assert.IsFalse(result.Status);

            result = locationController.AddLocation(new TblLocation() { LocationId = 2, LocationCity = "" }).Result;
            Assert.IsFalse(result.Status);

        }

        /// <summary>
        /// Unit test method for add a location detail for invalid location country
        /// </summary>
        [TestMethod]
        public void LocationController_AddLocation_InvalidLocationCountry_Test()
        {
            var result = locationController.AddLocation(new TblLocation()).Result;
            Assert.IsFalse(result.Status);

            result = locationController.AddLocation(new TblLocation() { LocationId = 2, LocationCity = "Brisbane" }).Result;
            Assert.IsFalse(result.Status);

            result = locationController.AddLocation(new TblLocation() { LocationId = 2, LocationCity = "Brisbane", LocationCountry = "" }).Result;
            Assert.IsFalse(result.Status);
        }

        #endregion
    }
}
