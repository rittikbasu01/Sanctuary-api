using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using IBusinessLayer;
using Sanctuary.Entities;
using System.Threading.Tasks;

namespace Sanctuary.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationController : ApiController
    {
        private readonly ILocationManager locationManager;

        public LocationController()
        {

        }
       
        public LocationController(ILocationManager locationManager)
        {
            this.locationManager = locationManager;
        }
        [HttpPost]
        public async Task<OperationResult> AddLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                return await this.locationManager.AddLocation(location);
            }
            return new OperationResult()
            {
                Status = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Bad Request",
                Result = ""
            };
        }

        public async Task<OperationResult> FetchLocation(int location)
        {
            return await locationManager.FetchLocation(location);
        }
        [HttpGet]
        [AllowAnonymous]
        /// <summary>
        /// Get the location city names
        /// </summary>
        /// <param name="locationCountryName"></param>
        /// <returns></returns>
        public async Task<OperationResult> GetLocationCityNames(string locationCountryName)
        {
            if(locationCountryName!=null)
                return await locationManager.GetLocationCityNames(locationCountryName);

            return new OperationResult()
            {
                Status = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Bad Request",
                Result = ""
            };
        }

       
    }
}
