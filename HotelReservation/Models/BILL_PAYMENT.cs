//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelReservation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILL_PAYMENT
    {
        public System.Guid PAYMENT_ID { get; set; }
        public System.Guid CUST_ID { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public Nullable<decimal> ADVANCE { get; set; }
        public Nullable<decimal> BALANCE { get; set; }
    }
}
