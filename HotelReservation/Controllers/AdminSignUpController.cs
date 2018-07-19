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
    public class AdminSignUpController : Controller
    {
        //
        // GET: /AdminSignUp/
        public ActionResult AdminSignUp()
        {
            ADMIN_PROFILE adminProfile = new ADMIN_PROFILE();
            return View(adminProfile);
        }

        public ActionResult Details(Guid UserID)
        {
            ADMIN_PROFILE adminDetails = new ADMIN_PROFILE();
            return View(adminDetails.AdminDetails(UserID));
        }

        public ActionResult Edit(Guid UserID)
        {
            ADMIN_PROFILE adminEdit = new ADMIN_PROFILE();
            return View(adminEdit.AdminDetails(UserID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ADMIN_PROFILE AdminEdit)
        {
            if(AdminEdit.AdminUpdate())
            {
                ViewBag.Message = "Your information updated successfully !!";

            }
            else
            {
                ViewBag.Message = "Error occured while updateing the you information." + "\n[AdminSignUpController.Edit {POST} ]";
            }
            return View(AdminEdit);
        }

        [HttpPost]
        public ActionResult AdminSignUp(ADMIN_PROFILE AdminSignUp)
        {
            if (AdminSignUp.PASSWORD.Equals(AdminSignUp.CONFIRMPASSWORD))
            {
                if (AdminSignUp.AdminSignUp())
                {
                    //direct login
                    FormsAuthentication.SetAuthCookie(AdminSignUp.EMAIL, AdminSignUp.extraLogin.RememberMe);
                    return RedirectToAction("AdminLogin", "AdminSignUp");
                }
                else
                {
                    ViewBag.Message = "Error occured while signing up new user !!" + "\n[AdminSignUpController.AdminSignUp]";
                }
            }
            else
            {
                ViewBag.Message = "Passwords do not match !!";
            }

            return View();
        }

        public ActionResult AdminLogin(string returnUrl)
        {
            ADMIN_PROFILE profileForLogin = new ADMIN_PROFILE();
            profileForLogin.extraLogin.ReturnUrl = returnUrl;

            if (SessionHandler.CurrentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(profileForLogin);
        }

        [HttpPost]
        public ActionResult AdminLogin(ADMIN_PROFILE profile)
        {
            if (profile.AdminLogin() != null)
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

        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            SessionHandler.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}