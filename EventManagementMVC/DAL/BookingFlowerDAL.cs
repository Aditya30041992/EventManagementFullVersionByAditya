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
    public class BookingFlowerDAL
    {
        private static string conString = string.Empty;
        static BookingFlowerDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(BookingFlower bookflw)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into BookingFlower(FlowerId,CustomerId) " +
                        "Values(@FlowerId,@CustomerId)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@FlowerId", bookflw.FlowerId));
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", bookflw.CustomerId));


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




        public static bool Update(string CustomerId, BookingFlower bookflw)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE BookingFlower SET FlowerId=@FlowerId, " +
                        "WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@FlowerId", bookflw.FlowerId));
                  //  cmd.Parameters.Add(new SqlParameter("@CustomerId", bookflw.CustomerId));

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
                    string query = "delete from BookingFlower where CustomerId=@CustomerId";
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




        public static List<BookingFlower> GetAll()
        {
            List<BookingFlower> bookflwlist = new List<BookingFlower>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookingFlower";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookingFlower bookflw = new BookingFlower()
                                {
                                    FlowerId = reader["FlowerId"].ToString(),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),

                                };
                                bookflwlist.Add(bookflw);
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

            return bookflwlist;
        }
    }
}
