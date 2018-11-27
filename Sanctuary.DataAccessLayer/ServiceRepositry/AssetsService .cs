using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Sanctuary.DataAccessLayer.DbContext;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;

namespace Sanctuary.DataAccessLayer.ServiceRepositry
{
    /// <summary>
    /// assets service
    /// </summary>
    public class AssetsService : IAssetsService
    {
        /// <summary>
        /// db context
        /// </summary>
        private readonly SanctuaryDbContext SanctuaryDbContext;
        
        /// <summary>
        /// constructor for asset service
        /// </summary>
        public AssetsService()
        {
            this.SanctuaryDbContext = new SanctuaryDbContext();
        }

        /// <summary>
        /// Create method for new asset creation
        /// </summary>
        /// <param name="assets"></param>
        public void CreateAssets(Assets assets)
        {
            this.SanctuaryDbContext.Assets.Add(assets);
            this.SanctuaryDbContext.SaveChanges();
        }

        /// <summary>
        /// retrive method by asset id
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>
        public Assets GetAssets(int assetid)
        {
            return this.SanctuaryDbContext.Assets.SqlQuery("Select * from Assets where AssetId = @p0", assetid).SingleOrDefault<Assets>();
        }

        /// <summary>
        /// update asset by id
        /// </summary>
        /// <param name="assetid"></param>
        /// <param name="roomprice"></param>
        public async Task<OperationResult> UpdateAssets(Assets asset)
        {
            Assets tempAssets = this.SanctuaryDbContext.Assets.Where(newLocation => (newLocation.LocationId == asset.LocationId && newLocation.RoomType == asset.RoomType)).Single<Assets>();

            List<Booking> bookingdetailsforasset = this.SanctuaryDbContext.Bookings.Where(booking => (booking.Asset_Id == tempAssets.AssetId) && (booking.BookingToDate > new DateTime()) && (booking.IsDelete == false)).ToList<Booking>();

            int activeRoomCount = 0;
            foreach(Booking booking in bookingdetailsforasset)
            {
                activeRoomCount += booking.NoOfRooms;
            }

            if(activeRoomCount>=asset.NoOfRooms)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Unable to update assets since there are active bookings"
                };
            }

            //Assets tempAssets = this.SanctuaryDbContext.Assets.Where(newLocation => (newLocation.LocationId == asset.LocationId && newLocation.RoomType == asset.RoomType)).Single<Assets>();

            tempAssets.RoomPrice = asset.RoomPrice;
            tempAssets.NoOfRooms = asset.NoOfRooms;
           
            await this.SanctuaryDbContext.SaveChangesAsync();
            return new OperationResult()
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Updated Successfully"
            };
        }
        /// <summary>
        /// delete a asset from database
        /// </summary>
        /// <param name="assetid"></param>


        public async Task<OperationResult> DeleteAssets(string roomType, int locationId)
        {
            Assets tempAssets = this.SanctuaryDbContext.Assets.Where(delasset => (delasset.LocationId == locationId && delasset.RoomType == roomType)).Single<Assets>();
            tempAssets.IsDelete = true;
            this.SanctuaryDbContext.Entry(tempAssets).CurrentValues.SetValues(tempAssets);
            await this.SanctuaryDbContext.SaveChangesAsync();
            return new OperationResult()
            {
                Status = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Deleted Successfully"
            };
        }


        public async Task<OperationResult> GetLocationNamesAssets(string countryName)
        {
            var locationCity = this.SanctuaryDbContext.Locations.Where(location => location.LocationCountry.Equals(countryName)).Select(location => location).ToList();
               
            return new OperationResult()
            {
                Status = true,
                StatusCode = HttpStatusCode.Found,
                Message = "Location Found",
                Result = locationCity
            };
        }

        public async Task<OperationResult> GetAllAssets()
        {
            try
            {
                List<Assets> assets = SanctuaryDbContext.Assets.ToList<Assets>();
                return new OperationResult()
                {
                    Message = "All assets details are fetched",
                    StatusCode = HttpStatusCode.Found,
                    Status = true,
                    Result = assets
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Message = "No assets found",
                    StatusCode = HttpStatusCode.NotFound,
                    Status = false,
                };
            }
        }
    }
}
