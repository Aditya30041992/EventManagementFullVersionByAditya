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
    public class FlowerDetailsDAL
    {
        private static string conString = string.Empty;
        static FlowerDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(FlowerDetails flwDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into FlowerDetails(FlowerId,FlowerName,FlowerCost) " +
                        "Values(@FlowerId,@FlowerName,@FlowerCost)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@FlowerId", flwDetails.FlowerId));
                    cmd.Parameters.Add(new SqlParameter("@FlowerName", flwDetails.FlowerName));
                   // cmd.Parameters.Add(new SqlParameter("@FlowerFileName", flwDetails.FlowerFileName));
                    //cmd.Parameters.Add(new SqlParameter("@FlowerFilePath", flwDetails.FlowerFilePath));
                    cmd.Parameters.Add(new SqlParameter("@FlowerCost", flwDetails.FlowerCost));
                 //   cmd.Parameters.Add(new SqlParameter("@FlowerCreatedBy", flwDetails.FlowerCreatedBy));
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




        public static bool Update(string FlowerId, FlowerDetails flwDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE FlowerDetails SET FlowerName=@FlowerName," +
                        " FlowerCost=@FlowerCost " +
                        "WHERE FlowerId=@FlowerId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@FlowerId", flwDetails.FlowerId));
                    cmd.Parameters.Add(new SqlParameter("@FlowerName", flwDetails.FlowerName));
                  //  cmd.Parameters.Add(new SqlParameter("@FlowerFileName", flwDetails.FlowerFileName));
                  //  cmd.Parameters.Add(new SqlParameter("@FlowerFilePath", flwDetails.FlowerFilePath));
                    cmd.Parameters.Add(new SqlParameter("@FlowerCost", flwDetails.FlowerCost));
                    //cmd.Parameters.Add(new SqlParameter("@FlowerCreatedBy", flwDetails.FlowerCreatedBy));

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

        public static bool Delete(string FlowerId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from FlowerDetails where FlowerId=@FlowerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@FlowerId", FlowerId));
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


        public static List<FlowerDetails> Get(int CustomerId)
        {
            List<FlowerDetails> datalist = new List<FlowerDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select FlowerName , FlowerCost from FlowerDetails, BookingFlower " +
                        "where FlowerDetails.FlowerId = BookingFlower.FlowerId and CustomerId = @CustomerId ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                FlowerDetails data = new FlowerDetails()
                                {
                                    FlowerName = reader["FlowerName"].ToString(),
                                    FlowerCost = int.Parse(reader["FlowerCost"].ToString())

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

        public static List<FlowerDetails> GetAll()
        {
            List<FlowerDetails> flwDetailsList = new List<FlowerDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM FlowerDetails";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FlowerDetails flwDetails = new FlowerDetails()
                                {
                                    FlowerId = reader["FlowerId"].ToString(),
                                    FlowerName = reader["FlowerName"].ToString(),
                                    //FlowerFileName = reader["FlowerFileName"].ToString(),
                                    //FlowerFilePath = reader["FlowerFilePath"].ToString(),
                                    FlowerCost = int.Parse(reader["FlowerCost"].ToString())
                                   // FlowerCreatedBy = reader["FlowerCreatedBy"].ToString(),


                                };
                                flwDetailsList.Add(flwDetails);
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

            return flwDetailsList;
        }

    }
}
