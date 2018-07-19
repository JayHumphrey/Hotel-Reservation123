using HotelReservation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class MY_RESERVATIONS
    {
        DataAccess da;

        public System.Guid RESERVE_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public Nullable<System.Guid> PAYMENT_ID { get; set; }
        public System.DateTime ARRIVAL_DATE { get; set; }
        public System.DateTime DEPARTURE_DATE { get; set; }
        public string ROOM_TYPE { get; set; }
        public string ROOM_ID { get; set; }
        public decimal ROOM_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal MAX_GUEST { get; set; }
        public Nullable<decimal> DISCOUNT { get; set; }
        public Nullable<decimal> ADVANCE { get; set; }
        public string BOOKING_STATUS { get; set; }

        public IEnumerable<MY_RESERVATIONS> MyReservations()
        {
            da = new DataAccess();
            return da.MyReservations(this.CUST_ID);
        }
    }
}