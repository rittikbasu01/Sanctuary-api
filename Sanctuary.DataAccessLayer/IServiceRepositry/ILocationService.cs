using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Entities;

namespace Sanctuary.DataAccessLayer.IServiceRepositry
{
    /// <summary>
    /// Interface for location service
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Method for adding a new location in the Locations table
        /// </summary>
        /// <param name="location"></param>
        Task<OperationResult> AddLocation(Location location);

        /// <summary>
        /// Method for deleting an existing  location  from the Locations table
        /// </summary>
        /// <param name="locationId"></param>
        Task<OperationResult> DeleteLocation(int locationId);

        /// <summary>   
        /// Method for updating a particular Location details 
        /// </summary>
        Task<OperationResult> UpdateLocation(Location location);

        /// <summary>
        /// Fetching a details for particular location
        /// </summary>
        /// <param name="locationId"></param>
        Task<OperationResult> FetchLocation(int locationId);

        /// <summary>
        /// Get the location city names by location country names
        /// </summary>
        /// <param name="locationCountryName"></param>
        /// <returns></returns>
        Task<OperationResult> GetLocationCityNames(string locationCountryName);
        

        
    }
}
