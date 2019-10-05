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
    public class BookingDetailsDAL
    {

        private static string conString = string.Empty;
        static BookingDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static List<BookingDetails> GetAll()
        {
            List<BookingDetails> bookdetailslist = new List<BookingDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select CustomerRegistration.CustomerId as 'CustomerID', CustomerName, CustomerContact, VenueName,VenueCost, BookDate from " +
                        "VenueDetails, BookingVenue, CustomerRegistration  where " +
                        "VenueDetails.VenueId = BookingVenue.VenueId and " +
                        "CustomerRegistration.CustomerId = BookingVenue.CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingDetails bookdetails = new BookingDetails()
                                {
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    CustomerContact = double.Parse(reader["CustomerContact"].ToString()),
                                    VenueName = reader["VenueName"].ToString(),
                                    VenueCost = double.Parse(reader["VenueCost"].ToString()),
                                    BookDate = DateTime.Parse(reader["BookDate"].ToString())
                                };
                                bookdetailslist.Add(bookdetails);
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

            return bookdetailslist;
        }

    }
}
