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
    using HotelReservation.DAL;
    using HelperCodes.Codes;
    using System;
    using System.Collections.Generic;

    public partial class ADMIN_PROFILE
    {
        DataAccess da;
        public Guid USER_ID { get; set; }
        public string PASSWORD { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string PHONE_NO { get; set; }
        public string EMAIL { get; set; }
        public string STATUS { get; set; }
        public string CONFIRMPASSWORD { get; set; }
        public PartialLogin extraLogin = new PartialLogin();

        internal bool AdminSignUp()
        {
            da = new DataAccess();
            bool isLoginSuccesful = false;

            try
            {
                ADMIN_PROFILE AdminProfile = new ADMIN_PROFILE();

                AdminProfile.USER_ID = Guid.NewGuid();
                AdminProfile.FIRST_NAME = this.FIRST_NAME;
                AdminProfile.LAST_NAME = this.LAST_NAME;
                AdminProfile.EMAIL = this.EMAIL;
                AdminProfile.PHONE_NO = this.PHONE_NO;
                AdminProfile.PASSWORD = this.PASSWORD;
                AdminProfile.CONFIRMPASSWORD = this.CONFIRMPASSWORD;
                //AdminProfile.STATUS = this.STATUS;

                isLoginSuccesful = da.AdminSignUp(AdminProfile);

                //if (isLoginSuccesful)
                //{
                //    SessionUser user = new SessionUser()
                //    {
                //        UserID = AdminProfile.USER_ID,
                //        FirstName = AdminProfile.FIRST_NAME,
                //        LastName = AdminProfile.LAST_NAME,
                //        Email = AdminProfile.EMAIL,
                //        PhoneNo = AdminProfile.PHONE_NO,
                //        Status = AdminProfile.STATUS
                //    };

                //    SessionHandler.User = user;
                //    SessionHandler.AddToCookie(user);
                //}
            }
            catch (Exception)
            {
                isLoginSuccesful = false;
            }

            return isLoginSuccesful;
        }
        public ADMIN_PROFILE AdminDetails(Guid userid)
        {
            da = new DataAccess();
            return da.AdminDetails(userid);
        }

        public ADMIN_PROFILE AdminLogin()
        {
            da = new DataAccess();
            ADMIN_PROFILE profile = da.AdminLogin(this.EMAIL, this.PASSWORD);

            if (profile != null)
            {
                SessionUser user = new SessionUser()
                {
                    UserID = profile.USER_ID,
                    FirstName = profile.FIRST_NAME,
                    LastName = profile.LAST_NAME,
                    Email = profile.EMAIL,
                    PhoneNo = profile.PHONE_NO,
                    Status = profile.STATUS
                };

                SessionHandler.User = user;
                SessionHandler.AddToCookie(user);
            }
            return profile;
        }

        public bool AdminUpdate()
        {
            ADMIN_PROFILE updateAdmin = new ADMIN_PROFILE();

            updateAdmin.USER_ID = this.USER_ID;
            updateAdmin.FIRST_NAME = this.FIRST_NAME;
            updateAdmin.LAST_NAME = this.LAST_NAME;
            updateAdmin.PHONE_NO = this.PHONE_NO;
            updateAdmin.EMAIL = this.EMAIL;
            updateAdmin.PASSWORD = this.PASSWORD;

            da = new DataAccess();
            return da.AdminUpdate(updateAdmin);
        }
    }
}
