﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OnlineHotelReservationEntities : DbContext
    {
        public OnlineHotelReservationEntities()
            : base("name=OnlineHotelReservationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMIN_PROFILE> ADMIN_PROFILE { get; set; }
        public virtual DbSet<BILL_PAYMENT> BILL_PAYMENT { get; set; }
        public virtual DbSet<CUSTOMER_PROFILE> CUSTOMER_PROFILE { get; set; }
        public virtual DbSet<RESERVATION> RESERVATIONs { get; set; }
        public virtual DbSet<ROOM_DETAILS> ROOM_DETAILS { get; set; }
        public virtual DbSet<ROOM_TYPE_INFO> ROOM_TYPE_INFO { get; set; }
    
        public virtual int CUSTOMER_PROFILE_CustomerSignUp(Nullable<System.Guid> cust_ID, string firstName, string lastName, string address, string email, string phone, string gender, string passWord)
        {
            var cust_IDParameter = cust_ID.HasValue ?
                new ObjectParameter("Cust_ID", cust_ID) :
                new ObjectParameter("Cust_ID", typeof(System.Guid));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("PassWord", passWord) :
                new ObjectParameter("PassWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CUSTOMER_PROFILE_CustomerSignUp", cust_IDParameter, firstNameParameter, lastNameParameter, addressParameter, emailParameter, phoneParameter, genderParameter, passWordParameter);
        }
    
        public virtual ObjectResult<RoomsForPublicView_Result> RoomsForPublicView()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RoomsForPublicView_Result>("RoomsForPublicView");
        }
    
        public virtual int ADMIN_PROFILE_AdminSignUp(Nullable<System.Guid> userID, string passWord, string firstName, string lastName, string phoneNo, string email)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("PassWord", passWord) :
                new ObjectParameter("PassWord", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneNoParameter = phoneNo != null ?
                new ObjectParameter("PhoneNo", phoneNo) :
                new ObjectParameter("PhoneNo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ADMIN_PROFILE_AdminSignUp", userIDParameter, passWordParameter, firstNameParameter, lastNameParameter, phoneNoParameter, emailParameter);
        }
    }
}
