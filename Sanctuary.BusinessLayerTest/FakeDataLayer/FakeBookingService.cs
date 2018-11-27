using Sanctuary.DataAccessLayer.IServiceRepositry;
using System;
using System.Threading.Tasks;
using Sanctuary.Entities;

namespace Sanctuary.BusinessLayerTest.FakeDataLayer
{
    /// <summary>
    /// BookingService which does crud operations on Booking table
    /// </summary>
    public class FakeBookingService : IBookingService
    {
        /// <summary>
        /// cancels a new booking
        /// </summary>
        /// <param name="bookingId">bookingId</param>
        public async Task<OperationResult> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// creates a new booking
        /// </summary>
        /// <param name="booking"></param>
        public async Task<OperationResult> CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get the avilability of rooms for assets for a given period of time.
        /// </summary>
        /// <param name="BookingFromDate"></param>
        /// <param name="BookingToDate"></param>
        /// <param name="location"></param>s
        /// <returns>OperationResult</returns>
        public async Task<OperationResult> GetAvailabilityOfRoomsByDate(string bookingFromDate, string bookingToDate, string locationCity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get the booking by Booking Id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpeartionResult</returns>
        public async Task<OperationResult> GetBooking(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
