using Sanctuary.DataAccessLayer.IServiceRepositry;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sanctuary.Entities;

namespace Sanctuary.BusinessLayerTest.FakeDataLayer
{

    /// <summary>
    /// fake locationService for CRUD operations
    /// </summary>
    public class FakeLocationService : ILocationService
    {
        /// <summary>
        /// List of locations for performing CRUD operations
        /// </summary>
        List<Location> locations = new List<Location>()
        {
            new Location() { LocationId = 1, LocationCity = "Melbourne", LocationCountry = "Austrailia" },
            new Location() { LocationId = 2, LocationCity = "Sydney", LocationCountry = "Austrailia" },
            new Location() { LocationId = 3, LocationCity = "Brisbane", LocationCountry = "Austrailia" },
            new Location() { LocationId = 4, LocationCity = "Auckland", LocationCountry = "New Zealand" },
            new Location() { LocationId = 5, LocationCity = "Nelson", LocationCountry = "New Zealand" },
            new Location() { LocationId = 6, LocationCity = "Napier", LocationCountry = "New Zealand" },
        };

        /// <summary>
        /// fake method to create a new location
        /// </summary>
        /// <param name="user">user</param>
        public async Task<OperationResult> AddLocation(Location location)
        {
            OperationResult result = new OperationResult()
            {
                Status = true,
            };
            return result;
        }


        /// <summary>
        /// fake method to delete a particular location with location id
        /// </summary>
        /// <param name="locationId">location id</param>
        public async Task<OperationResult> DeleteLocation(int locationId)
        {
            foreach(Location location in locations)
            {
                if(location.LocationId == locationId)
                {
                    return new OperationResult()
                    {
                        Status = true
                    };
                }
            }
            return new OperationResult()
            {
                Status = false
            };
        }


        /// <summary>
        /// fake method to fetch a particular location with location id
        /// </summary>
        /// <param name="locationId">location id</param>
        public async Task<OperationResult> FetchLocation(int locationId)
        {
            foreach (Location location in locations)
            {
                if (location.LocationId == locationId)
                {
                    return new OperationResult()
                    {
                        Status = true
                    };
                }
            }
            return new OperationResult()
            {
                Status = false
            };
        }


        /// <summary>
        /// fake method to update a particular location 
        /// </summary>
        /// <param name="location">location</param>
        public async Task<OperationResult> UpdateLocation(Location location)
        {
            foreach (Location tempLocation in locations)
            {
                if (tempLocation.LocationId == location.LocationId)
                {
                    return new OperationResult()
                    {
                        Status = true
                    };
                }
            }
            return new OperationResult()
            {
                Status = false
            };
        }
    }
}
