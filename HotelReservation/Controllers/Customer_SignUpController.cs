using HotelReservation.HelperCodes.Codes;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelReservation.Content.Controllers
{
    public class Customer_SignUpController : Controller
    {
        //
        // GET: /Customer_SignUp/
        public ActionResult CustomerSignUp()
        {
            CUSTOMER_PROFILE SignUp = new CUSTOMER_PROFILE();
            return View(SignUp);
        }

        public ActionResult Details(Guid custID)
        {
            CUSTOMER_PROFILE customerDetails = new CUSTOMER_PROFILE();
            return View(customerDetails.CustomerDetails(custID));
        }

        public ActionResult Edit(Guid custID)
        {
            CUSTOMER_PROFILE customerEdit = new CUSTOMER_PROFILE();
            return View(customerEdit.CustomerDetails(custID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CUSTOMER_PROFILE customerEdit)
        {
            if (customerEdit.customerUpdate())
            {
                ViewBag.Message = "Your information updated successfully !!";

            }
            else
            {
                ViewBag.Message = "Error occured while updateing the you information." + "\n[Customer_SignUpController.Edit {POST} ]";
            }
            return View(customerEdit);
        }

        [HttpPost]
        public ActionResult CustomerSignUp(CUSTOMER_PROFILE CustomerProfile)
        {

            if(CustomerProfile.PASSWORD.Equals(CustomerProfile.CONFIRMPASSWORD))
            {
                if(CustomerProfile.CustomerSignUp())
                {
                    //direct login
                    FormsAuthentication.SetAuthCookie(CustomerProfile.EMAIL, CustomerProfile.extraLogin.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                }
            }
            else 
            {
                ViewBag.Message = "Passwords do not match !!";
            }

            return View();
        }
        public ActionResult customerLogin(string returnUrl)
        {
            CUSTOMER_PROFILE profileForLogin = new CUSTOMER_PROFILE();
            profileForLogin.extraLogin.ReturnUrl = returnUrl;

            if (SessionHandler.CurrentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(profileForLogin);
        }

        [HttpPost]
        public ActionResult customerLogin(CUSTOMER_PROFILE profile)
        {
            if (profile.CustomerLogin() != null)
            {
                if (profile.extraLogin.ReturnUrl == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(profile.extraLogin.ReturnUrl);
                }
            }
            return View();
        }

        public ActionResult CustomerLogout()
        {
            FormsAuthentication.SignOut();
            SessionHandler.Clear();
            return RedirectToAction("Index", "Home");
        }

	}
}