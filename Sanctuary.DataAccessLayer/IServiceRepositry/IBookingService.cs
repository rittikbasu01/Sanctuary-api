using Sanctuary.Entities;
using System;
using System.Threading.Tasks;

namespace Sanctuary.DataAccessLayer.IServiceRepositry
{
    /// <summary>
    /// interface for booking service
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// gets all the bookings
        /// </summary>
        /// <returns>operational result which contains list of bookings</returns>
        Task<OperationResult> getBookings();

        /// <summary>
        /// method for creating new booking
        /// </summary>
        /// <param name="booking"></param>
        Task<OperationResult> CreateBooking(Booking booking);

        /// <summary>
        /// get booking details by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpearationResult</returns>
        Task<OperationResult> GetBooking(int bookingId);

        /// <summary>
        /// get booking details using to date, from date and location
        /// </summary>
        /// <param name="BookingFromDate"></param>
        /// <param name="BookingToDate"></param>
        /// <param name="location"></param>
        /// <returns>OpeartionResult</returns>
        Task<OperationResult> GetAvailabilityOfRoomsByDate(String bookingFromDate, String bookingToDate, string locationCity);

        /// <summary>
        /// cancel the booking by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpeartionResult</returns>
        Task<OperationResult> CancelBooking(int bookingId);

        /// <summary>
        /// get bookings of a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<OperationResult> GetBooking(string email);
    }
}
