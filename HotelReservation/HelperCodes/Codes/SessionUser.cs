using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.HelperCodes.Codes
{
    public class SessionUser
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}