using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelReservation.DAL
{
    public class DataAccess
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["OnlineHotelReservationDB"].ToString();

        public IEnumerable<RoomsForPublic> GetAllRoomsForPublic()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[RoomsForPublicView]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;

            List<RoomsForPublic> listofAllRooms = new List<RoomsForPublic>();

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RoomsForPublic roomDetails = new RoomsForPublic();

                    roomDetails.ROOM_ID = reader["ROOM_ID"].ToString();
                    roomDetails.ROOM_TYPE = reader["ROOM_TYPE"].ToString();
                    roomDetails.DESCRIPTION = reader["DESCRIPTION"].ToString();
                    roomDetails.MAX_GUEST = Convert.ToDecimal(reader["MAX_GUEST"]);
                    roomDetails.DISCOUNT = Convert.ToDecimal(reader["DISCOUNT"]);
                    roomDetails.ROOM_PRICE = Convert.ToDecimal(reader["ROOM_PRICE"]);
                    roomDetails.TOTAL_ROOMS = Convert.ToDecimal(reader["TOTAL_ROOMS"]);
                    roomDetails.STATUS = reader["STATUS"].ToString();

                    listofAllRooms.Add(roomDetails);
                }
            }
            catch { throw; }

            reader.Close();
            con.Close();
            return listofAllRooms;
        }

        public bool CustomerSignUp(CUSTOMER_PROFILE CustomerProfile)
        {
            bool customerAdded = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "CUSTOMER_PROFILE_CustomerSignUp";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Cust_ID", SqlDbType.UniqueIdentifier).Value = CustomerProfile.CUST_ID;
            cmd.Parameters.Add("@FirstName", SqlDbType.NChar).Value = CustomerProfile.FIRST_NAME;
            cmd.Parameters.Add("@LastName", SqlDbType.NChar).Value = CustomerProfile.LAST_NAME;
            cmd.Parameters.Add("@Address", SqlDbType.NChar).Value = CustomerProfile.ADDRESS;
            cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = CustomerProfile.EMAIL;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = CustomerProfile.PHONE_NO;
            cmd.Parameters.Add("@Gender", SqlDbType.NChar).Value = CustomerProfile.GENDER;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = CustomerProfile.PASSWORD;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                customerAdded = true;

            }
            catch (Exception ex)
            {
                throw;
            }

            con.Close();
            return customerAdded;
        }

        public bool AdminSignUp(ADMIN_PROFILE AdminProfile)
        {
            bool adminAdded = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "ADMIN_PROFILE_AdminSignUp";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = AdminProfile.USER_ID;
            cmd.Parameters.Add("@PassWord", SqlDbType.NChar).Value = AdminProfile.PASSWORD;
            cmd.Parameters.Add("@FirstName", SqlDbType.NChar).Value = AdminProfile.FIRST_NAME;
            cmd.Parameters.Add("@LastName", SqlDbType.NChar).Value = AdminProfile.LAST_NAME;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.NChar).Value = AdminProfile.PHONE_NO;
            cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = AdminProfile.EMAIL;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                adminAdded = true;

            }
            catch (Exception ex)
            {
                throw;
            }

            con.Close();
            return adminAdded;
        }

        public ADMIN_PROFILE AdminDetails(Guid userid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[ADMIN_PROFILE_Details]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userid;
            SqlDataReader reader;

            ADMIN_PROFILE profile = new ADMIN_PROFILE(); ;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profile.USER_ID = new Guid(reader["USER_ID"].ToString());
                    profile.FIRST_NAME = reader["FIRST_NAME"].ToString();
                    profile.LAST_NAME = reader["LAST_NAME"].ToString();
                    profile.EMAIL = reader["EMAIL"].ToString();
                    profile.PHONE_NO = reader["PHONE_NO"].ToString();
                    profile.PASSWORD = reader["PASSWORD"].ToString();
                   // profile.STATUS = reader["STATUS"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return profile;

        }

        public CUSTOMER_PROFILE CustomerDetails(Guid CustID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[CUSTOMER_PROFILE_Details]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = CustID;
            SqlDataReader reader;

            CUSTOMER_PROFILE custprofile = new CUSTOMER_PROFILE(); ;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    custprofile.CUST_ID = new Guid(reader["CUST_ID"].ToString());
                    custprofile.FIRST_NAME = reader["FIRST_NAME"].ToString();
                    custprofile.LAST_NAME = reader["LAST_NAME"].ToString();
                    custprofile.GENDER = reader["GENDER"].ToString();
                    custprofile.EMAIL = reader["EMAIL"].ToString();
                    custprofile.ADDRESS = reader["ADDRESS"].ToString();
                    custprofile.PHONE_NO = reader["PHONE_NO"].ToString();
                    custprofile.PASSWORD = reader["PASSWORD"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return custprofile;

        }

        public ADMIN_PROFILE AdminLogin(string email, string password)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[ADMIN_PROFILE_LogIn]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@PassWord", SqlDbType.NChar).Value = password;


            SqlDataReader reader;
            ADMIN_PROFILE adminInfo = null;

            try
            {
                adminInfo = new ADMIN_PROFILE();

                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    adminInfo.USER_ID = new Guid(reader["USER_ID"].ToString());
                    adminInfo.FIRST_NAME = reader["FIRST_NAME"].ToString();
                    adminInfo.LAST_NAME = reader["LAST_NAME"].ToString();
                    adminInfo.PHONE_NO = reader["PHONE_NO"].ToString();
                    adminInfo.EMAIL = reader["EMAIL"].ToString();
                    adminInfo.STATUS = reader["STATUS"].ToString();
                }
            }
            catch
            {
                adminInfo = null;
                throw;
            }

            return adminInfo;
        }

        public CUSTOMER_PROFILE CustomerLogin(string email, string password)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[CUSTOMER_PROFILE_LogIn]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = email;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = password;


            SqlDataReader reader;
            CUSTOMER_PROFILE CustomerInfo = null;

            try
            {
                CustomerInfo = new CUSTOMER_PROFILE();

                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CustomerInfo.CUST_ID = new Guid(reader["CUST_ID"].ToString());
                    CustomerInfo.FIRST_NAME = reader["FIRST_NAME"].ToString();
                    CustomerInfo.LAST_NAME = reader["LAST_NAME"].ToString();
                    CustomerInfo.GENDER = reader["GENDER"].ToString();
                    CustomerInfo.ADDRESS = reader["ADDRESS"].ToString();
                    CustomerInfo.PHONE_NO = reader["PHONE_NO"].ToString();
                    CustomerInfo.EMAIL = reader["EMAIL"].ToString();
                    CustomerInfo.STATUS = reader["STATUS"].ToString();
                }
            }
            catch
            {
                CustomerInfo = null;
                throw;
            }

            return CustomerInfo;
        }

        public bool AdminUpdate(ADMIN_PROFILE updateAdmin)
        {
            bool adminUpdated = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[ADMIN_PROFILE_Edit]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = updateAdmin.USER_ID;
            cmd.Parameters.Add("@FirstName", SqlDbType.NChar).Value = updateAdmin.FIRST_NAME;
            cmd.Parameters.Add("@LastName", SqlDbType.NChar).Value = updateAdmin.LAST_NAME;
            cmd.Parameters.Add("@Phone_No", SqlDbType.NChar).Value = updateAdmin.PHONE_NO;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = updateAdmin.EMAIL;
            cmd.Parameters.Add("@PassWord", SqlDbType.NChar).Value = updateAdmin.PASSWORD;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                adminUpdated = true;
            }
            catch
            {
                adminUpdated = false;
                throw;
            }

            return adminUpdated ;
        }

        public bool CustomerUpdate(CUSTOMER_PROFILE updateCustomer)
        {
            bool customerUpdated = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[CUSTOMER_PROFILE_Edit]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = updateCustomer.CUST_ID;
            cmd.Parameters.Add("@FirstName", SqlDbType.NChar).Value = updateCustomer.FIRST_NAME;
            cmd.Parameters.Add("@LastName", SqlDbType.NChar).Value = updateCustomer.LAST_NAME;
            cmd.Parameters.Add("@Gender", SqlDbType.NChar).Value = updateCustomer.GENDER;
            cmd.Parameters.Add("@Address", SqlDbType.NChar).Value = updateCustomer.ADDRESS;
            cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = updateCustomer.EMAIL;
            cmd.Parameters.Add("@PhNO", SqlDbType.NVarChar).Value = updateCustomer.PHONE_NO;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = updateCustomer.PASSWORD;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                customerUpdated = true;
            }
            catch
            {
                customerUpdated = false;
                throw;
            }

            return customerUpdated;
        }

        public IEnumerable<SearchList> SearchRoom(DateTime arrivalDate, DateTime departureDate)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[SEARCH]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ArrivalDate", SqlDbType.DateTime).Value = arrivalDate;
            cmd.Parameters.Add("@DepartureDate", SqlDbType.DateTime).Value = departureDate;
            SqlDataReader reader;

            List<SearchList> SearchlistofAllRooms = new List<SearchList>();

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SearchList searchInfo = new SearchList();

                    searchInfo.ARRIVAL_DATE = arrivalDate;
                    searchInfo.DEPARTURE_DATE = departureDate;
                    searchInfo.ROOM_ID = reader["ROOM_ID"].ToString();
                    searchInfo.ROOM_TYPE = reader["ROOM_TYPE"].ToString();
                    searchInfo.DESCRIPTION = reader["DESCRIPTION"].ToString();
                    searchInfo.MAX_GUEST = Convert.ToDecimal(reader["MAX_GUEST"]);
                    searchInfo.DISCOUNT = Convert.ToDecimal(reader["DISCOUNT"]);
                    searchInfo.TOTAL_ROOMS = Convert.ToDecimal(reader["TOTAL_ROOMS"]);
                    searchInfo.ROOM_PRICE = Convert.ToDecimal(reader["ROOM_PRICE"]);

                    SearchlistofAllRooms.Add(searchInfo);
                }
            }
            catch { throw; }

            reader.Close();
            con.Close();
            return SearchlistofAllRooms;
        }        

        public bool Booking(RESERVATION bookroom)
        {
            bool customerAdded = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "RESERVATION_booking";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReserveID", SqlDbType.UniqueIdentifier).Value = bookroom.RESERVE_ID;
            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = bookroom.CUST_ID;
            cmd.Parameters.Add("@ArrivalDate", SqlDbType.DateTime).Value = bookroom.ARRIVAL_DATE;
            cmd.Parameters.Add("@Departure", SqlDbType.DateTime).Value = bookroom.DEPARTURE_DATE;
            cmd.Parameters.Add("@RoomID", SqlDbType.NVarChar).Value = bookroom.ROOM_ID;
            

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                customerAdded = true;

            }
            catch (Exception ex)
            {
                throw;
            }

            con.Close();
            return customerAdded;
        }

        public ReservationDetails Reserve_Room(Guid reserveID, Guid custID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[RESERVE_ROOM_details]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReservationID", SqlDbType.UniqueIdentifier).Value = reserveID;
            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = custID;


            SqlDataReader reader;
            ReservationDetails reserveInfo = null;

            try
            {
                reserveInfo = new ReservationDetails();

                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reserveInfo.RESERVE_ID = new Guid(reader["RESERVE_ID"].ToString());
                    reserveInfo.CUST_ID = new Guid(reader["CUST_ID"].ToString());
                    reserveInfo.ARRIVAL_DATE = Convert.ToDateTime(reader["ARRIVAL_DATE"].ToString());
                    reserveInfo.DEPARTURE_DATE = Convert.ToDateTime(reader["DEPARTURE_DATE"].ToString());
                    reserveInfo.ROOM_TYPE = reader["ROOM_TYPE"].ToString();
                    reserveInfo.DESCRIPTION = reader["DESCRIPTION"].ToString();
                    reserveInfo.MAX_GUEST = Convert.ToDecimal(reader["MAX_GUEST"].ToString());
                    reserveInfo.ROOM_PRICE = Convert.ToDecimal(reader["ROOM_PRICE"].ToString());
                    reserveInfo.DISCOUNT = Convert.ToDecimal(reader["DISCOUNT"].ToString());
                    
                }
            }
            catch
            {
                reserveInfo = null;
                throw;
            }

            return reserveInfo;
        }

        public Bill_Payment_info BillPayment_info(Guid reserveID, Guid custID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[BILL_PAYMENT_info]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReservationID", SqlDbType.UniqueIdentifier).Value = reserveID;
            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = custID;


            SqlDataReader reader;
            Bill_Payment_info bill_paymentInfo = null;

            try
            {
                bill_paymentInfo = new Bill_Payment_info();

                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bill_paymentInfo.RESERVE_ID = new Guid(reader["RESERVE_ID"].ToString());
                    bill_paymentInfo.CUST_ID = new Guid(reader["CUST_ID"].ToString());
                    bill_paymentInfo.TOTAL_AMOUNT= Convert.ToDecimal(reader["ROOM_PRICE"].ToString());

                }
            }
            catch
            {
                bill_paymentInfo = null;
                throw;
            }

            return bill_paymentInfo;
        }

        public bool BillPayment(Bill_Payment_info BillPay)
        {
            bool billpaymentAdded = false;

            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "BILL_PAYMENT_Details";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PaymentID", SqlDbType.UniqueIdentifier).Value = BillPay.PAYMENT_ID;
            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = BillPay.CUST_ID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = BillPay.TOTAL_AMOUNT;
            cmd.Parameters.Add("@Advance", SqlDbType.Decimal).Value = BillPay.ADVANCE;
            cmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = BillPay.BALANCE;
            cmd.Parameters.Add("@reservationID", SqlDbType.UniqueIdentifier).Value = BillPay.RESERVE_ID;


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                billpaymentAdded = true;

            }
            catch (Exception ex)
            {
                throw;
            }

            con.Close();
            return billpaymentAdded;
        }

        public IEnumerable<MY_RESERVATIONS> MyReservations(Guid custID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string command = "[dbo].[MY_RESRVATIONS_Details]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CustID", SqlDbType.UniqueIdentifier).Value = custID;
            SqlDataReader reader;

            List<MY_RESERVATIONS> myreservationsList = new List<MY_RESERVATIONS>();

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MY_RESERVATIONS myreservations = new MY_RESERVATIONS();

                    myreservations.ARRIVAL_DATE = Convert.ToDateTime(reader["ARRIVAL_DATE"].ToString());
                    myreservations.DEPARTURE_DATE = Convert.ToDateTime(reader["DEPARTURE_DATE"].ToString());
                    myreservations.ROOM_ID = reader["ROOM_ID"].ToString();
                    myreservations.ROOM_TYPE = reader["ROOM_TYPE"].ToString();
                    myreservations.DESCRIPTION = reader["DESCRIPTION"].ToString();
                    myreservations.ROOM_PRICE = Convert.ToDecimal(reader["ROOM_PRICE"]);
                    myreservations.MAX_GUEST = Convert.ToDecimal(reader["MAX_GUEST"]);
                    myreservations.DISCOUNT = Convert.ToDecimal(reader["DISCOUNT"]);
                    myreservations.ADVANCE = Convert.ToDecimal(reader["ADVANCE"]);


                    myreservationsList.Add(myreservations);
                }
            }
            catch { throw; }

            reader.Close();
            con.Close();
            return myreservationsList;
        }        
       
    }
}