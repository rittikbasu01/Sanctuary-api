using IBusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using System;
using System.Threading.Tasks;
using Sanctuary.Entities;

namespace Sanctuary.BusinessLayerTest.FakeBusinessLayer
{
    public class FakeBookingManager : IBookingManager
    {
        /// <summary>
        /// interface of booking service
        /// </summary>
        IBookingService bookingService;

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="bookingService">fake data layer object</param>
        public FakeBookingManager(IBookingService fakeBookingService)
        {
            bookingService = fakeBookingService;
        }

        /// <summary>
        /// cancel booking by booking id
        /// </summary>
        /// <param name="bookingId">booking id</param>
        /// <returns>OperationResult</returns>
        public async Task<OperationResult> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// create a new booking for given date and location
        /// </summary>
        /// <param name="booking">booking table object</param>
        /// <returns>OperationResult</returns>
        public async Task<OperationResult> CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get availability of rooms
        /// </summary>
        /// <param name="bookingFromDate">bookingFromDate</param>
        /// <param name="bookingToDate">bookingToDate</param>
        /// <param name="locationCity">locationCity</param>
        /// <returns>OperationResult</returns>
        public async Task<OperationResult> GetAvailabilityOfRoomsByDate(string bookingFromDate, string bookingToDate, string locationCity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the booking using booking id
        /// </summary>
        /// <param name="bookingId">booking id</param>
        /// <returns>OperationResult</returns>
        public async Task<OperationResult> GetBooking(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
