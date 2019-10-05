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
    public class LightDetailsDAL
    {

        private static string conString = string.Empty;
        static LightDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(LightDetails lightdetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into LightDetails(LightId,LightName,LightCost) " +
                        "Values(@LightId,@LightName,@LightCost)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@LightId", lightdetails.LightId));
                    //cmd.Parameters.Add(new SqlParameter("@LightType", lightdetails.LightType));
                    cmd.Parameters.Add(new SqlParameter("@LightName", lightdetails.LightName));
                    //cmd.Parameters.Add(new SqlParameter("@LightFileName", lightdetails.LightFileName));
                    //cmd.Parameters.Add(new SqlParameter("@LightFilePath", lightdetails.LightFilePath));
                    cmd.Parameters.Add(new SqlParameter("@LightCost", lightdetails.LightCost));
                    //cmd.Parameters.Add(new SqlParameter("@LightCreatedBy", lightdetails.LightCreatedBy));
                   

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




        public static bool Update(string LightId, LightDetails lightdetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE LightDetails SET LightName=@LightName," +
                        " LightCost=@LightCost " +
                        "WHERE LightId=@LightId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@LightId", lightdetails.LightId));
                   // cmd.Parameters.Add(new SqlParameter("@LightType", lightdetails.LightType));
                    cmd.Parameters.Add(new SqlParameter("@LightName", lightdetails.LightName));
                    //cmd.Parameters.Add(new SqlParameter("@LightFileName", lightdetails.LightFileName));
                    //cmd.Parameters.Add(new SqlParameter("@LightFilePath", lightdetails.LightFilePath));
                    cmd.Parameters.Add(new SqlParameter("@LightCost", lightdetails.LightCost));
                  //  cmd.Parameters.Add(new SqlParameter("@LightCreatedBy", lightdetails.LightCreatedBy));

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


        public static bool Delete(string LightId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from LightDetails where LightId=@LightId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@LightId", LightId));
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

        public static List<LightDetails> Get(int CustomerId)
        {
            List<LightDetails> lightlist = new List<LightDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select LightName, LightCost from LightDetails, BookingLight " +
                        "where (LightDetails.LightId = BookingLight.LightNameID or LightDetails.LightId = BookingLight.LightType) " +
                        "and CustomerId = @CustomerId ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LightDetails light = new LightDetails()
                                {
                                    LightName = reader["LightName"].ToString(),
                                    LightCost = int.Parse(reader["LightCost"].ToString()),
                                };
                                lightlist.Add(light);
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
            return lightlist;
        }


        public static List<LightDetails> GetAll()
        {
            List<LightDetails> lightdetailslist = new List<LightDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM LightDetails";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LightDetails lightdetails = new LightDetails()
                                {
                                    LightId = reader["LightId"].ToString(),
                                    //LightType = reader["LightType"].ToString(),
                                    LightName = reader["LightName"].ToString(),
                                    //LightFileName = reader["LightFileName"].ToString(),
                                    //LightFilePath = reader["LightFilePath"].ToString(),
                                    LightCost = int.Parse(reader["LightCost"].ToString()),
                                 //   LightCreatedBy = reader["LightCreatedBy"].ToString(),
                              
                                };
                                lightdetailslist.Add(lightdetails);
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

            return lightdetailslist;
        }

    }
}
