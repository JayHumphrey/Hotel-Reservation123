using HotelReservation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HotelReservation.Models
{
    
    public class RoomsForPublic
    {
        DataAccess da;

        public string ROOM_TYPE { get; set; }
        public decimal ROOM_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal MAX_GUEST { get; set; }
        public decimal DISCOUNT { get; set; }

        public string ROOM_ID { get; set; }
        public decimal TOTAL_ROOMS { get; set; }
        public string STATUS { get; set; }

        public IEnumerable<RoomsForPublic> GetAllRoomsForPublic()
        {
            da = new DataAccess();
            return da.GetAllRoomsForPublic();
        }
    
    }
}