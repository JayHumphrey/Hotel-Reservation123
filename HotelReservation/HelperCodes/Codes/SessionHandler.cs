using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.HelperCodes.Codes
{
    public class SessionHandler
    {
        public static SessionUser User
        {
            get
            {
                return HttpContext.Current.Session["SessionHandler"] as SessionUser;
            }
            set
            {
                HttpContext.Current.Session["SessionHandler"] = value;
            }
        }

        public static SessionUser CurrentUser
        {
            get
            {
                var currentUser = User;

                if (currentUser == null)
                {
                    currentUser = new SessionUser();
                    var httpCookie = HttpContext.Current.Response.Cookies["SessionUser"];
                    try
                    {
                        currentUser.UserID = new Guid(httpCookie["UserID"]);
                        currentUser.FirstName = httpCookie["FirstName"];
                        currentUser.LastName = httpCookie["LastName"];
                        currentUser.PhoneNo = httpCookie["PhoneNo"];
                        currentUser.Email = httpCookie["Email"];
                        currentUser.Status = httpCookie["Status"];
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return currentUser;
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session["SessionHandler"] = null;
            var httpCookie = HttpContext.Current.Response.Cookies["SessionUser"];
            if (httpCookie != null)
            {
                httpCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(httpCookie);
            }
        }

        public static void AddToCookie(SessionUser sessionUser)
        {
            var httpCookie = HttpContext.Current.Response.Cookies["SessionUser"];
            if (httpCookie != null)
            {
                httpCookie["UserID"] = sessionUser.UserID.ToString();
                httpCookie["FirstName"] = sessionUser.FirstName;
                httpCookie["LastName"] = sessionUser.LastName;
                httpCookie["PhoneNo"] = sessionUser.PhoneNo;
                httpCookie["Email"] = sessionUser.Email;
                httpCookie["Status"] = sessionUser.Status;

                httpCookie.Expires = DateTime.Now.AddDays(1);
            }

        }
    }
}