using HotelReservation.HelperCodes.Codes;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class BillPaymentController : Controller
    {
        //
        // GET: /BillPayment/
        public ActionResult BillPayment_info(Guid reservationID)
        {
            Bill_Payment_info info = new Bill_Payment_info();
            info.RESERVE_ID = reservationID;
            info.CUST_ID = SessionHandler.CurrentUser.UserID; 

            return View(info.BillPayment_info());
        }
        [HttpPost]
        public ActionResult BillPayment_info(Bill_Payment_info info)
        {
            if((info.ADVANCE)>= 2000 )
            {
                if (info.Bill_Payment())
                {

                    ViewBag.Message = "Your Bill paid successfully !!";

                }
                else
                {
                    ViewBag.Message = "Error occured while updateing the you information." + "\n[BillPaymentController.BillPayment_info {POST} ]";
                }
            }
            else
            {
                ViewBag.Message = "Pay minimum 2000 tk !!";

            }
           
            return View(info);
        }
	}
}