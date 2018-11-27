using IBusinessLayer;
using Sanctuary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sanctuary.ApiControllers
{
    [EnableCors(origins: "http://localhost:4202", headers: "*", methods: "*")]
    [RoutePrefix("Booking")]
    public class BookingController : ApiController
    {
        /// <summary>
        /// Booking manager
        /// </summary>
        private readonly IBookingManager BookingManager;


        /// <summary>
        /// constructoe for the booking controller
        /// </summary>
        /// <param name="userManager"></param>
        public BookingController(IBookingManager bookingManager)
        {
            this.BookingManager = bookingManager;
        }

        public BookingController()
        {

        }

        /// <summary>
        /// gets all the bookings
        /// </summary>
        /// <returns>operational result which contains list of bookings</returns>
        [HttpGet]
        [Route("all")]
        public async Task<OperationResult> getBookings()
        {
            return await this.BookingManager.getBookings();
        }

        [HttpGet]
        [Route("myBookings")]
        public async Task<OperationResult> GetBookings(string email)
        {
            return await this.BookingManager.GetBooking(email);
        }

        /// <summary>
        /// Get method for finding booking details of already booked assets
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBookingDetails")]
        public async Task<HttpResponseMessage> GetBooking(int bookingId)
        {
            OperationResult operationResult = await this.BookingManager.GetBooking(bookingId);
            return Request.CreateResponse(HttpStatusCode.OK, operationResult);
        }

        /// <summary>
        /// Get method to find check the availability of rooms at particular location
        /// </summary>
        /// <param name="bookingFromDate"></param>
        /// <param name="bookingToDate"></param>
        /// <param name="locationCity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckAvailability")]
        public async Task<OperationResult> GetAvailabilityOfRoomsByDate(String  bookingFromDate, String bookingToDate, String locationCity)
        {
           return await this.BookingManager.GetAvailabilityOfRoomsByDate(bookingFromDate, bookingToDate, locationCity);
        }

        /// <summary>
        /// Post Method to insert the booking details .
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateBooking")]
        public async Task<HttpResponseMessage> CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            OperationResult operationResult = await this.BookingManager.CreateBooking(booking);
            return Request.CreateResponse(HttpStatusCode.Created, operationResult);
        }

        /// <summary>
        /// Delete Method to cancel booking . 
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>OpeartionalResult</returns>
        [HttpDelete]
        [Route("cancel")]
        public async Task<HttpResponseMessage> CancelBooking(int bookingId)
        {
            OperationResult operationResult = await this.BookingManager.CancelBooking(bookingId);
            return Request.CreateResponse(HttpStatusCode.OK, operationResult);
        }

    }
}
