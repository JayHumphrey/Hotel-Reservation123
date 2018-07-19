using HotelReservation.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class SearchList
    {
        public SearchList()
        {
             CheckIn = new DateTimeHelper();
             CheckOut = new DateTimeHelper();
        }


        DataAccess da;
        public DateTimeHelper CheckIn{get; set;}
        public DateTimeHelper CheckOut { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime ARRIVAL_DATE { get; set; }
        public System.DateTime DEPARTURE_DATE { get; set; }
        public string ROOM_TYPE { get; set; }
        public decimal ROOM_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal MAX_GUEST { get; set; }
        public decimal DISCOUNT { get; set; }

        public string ROOM_ID { get; set; }
        public decimal TOTAL_ROOMS { get; set; }
        public string STATUS { get; set; }

           

        public IEnumerable<SearchList> SearchRoom()
        {
            ARRIVAL_DATE = new DateTime(Convert.ToInt32( CheckIn.TakeYear), Convert.ToInt32(CheckIn.TakeMonth), Convert.ToInt32( CheckIn.TakeDay), 0, 0, 0);
            DEPARTURE_DATE = new DateTime(Convert.ToInt32(CheckOut.TakeYear), Convert.ToInt32(CheckOut.TakeMonth), Convert.ToInt32(CheckOut.TakeDay), 0, 0, 0);
         
            da = new DataAccess();
            return da.SearchRoom(this.ARRIVAL_DATE, this.DEPARTURE_DATE);
        }

       
    }
}