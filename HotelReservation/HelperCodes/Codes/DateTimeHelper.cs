using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation
{
    public class DateTimeHelper
    {
        public List<SelectListItem> Day = new List<SelectListItem>();
        public List<SelectListItem> Month = new List<SelectListItem>();
        public List<SelectListItem> Year = new List<SelectListItem>();
        public List<SelectListItem> Hour = new List<SelectListItem>();

        public string TakeDay { get; set; }
        public string TakeMonth { get; set; }
        public string TakeYear { get; set; }
        public string TakeHour { get; set; }

        public DateTimeHelper()
        {
            for (int i = 1; i <= 31; i++)
            {
                this.Day.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            this.Month.Add(new SelectListItem { Text = "January", Value = "1" });
            this.Month.Add(new SelectListItem { Text = "February", Value = "2" });
            this.Month.Add(new SelectListItem { Text = "March", Value = "3" });
            this.Month.Add(new SelectListItem { Text = "April", Value = "4" });
            this.Month.Add(new SelectListItem { Text = "May", Value = "5" });
            this.Month.Add(new SelectListItem { Text = "June", Value = "6" });
            this.Month.Add(new SelectListItem { Text = "July", Value = "7" });
            this.Month.Add(new SelectListItem { Text = "August", Value = "8" });
            this.Month.Add(new SelectListItem { Text = "September", Value = "9" });
            this.Month.Add(new SelectListItem { Text = "October", Value = "10" });
            this.Month.Add(new SelectListItem { Text = "November", Value = "11" });
            this.Month.Add(new SelectListItem { Text = "December", Value = "12" });

            this.Year.Add(new SelectListItem { Text = "2017", Value = "2017" });
            this.Year.Add(new SelectListItem { Text = "2018", Value = "2018" });
            this.Year.Add(new SelectListItem { Text = "2019", Value = "2019" });
            this.Year.Add(new SelectListItem { Text = "2020", Value = "2020" });
            this.Year.Add(new SelectListItem { Text = "2021", Value = "2021" });
            this.Year.Add(new SelectListItem { Text = "2022", Value = "2022" });

            for (int i = 1; i <= 24; i++)
            {
                this.Hour.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
        }
    }
}