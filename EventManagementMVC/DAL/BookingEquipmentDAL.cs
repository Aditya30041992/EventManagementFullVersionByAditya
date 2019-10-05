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
    public class BookingEquipmentDAL
    {
        private static string conString = string.Empty;
        static BookingEquipmentDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(BookingEquipment bookeqp)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into BookingEquipment(EquipmentId,CustomerId) " +
                        "Values(@EquipmentId, @CustomerId)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", bookeqp.EquipmentId));
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", bookeqp.CustomerId));
                 

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




        public static bool Update(string CustomerId, BookingEquipment bookeqp)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE BookingEquipment SET EquipmentId=@EquipmentId, " +
                        "WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@EquipmentId", bookeqp.EquipmentId));
               //     cmd.Parameters.Add(new SqlParameter("@CustomerId", bookeqp.CustomerId));

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
                    string query = "delete from BookingEquipment where CustomerId=@CustomerId";
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


        public static List<BookingEquipment> GetByID(string CustomerId)
        {
            List<BookingEquipment> bookeqplist = new List<BookingEquipment>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingEquipment where CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingEquipment bookeqp = new BookingEquipment()
                                {
                                    EquipmentId = reader["EquipmentId"].ToString(),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),

                                };
                                bookeqplist.Add(bookeqp);
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

            return bookeqplist;
        }
    




public static List<BookingEquipment> GetAll()
        {
            List<BookingEquipment> bookeqplist = new List<BookingEquipment>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingEquipment";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingEquipment bookeqp = new BookingEquipment()
                                {
                                    EquipmentId = reader["EquipmentId"].ToString(),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                   
                                };
                                bookeqplist.Add(bookeqp);
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

            return bookeqplist;
        }
    }
}
