using Sanctuary.DataAccessLayer.DbContext;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Globalization;

namespace Sanctuary.DataAccessLayer.ServiceRepositry
{
    /// <summary>
    /// BookingService which does crud operations on Booking table
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// Db context class for the database
        /// </summary>
        private readonly SanctuaryDbContext SanctuaryDbContext;


        /// <summary>
        /// Constructor of the UserService
        /// </summary>
        public BookingService(SanctuaryDbContext sanctuaryDbContext)
        {
            this.SanctuaryDbContext = sanctuaryDbContext;
        }

        /// <summary>
        /// gets all the bookings
        /// </summary>
        /// <returns>operational result which contains list of bookings</returns>
        public async Task<OperationResult> getBookings()
        {
            try
            {
                List<Booking> bookings = SanctuaryDbContext.Bookings.ToList<Booking>();
                return new OperationResult()
                {
                    Message = "All booking details are fetched",
                    StatusCode = HttpStatusCode.Found,
                    Status = true,
                    Result = bookings
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Message = "No bookings found",
                    StatusCode = HttpStatusCode.NotFound,
                    Status = false,
                };
            }
        }

        /// <summary>
        /// creates a new booking
        /// </summary>
        /// <param name="booking"></param>
        public async Task<OperationResult> CreateBooking(Booking booking)
        {
            try
            {
                SanctuaryDbContext.Bookings.Add(booking);

                UserAmount tempUserAmountDetails = this.SanctuaryDbContext.UserAmount.Where(userAmount => userAmount.User_Email.Equals(booking.User_Email)).Single<UserAmount>();
                tempUserAmountDetails.TotalAmount += booking.Amount;

                this.SanctuaryDbContext.SaveChanges();
                return new OperationResult()
                {
                    Message = "Created Sucessfully",
                    StatusCode = HttpStatusCode.Created,
                    Status = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult()
                {
                    Message = "",
                    StatusCode = HttpStatusCode.BadRequest,
                    Status = false
                };
            }

        }

        /// <summary>
        /// get the booking by Booking Id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpeartionResult</returns>
        public async Task<OperationResult> GetBooking(int bookingId)
        {
            try
            {
                Booking booking = SanctuaryDbContext.Bookings.Find(bookingId);
                return new OperationResult()
                {
                    Message = "Booking details for the particular booking Id found",
                    StatusCode = HttpStatusCode.Found,
                    Status = true,
                    Result = booking
                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Message = "Booking details for the given booking Id not found",
                    StatusCode = HttpStatusCode.NotFound,
                    Status = false,

                };
            }
        }

        /// <summary>
        /// get a users bookings
        /// </summary>
        /// <param name="email"></param>
        /// <returns>operational result</returns>
        public async Task<OperationResult> GetBooking(string email)
        {
            return new OperationResult()
            {
                Message = "user previous bookings",
                StatusCode = HttpStatusCode.Found,
                Status = true,
                Result = this.SanctuaryDbContext.Bookings.Where(booking => booking.User_Email == email).OrderByDescending(booking => booking.BookingId).ToList<Booking>()
            };
    }

    /// <summary>
    /// get the avilability of rooms for assets for a given period of time.
    /// </summary>
    /// <param name="BookingFromDate"></param>
    /// <param name="BookingToDate"></param>
    /// <param name="location"></param>s
    /// <returns>name="AvailableRoomDetails"</returns>
    public async Task<OperationResult> GetAvailabilityOfRoomsByDate(string bookingFromDate, string bookingToDate, string locationCity)
        {
            DateTime bookingDateFrom = DateTime.ParseExact(bookingFromDate, "d", CultureInfo.InvariantCulture);
            DateTime bookingDateTo = DateTime.ParseExact(bookingToDate, "d", CultureInfo.InvariantCulture);
            //list of details of room available for the required time period
            List<AvailableRoomDetail> availableroomdetails = new List<AvailableRoomDetail>();

            //query to fetch list of assets at a required location
            var assetsAtLocation = from asset in SanctuaryDbContext.Assets
                                   where asset.Location.LocationCity == locationCity
                                   select asset;

            //searching for available rooms for each asset at the given  location
            foreach (Assets asset in assetsAtLocation)
            {
                AvailableRoomDetail availableroomdetail = new AvailableRoomDetail();
                int availableRooms = asset.NoOfRooms;

                //query to find list of booking details for the given asset
                List<Booking> bookingdetailsforasset = this.SanctuaryDbContext.Bookings.Where(booking => (booking.Asset_Id == asset.AssetId) && (booking.IsDelete == false)).ToList<Booking>();
                foreach (Booking booking in bookingdetailsforasset)
                {
                    //condtion for checking availibilty of rooms for asset for the given period
                    if (!((DateTime.Compare(Convert.ToDateTime(booking.BookingFromDate), bookingDateFrom) > 0 && DateTime.Compare(Convert.ToDateTime(booking.BookingFromDate), bookingDateTo) > 0) ||
                      (DateTime.Compare(Convert.ToDateTime(booking.BookingToDate), bookingDateFrom) < 0 && DateTime.Compare(Convert.ToDateTime(booking.BookingToDate), bookingDateTo) < 0)) && booking.IsDelete == false)
                    
                    {
                        availableRooms = availableRooms - booking.NoOfRooms;
                    }
                }

                availableroomdetail.AssetId = asset.AssetId;
                availableroomdetail.RoomType = asset.RoomType;
                availableroomdetail.NoOfAvailableRooms = availableRooms;
                availableroomdetail.RoomPrice = asset.RoomPrice;

                availableroomdetails.Add(availableroomdetail);
            }

            return new OperationResult()
            {
                Message = "rooms availability at the given location found",
                StatusCode = HttpStatusCode.Found,
                Status = true,
                Result = availableroomdetails
            };


        }

        /// <summary>
        /// cancel a booking using booking id
        /// </summary>
        /// <param name="bookingId"></param>
        public async Task<OperationResult> CancelBooking(int bookingId)
        {
            try
            {
                Booking booking = SanctuaryDbContext.Bookings.Find(bookingId);
                booking.IsDelete = true;

                UserAmount tempUserAmountDetails = this.SanctuaryDbContext.UserAmount.Where(userAmount => userAmount.User_Email.Equals(booking.User_Email)).Single<UserAmount>();
                tempUserAmountDetails.TotalAmount -= booking.Amount;

                SanctuaryDbContext.SaveChanges();
                return new OperationResult()
                {
                    Message = "Booking cancelled",
                    StatusCode = HttpStatusCode.OK,
                    Status = true,

                };
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Message = "Booking not cancelled",
                    StatusCode = HttpStatusCode.NotFound,
                    Status = false
                };
            }
        }
    }
}
