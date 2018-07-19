using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Content.Controllers
{
    public class RoomsforPublicViewController : Controller
    {
      //  private OnlineHotelReservationEntities db = new OnlineHotelReservationEntities();
        // GET: /RoomsforPublicView/
        public ActionResult Index()
        {
            RoomsForPublic rooms = new RoomsForPublic();
            return View(rooms.GetAllRoomsForPublic());
            
        }
	}
}