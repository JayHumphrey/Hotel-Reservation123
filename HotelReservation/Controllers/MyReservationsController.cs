using HotelReservation.HelperCodes.Codes;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class MyReservationsController : Controller
    {
        //
        // GET: /MyReservations/
        public ActionResult MyReservations()
        {
            MY_RESERVATIONS myReserve = new MY_RESERVATIONS();
            myReserve.CUST_ID = SessionHandler.CurrentUser.UserID;
            return View(myReserve.MyReservations());
        }
	}
}