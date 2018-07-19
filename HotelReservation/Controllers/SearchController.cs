using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        [HttpPost]
        public ActionResult Search(SearchList searchDetails)
        {
            return View(searchDetails.SearchRoom());
        }



	}
}