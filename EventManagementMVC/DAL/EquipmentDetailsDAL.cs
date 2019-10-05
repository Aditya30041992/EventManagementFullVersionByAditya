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
    public class EquipmentDetailsDAL
    {
        private static string conString = string.Empty;
        static EquipmentDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(EquipmentDetails eqpDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "Insert into EquipmentDetails(EquipmentId,EquipmentNamw,EquipmentCost) " +
                        "Values(@EquipmentId,@EquipmentName,@EquipmentCost)";
                    //string qyery = "Insert into EquipmentDetails(EquipmentId,EquipmentName,EquipmentCost) " +
                      //  "Values(@EquipmentId,@EquipmentName,@EquipmentFileName,@EquipmentFilePath,@EquipmentCost)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", eqpDetails.EquipmentId));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentName", eqpDetails.EquipmentName));
                    //cmd.Parameters.Add(new SqlParameter("@EquipmentFileName", eqpDetails.EquipmentFileName));
                    //cmd.Parameters.Add(new SqlParameter("@EquipmentFilePath", eqpDetails.EquipmentFilePath));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentCost", eqpDetails.EquipmentCost));
                   // cmd.Parameters.Add(new SqlParameter("@EquipmentCreatedBy", eqpDetails.EquipmentCreatedBy));



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




        public static bool Update(string EquipmentId, EquipmentDetails eqpDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE EquipmentDetails SET EquipmentName=@EquipmentName," +
                        " EquipmentCost=@EquipmentCost " +
                        "WHERE EquipmentId=@EquipmentId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", eqpDetails.EquipmentId));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentName", eqpDetails.EquipmentName));
                    //cmd.Parameters.Add(new SqlParameter("@EquipmentFileName", eqpDetails.EquipmentFileName));
                    //cmd.Parameters.Add(new SqlParameter("@EquipmentFilePath", eqpDetails.EquipmentFilePath));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentCost", eqpDetails.EquipmentCost));
                   // cmd.Parameters.Add(new SqlParameter("@EquipmentCreatedBy", eqpDetails.EquipmentCreatedBy));

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


        public static bool Delete(string EquipmentId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from EquipmentDetails where EquipmentId=@EquipmentId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", EquipmentId));
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


        public static List<EquipmentDetails> Get(int CustomerId)
        {
            List<EquipmentDetails> datalist = new List<EquipmentDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select EquipmentName, EquipmentCost from EquipmentDetails, BookingEquipment " +
                        "where EquipmentDetails.EquipmentId = BookingEquipment.EquipmentId and CustomerId = @CustomerId ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                EquipmentDetails data = new EquipmentDetails()
                                {
                                    EquipmentName = reader["EquipmentName"].ToString(),
                                    EquipmentCost = int.Parse(reader["EquipmentCost"].ToString()),

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




        public static List<EquipmentDetails> GetAll()
        {
            List<EquipmentDetails> eqpDetailsList = new List<EquipmentDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM EquipmentDetails";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                EquipmentDetails eqpDetails = new EquipmentDetails()
                                {
                                    EquipmentId = reader["EquipmentId"].ToString(),
                                    EquipmentName = reader["EquipmentName"].ToString(),
                                    //EquipmentFileName = reader["EquipmentFileName"].ToString(),
                                    //EquipmentFilePath = reader["EquipmentFilePath"].ToString(),
                                    EquipmentCost = int.Parse(reader["EquipmentCost"].ToString()),
                           //         EquipmentCreatedBy = reader["EquipmentCreatedBy"].ToString(),


                                };
                                eqpDetailsList.Add(eqpDetails);
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

            return eqpDetailsList;
        }

    }
}
