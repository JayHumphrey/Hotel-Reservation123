using HotelReservation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Bill_Payment_info
    {
        DataAccess da;
        public System.Guid RESERVE_ID { get; set; }
        public System.Guid PAYMENT_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public Nullable<decimal> ADVANCE { get; set; }
        public Nullable<decimal> BALANCE { get; set; }
        public decimal ROOM_PRICE { get; set; }

        public Bill_Payment_info BillPayment_info()
        {
            da = new DataAccess();
            Bill_Payment_info payment_details = da.BillPayment_info(this.RESERVE_ID, this.CUST_ID);
            return payment_details;
        }

        internal bool Bill_Payment()
        {
            da = new DataAccess();
            bool isBillPaySuccesful = false;

            try
            {
                Bill_Payment_info billpay = new Bill_Payment_info();

                billpay.PAYMENT_ID = Guid.NewGuid();
                billpay.CUST_ID = this.CUST_ID;
                billpay.TOTAL_AMOUNT = this.TOTAL_AMOUNT;
                billpay.ADVANCE = this.ADVANCE;
                billpay.BALANCE = ((this.TOTAL_AMOUNT) - (this.ADVANCE));
                billpay.RESERVE_ID = this.RESERVE_ID;

                isBillPaySuccesful = da.BillPayment(billpay);

                
            }
            catch (Exception)
            {
                isBillPaySuccesful = false;
            }

            return isBillPaySuccesful;
        }

    }
}