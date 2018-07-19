using HotelReservation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class ReservationDetails
    {
        DataAccess da;

        public System.Guid RESERVE_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public System.DateTime ARRIVAL_DATE { get; set; }
        public System.DateTime DEPARTURE_DATE { get; set; }
        public string ROOM_ID { get; set; }
        public string ROOM_TYPE { get; set; }
        public decimal ROOM_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal MAX_GUEST { get; set; }
        public Nullable<decimal> DISCOUNT { get; set; }

        public ReservationDetails Reserve_Room()
        {
            da = new DataAccess();
            ReservationDetails reserve_details = da.Reserve_Room(this.RESERVE_ID,this.CUST_ID);           
            return reserve_details;
        }


    }
}