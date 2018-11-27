using IBusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.DataAccessLayer.ServiceRepositry;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookingManager : IBookingManager
    {
        /// <summary>
        /// interface of booking service
        /// </summary>
        private readonly IBookingService BookingService;
        private readonly IUserService UserService = new UserService();
        private readonly IUserAmountService UserAmountService = new UserAmountService();

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="bookingService"></param>
        public BookingManager(IBookingService bookingService)
        {
            this.BookingService = bookingService;
        }

        /// <summary>
        /// gets all the bookings
        /// </summary>
        /// <returns>operational result which contains list of bookings</returns>
        public async Task<OperationResult> getBookings()
        {
            return await this.BookingService.getBookings();
        }

        /// <summary>
        /// create a new booking for given date and location
        /// </summary>
        /// <param name="booking">booking table object</param>
        public async Task<OperationResult> CreateBooking(Booking booking)
        {
            UserAmount userAmountDetails = await this.UserAmountService.GetUserAmount(booking.User_Email);

            if (userAmountDetails != null)
            {
                OperationResult operationResult = await this.UserService.GetUser(booking.User_Email);
                User user = (User)operationResult.Result;

                if ((userAmountDetails.TotalAmount + booking.Amount) >= 20000 && user.LoyaltyTier <= (int)EnumClasses.LoyaltyTier.Platinum)
                {
                    user.LoyaltyTier = (int)EnumClasses.LoyaltyTier.Platinum;
                    await this.UserService.UpdateUser(user);
                }
                else if ((userAmountDetails.TotalAmount + booking.Amount) >= 10000 && user.LoyaltyTier <= (int)EnumClasses.LoyaltyTier.Gold)
                {
                    user.LoyaltyTier = (int)EnumClasses.LoyaltyTier.Gold;
                    await this.UserService.UpdateUser(user);
                }
                else if ((userAmountDetails.TotalAmount + booking.Amount) >= 5000 && user.LoyaltyTier <= (int)EnumClasses.LoyaltyTier.Silver)
                {
                    user.LoyaltyTier = (int)EnumClasses.LoyaltyTier.Silver;
                    await this.UserService.UpdateUser(user);
                }

                return await this.BookingService.CreateBooking(booking);
            }
            else
            {
                return new OperationResult()
                {
                    Message = "User does not exists",
                    StatusCode = HttpStatusCode.BadRequest,
                    Status = false
                };

            }

        }

        /// <summary>
        /// Get the booking using booking id
        /// </summary>
        /// <param name="bookingId">booking id</param>
        public async Task<OperationResult> GetBooking(int bookingId)
        {
            return await BookingService.GetBooking(bookingId);
        }

        /// <summary>
        /// cancel booking by booking id
        /// </summary>
        /// <param name="bookingId">booking id</param>
        public async Task<OperationResult> CancelBooking(int bookingId)
        {
            return await BookingService.CancelBooking(bookingId);
        }

        /// <summary>
        /// Get availability of rooms
        /// </summary>
        /// <param name="bookingFromDate">bookingFromDate</param>
        /// <param name="bookingToDate">bookingToDate</param>
        /// <param name="locationCity">locationCity</param>
        /// <returns></returns>
        public async Task<OperationResult> GetAvailabilityOfRoomsByDate(String bookingFromDate, String bookingToDate, string locationCity)
        {
            return await BookingService.GetAvailabilityOfRoomsByDate(bookingFromDate, bookingToDate, locationCity);
        }

        /// <summary>
        /// get bookings of a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<OperationResult> GetBooking(string email)
        {
            return await this.BookingService.GetBooking(email);
        }

    }
}
