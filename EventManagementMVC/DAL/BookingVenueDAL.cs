using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BOL;

namespace DAL
{
    public class BookingVenueDAL
    {
        private static string conString = string.Empty;
        static BookingVenueDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(BookingVenue bookVenue)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into BookingVenue(VenueId,EventTypeId,GuestCount,BookDate,CustomerId) " +
                        "Values(@VenueId,@EventTypeId,@GuestCount,@BookDate,@CustomerId)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@VenueId", bookVenue.VenueId));
                    cmd.Parameters.Add(new SqlParameter("@EventTypeId", bookVenue.EventTypeId));
                    cmd.Parameters.Add(new SqlParameter("@GuestCount", bookVenue.GuestCount));
                    cmd.Parameters.Add(new SqlParameter("@BookDate", bookVenue.BookDate));
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", bookVenue.CustomerId));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }


        public static bool Check(int BookingVenueId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingVenue WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", BookingVenueId));
                 //   cmd.Parameters.Add(new SqlParameter("@CustomerPassword", CustomerPassword));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            //if (reader.Read())
                            //{
                            //    adminReg = new AdminRegistration()
                            //    {
                            //        ProductId = int.Parse(reader["productId"].ToString()),
                            //        Title = reader["title"].ToString(),
                            //        Description = reader["description"].ToString(),
                            //        ImageURL = reader["picture"].ToString(),
                            //        UnitPrice = float.Parse(reader["price"].ToString()),
                            //        Balance = int.Parse(reader["quantity"].ToString()),
                            //        PaymentTerm = reader["paymentTerm"].ToString(),
                            //        Delivery = reader["delivery"].ToString(),
                            //        Category = reader["category"].ToString()
                            //    };
                            //}
                            status = true;
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }



        public static bool Update(string CustomerId,  BookingVenue bookVenue)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE BookingVenue SET VenueId=@VenueId, EventTypeId=@EventTypeId, " +
                        "GuestCount=@GuestCount, CreatedBy=@CreatedBy, " +
                        "WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@VenueId", bookVenue.VenueId));
                    cmd.Parameters.Add(new SqlParameter("@EventTypeId", bookVenue.EventTypeId));
                    cmd.Parameters.Add(new SqlParameter("@GuestCount", bookVenue.GuestCount));
                    cmd.Parameters.Add(new SqlParameter("@BookDate", bookVenue.BookDate));
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", bookVenue.CustomerId));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public static bool Delete(int CustomerId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from BookingVenue where CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }




        public static List<BookingVenue> GetAll()
        {
            List<BookingVenue> bookVenuesList = new List<BookingVenue>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingVenue";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingVenue bookvenue = new BookingVenue()
                                {
                                    VenueId = reader["VenueId"].ToString(),
                                    EventTypeId = int.Parse(reader["EventTypeId"].ToString()),
                                    GuestCount = int.Parse(reader["GuestCount"].ToString()),
                                    BookDate = DateTime.Parse(reader["BookDate"].ToString()),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString())
                                };
                                bookVenuesList.Add(bookvenue);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bookVenuesList;
        }


    }
}
