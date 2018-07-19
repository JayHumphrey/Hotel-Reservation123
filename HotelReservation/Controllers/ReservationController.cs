using HotelReservation.HelperCodes.Codes;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class ReservationController : Controller
    {
        //
        // GET: /Reservation/
        public ActionResult Booking(DateTime ArrivalDate,DateTime DepertureDate, string RoomID) 
        {
            RESERVATION BookRoom = new RESERVATION();
            BookRoom.ARRIVAL_DATE = ArrivalDate;
            BookRoom.DEPARTURE_DATE = DepertureDate;
            BookRoom.ROOM_ID = RoomID;
            BookRoom.CUST_ID = SessionHandler.CurrentUser.UserID;
            BookRoom.RESERVE_ID = Guid.NewGuid();
            BookRoom.Booking();
            return RedirectToAction("Reserve_Room", "ReservationDetails", new { reservationID = BookRoom.RESERVE_ID });


        }
	}
}