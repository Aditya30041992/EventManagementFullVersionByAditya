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
    public class BookingLightDAL
    {

        private static string conString = string.Empty;
        static BookingLightDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(BookingLight booklight)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into BookingLight(CustomerId,LightType,LightNameID) " +
                        "Values(@CustomerId,@LightType,@LightNameID)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", booklight.CustomerId));
                    cmd.Parameters.Add(new SqlParameter("@LightType", booklight.LightType));
                    cmd.Parameters.Add(new SqlParameter("@LightNameID", booklight.LightNameID));
                   // cmd.Parameters.Add(new SqlParameter("@LightId", booklight.LightId));


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




        public static bool Update(string CustomerId, BookingLight booklight)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE BookingLight SET LightType=@LightType, LightNameID=@LightNameID " +
                        "WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", booklight.CustomerId));
                    cmd.Parameters.Add(new SqlParameter("@LightType", booklight.LightType));
                    cmd.Parameters.Add(new SqlParameter("@LightNameID", booklight.LightNameID));
                    //cmd.Parameters.Add(new SqlParameter("@LightId", booklight.LightId));

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
                    string query = "delete from BookingLight where CustomerId=@CustomerId";
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




        public static List<BookingLight> GetAll()
        {
            List<BookingLight> booklightlist = new List<BookingLight>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingLight";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingLight booklight = new BookingLight()
                                {
                                    LightType = reader["LightType"].ToString(),
                                    LightNameID = reader["LightNameID"].ToString(),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                   //LightId = int.Parse(reader["LightId"].ToString())

                                };
                                booklightlist.Add(booklight);
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

            return booklightlist;
        }

    }
}
