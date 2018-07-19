using HotelReservation.HelperCodes.Codes;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class ReservationDetailsController : Controller
    {
        //
        // GET: /ReservationDetails/
        public ActionResult Reserve_Room(Guid reservationID)
        {
            ReservationDetails reserve_room = new ReservationDetails();
            reserve_room.RESERVE_ID = reservationID;
            reserve_room.CUST_ID = SessionHandler.CurrentUser.UserID;            
            return View(reserve_room.Reserve_Room());
        }
        
	}
}