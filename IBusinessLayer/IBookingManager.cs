using Sanctuary.Entities;
using System;
using System.Threading.Tasks;

namespace IBusinessLayer
{
    /// <summary>
    /// interface for booking manager
    /// </summary>
    public interface IBookingManager
    {
        /// <summary>
        /// Method to insert booking details in booking.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>OpeartionResult</returns>
        Task<OperationResult> CreateBooking(Booking booking);

        /// <summary>
        /// Get the booking details by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OperationResult</returns>
        Task<OperationResult> GetBooking(int bookingId);

        /// <summary>
        /// Cancel booking by using the booking Id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpeartionResult</returns>
        Task<OperationResult> CancelBooking(int bookingId);

        /// <summary>
        /// Get room availability details by date and location city
        /// </summary>
        /// <param name="bookingFromDate"></param>
        /// <param name="bookingToDate"></param>
        /// <param name="locationCity"></param>
        /// <returns>OpeartionResult</returns>
        Task<OperationResult> GetAvailabilityOfRoomsByDate(String bookingFromDate, String bookingToDate, string locationCity);

        /// <summary>
        /// get bookings of a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<OperationResult> GetBooking(string email);

        /// <summary>
        /// gets all the bookings
        /// </summary>
        /// <returns>operational result which contains list of bookings</returns>
        Task<OperationResult> getBookings();
    }
}
