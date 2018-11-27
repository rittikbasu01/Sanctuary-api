using System;
using Sanctuary.DataAccessLayer.DbContext;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Sanctuary.DataAccessLayer.ServiceRepositry
{
    public class LocationService : ILocationService
    {
        /// <summary>
        /// DbContext class reference for the database 
        /// </summary>
        private readonly SanctuaryDbContext SanctuaryDbContext;

        /// <summary>
        /// Cunstructor for the LocationService class
        /// </summary>
        /// <param name="SanctuaryDbContext"></param>
        public LocationService()
        {
            this.SanctuaryDbContext = new SanctuaryDbContext();
        }

        public async Task<OperationResult> AddLocation(Location location)
        {
            var locationDetails = (from locations in SanctuaryDbContext.Locations
                                   where locations.LocationCity.Equals(location.LocationCity)
                                   where locations.LocationCountry.Equals(location.LocationCountry)
                                   select locations).ToList();
           
            if (locationDetails.Count >= 1)
            {
                return new OperationResult()
                {
                    Message = "Location already exists",
                    Status = false,
                    StatusCode = HttpStatusCode.Found,
                    Result = null


                };
            }

            this.SanctuaryDbContext.Locations.Add(location);
            await this.SanctuaryDbContext.SaveChangesAsync();

            int? locationId = (from locations in SanctuaryDbContext.Locations
                               where locations.LocationCity.Equals(location.LocationCity)
                               where locations.LocationCountry.Equals(location.LocationCountry)
                               select locations.LocationId).SingleOrDefault();

            if (locationId.HasValue)
            {
                List<Assets> assets = new List<Assets>()
                    {
                        new Assets(){ LocationId=locationId.Value,RoomType="Meeting",RoomPrice=200,NoOfRooms=5},

                        new Assets(){ LocationId=locationId.Value,RoomType="Accommodation",RoomPrice=350,NoOfRooms=5},

                        new Assets(){ LocationId=locationId.Value,RoomType="Amphitheatre",RoomPrice=1000,NoOfRooms=1},

                        new Assets(){ LocationId=locationId.Value,RoomType="Auditorium",RoomPrice=750,NoOfRooms=5},

                        new Assets(){ LocationId=locationId.Value,RoomType="Conference",RoomPrice=500,NoOfRooms=5},

                    };
                SanctuaryDbContext.Assets.AddRange(assets);
                SanctuaryDbContext.SaveChanges();

            }

            return new OperationResult()
            {
                StatusCode = HttpStatusCode.Created,
                Status = true,
                Message = "New Location added successfully"
            };


        }

        /// <summary>
        /// Method For deleting a particular location in the locations table
        /// </summary>
        /// <param name="locationId"></param>
        public async Task<OperationResult> DeleteLocation(int locationId)
        {
            Location tempLocation = this.SanctuaryDbContext.Locations.Where(newLocation => (newLocation.LocationId == locationId && newLocation.IsDelete == false)).Single<Location>();
            if (tempLocation == null)
            {
                return new OperationResult()
                {
                    Message = "Location does not exists",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Status = false
                };
            }
            tempLocation.IsDelete = true;
            this.SanctuaryDbContext.Entry(tempLocation).CurrentValues.SetValues(tempLocation);
            await this.SanctuaryDbContext.SaveChangesAsync();
            return new OperationResult()
            {
                Message = "Location remove successfully",
                StatusCode = HttpStatusCode.OK,
                Status = true
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public async Task<OperationResult> FetchLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public async Task<OperationResult> UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> GetAllLocation()
        {
            var locationDetails = from location in SanctuaryDbContext.Locations
                                  select new { location.LocationCity, location.LocationCountry };
            return new OperationResult()
            {
                Message = "Locations found Successfuly",
                StatusCode = HttpStatusCode.Found,
                Status = true,
                Result = locationDetails

            };

        }


        public async Task<OperationResult> GetLocationCityNames(string locationCountryName)
        {
            var locationCityNames = from location in SanctuaryDbContext.Locations
                                    where location.LocationCountry.Equals(locationCountryName)
                                    select location.LocationCity;



            return new OperationResult()
            {
                Message = "Locations found Successfuly",
                StatusCode = HttpStatusCode.Found,
                Status = true,
                Result = locationCityNames

            };
        }
    }
}
