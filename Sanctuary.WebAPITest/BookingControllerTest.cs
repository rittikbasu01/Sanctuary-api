using BusinessLayer;
using Sanctuary.ApiControllers;
using Sanctuary.BusinessLayerTest.FakeDataLayer;
using Sanctuary.Entities;
using System;


namespace Sanctuary.WebAPITest
{
    public class BookingControllerTest
    {
        BookingController bookingController; 
        public BookingControllerTest()
        {
            bookingController = new BookingController(new BookingManager(new FakeBookingService()));
        }

        public void BookingController_CreateBooking_ValidTest()
        {
            bookingController.CreateBooking(new TblBooking()
            {
                UserId = new Guid(""),
                AssetId = 1,
                BookingFromDate = new DateTime(2018, 04, 26),
                BookingToDate = new DateTime(2018, 04, 27),
                NoOfRooms = 2,
            });
        }

        public void BookingController_CreateBooking_InvalidAssetId_Test()
        {

        }
    }
}
