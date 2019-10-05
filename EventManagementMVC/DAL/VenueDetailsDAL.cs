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
    public class VenueDetailsDAL
    {
        private static string conString = string.Empty;
        static VenueDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(VenueDetails venuedetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into VenueDetails(VenueId,VenueName,VenueCost,VenueCapacity,VenueContact,VenueAddress) " +
                        "Values(@VenueId,@VenueName,@VenueCost,@VenueCapacity,@VenueContact,@VenueAddress)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@VenueId", venuedetails.VenueId));
                    cmd.Parameters.Add(new SqlParameter("@VenueName", venuedetails.VenueName));
                    //cmd.Parameters.Add(new SqlParameter("@VenueFileName", venuedetails.VenueFileName));
                    //cmd.Parameters.Add(new SqlParameter("@VenueFilePath", venuedetails.VenueFilePath));
                    cmd.Parameters.Add(new SqlParameter("@VenueCost", venuedetails.VenueCost));
                    cmd.Parameters.Add(new SqlParameter("@VenueCapacity", venuedetails.VenueCapacity));
                    cmd.Parameters.Add(new SqlParameter("@VenueContact", venuedetails.VenueContact));
                    cmd.Parameters.AddWithValue("@VenueAddress", venuedetails.VenueAddress);    
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

        


        public static bool Update(string VenueId, VenueDetails venuedetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE VenueDetails SET VenueName=@VenueName," +
                        " VenueCost=@VenueCost, VenueCapacity=@VenueCapacity, VenueContact= @VenueContact, VenueAddress=@VenueAddress " +
                        "WHERE VenueId=@VenueId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@VenueId", venuedetails.VenueId));
                    cmd.Parameters.Add(new SqlParameter("@VenueName", venuedetails.VenueName));
                    //cmd.Parameters.Add(new SqlParameter("@VenueFileName", venuedetails.VenueFileName));
                    //cmd.Parameters.Add(new SqlParameter("@VenueFilePath", venuedetails.VenueFilePath));
                    cmd.Parameters.Add(new SqlParameter("@VenueCost", venuedetails.VenueCost));
                    cmd.Parameters.Add(new SqlParameter("@VenueContact", venuedetails.VenueContact));
                    cmd.Parameters.Add(new SqlParameter("@VenueCapacity", venuedetails.VenueCapacity));
                    cmd.Parameters.Add(new SqlParameter("@VenueAddress", venuedetails.VenueAddress));

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

        public static bool Delete(string VenueId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from VenueDetails where VenueId=@VenueId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@VenueId", VenueId));
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


        public static List<VenueDetails> Get(int CustomerId)
        {
            List<VenueDetails> datalist = new List<VenueDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select VenueName,VenueCost, BookDate from VenueDetails, BookingVenue " +
                        "where VenueDetails.VenueId = BookingVenue.VenueId and CustomerId = @CustomerId ; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                VenueDetails data = new VenueDetails()
                                {
                                    VenueName = reader["VenueName"].ToString(),
                                    VenueCost = int.Parse(reader["VenueCost"].ToString()),
                                    BookDate = DateTime.Parse(reader["BookDate"].ToString()),                                   
                                };
                                datalist.Add(data);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            { throw ex; }
            return datalist;
        }






        public static List<VenueDetails> GetAll()
        {
            List<VenueDetails> venuedetailslist = new List<VenueDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM VenueDetails";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                VenueDetails venuedetails = new VenueDetails()
                                {
                                    VenueId = reader["VenueId"].ToString(),
                                    VenueName = reader["VenueName"].ToString(),
                                    //VenueFileName = reader["VenueFileName"].ToString(),
                                    //VenueFilePath = reader["VenueFilePath"].ToString(),
                                    VenueCost = int.Parse(reader["VenueCost"].ToString()),
                                //    VenueCreatedBy = reader["VenueCreatedBy"].ToString(),
                                    VenueCapacity = int.Parse(reader["VenueCapacity"].ToString()),
                                    VenueContact = double.Parse(reader["VenueContact"].ToString()),
                                    VenueAddress = reader["VenueAddress"].ToString(),

                                };
                                venuedetailslist.Add(venuedetails);
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

            return venuedetailslist;
        }


    }
}
