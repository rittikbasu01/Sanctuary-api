using System;
using System.Threading.Tasks;
using IBusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;

namespace BusinessLayer
{
  public  class LocationManager:ILocationManager
    {
        private readonly ILocationService locationService;
        public LocationManager(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        /// <summary>
        /// Add a new Location
        /// </summary>
        /// <param name="location"></param>
        public async Task<OperationResult> AddLocation(Location location)
        {
            return await this.locationService.AddLocation(location);
        }

        /// <summary>
        /// Delete a location by licationId
        /// </summary>
        /// <param name="locationId"></param>
        public async Task<OperationResult> DeleteLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch location details by locationId
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public async Task<OperationResult> FetchLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update location details 
        /// </summary>
        /// <param name="location"></param>
        public async Task<OperationResult> UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> GetLocationCityNames(string locationCountryName)
        {
           return await this.locationService.GetLocationCityNames(locationCountryName);
        }
    }
}
