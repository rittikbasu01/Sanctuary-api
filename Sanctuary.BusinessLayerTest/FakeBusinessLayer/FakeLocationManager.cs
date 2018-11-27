using IBusinessLayer;
using System;
using System.Threading.Tasks;
using Sanctuary.Entities;
using Sanctuary.DataAccessLayer.IServiceRepositry;

namespace Sanctuary.BusinessLayerTest.FakeBusinessLayer
{

    /// <summary>
    /// manages fake user services
    /// </summary>
    public class FakeLocationManager : ILocationManager
    {
        /// <summary>
        /// interface of location service
        /// </summary>
        public ILocationService locationService;

        /// <summary>
        /// Constructor of fake location manager class
        /// </summary>
        /// /// <param name="fakeLocationService">Fake data layer object</param>
        public FakeLocationManager(ILocationService fakeLocationService)
        {
            locationService = fakeLocationService;
        }

        /// <summary>
        /// Method for creating user
        /// </summary>
        /// <param name="location">Tbllocation</param>
        /// <returns>Result class object</returns>
        public async Task<OperationResult> AddLocation(Location location)
        {
            if(location == null)
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            if(location.LocationId == 0)
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            if(string.IsNullOrWhiteSpace(location.LocationCity))
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            if (string.IsNullOrWhiteSpace(location.LocationCountry))
            {
                return new OperationResult()
                {
                    Status = false
                };
            }

            return await locationService.AddLocation(location);

        }

        /// <summary>
        /// Fake method for deleting the location details from fake repository with location id
        /// </summary>
        /// <returns></returns>
        public Task<OperationResult> DeleteLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fake method for fetching the location details from fake repository with location id
        /// </summary>
        /// <returns></returns>
        public Task<OperationResult> FetchLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fake method for updating the location details from fake repository with location
        /// </summary>
        /// <returns></returns>
        public Task<OperationResult> UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
