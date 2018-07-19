using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class PartialLogin
    {
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}