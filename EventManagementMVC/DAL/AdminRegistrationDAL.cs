using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using BOL;
namespace DAL
{
    public class AdminRegistrationDAL
    {
 
            private static string conString = string.Empty;
        static AdminRegistrationDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(AdminRegistration adminReg)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into AdminRegistration(AdminId,AdminEmail,AdminPassword,AdminName,AdminContact)" +
                        "Values(@AdminId,@AdminEmail,@AdminPassword,@AdminName,@AdminContact)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@AdminId", adminReg.AdminId));
                    cmd.Parameters.Add(new SqlParameter("@AdminEmail", adminReg.AdminEmail));
                    cmd.Parameters.Add(new SqlParameter("@AdminPassword", adminReg.AdminPassword));
                    cmd.Parameters.Add(new SqlParameter("@AdminName", adminReg.AdminName));
                    cmd.Parameters.Add(new SqlParameter("@AdminContact", adminReg.AdminContact));
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


        public static bool Check(int AdminId, string AdminPassword)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM AdminRegistration WHERE AdminId=@AdminId and AdminPassword = @AdminPassword";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@AdminId", AdminId));
                    cmd.Parameters.Add(new SqlParameter("@AdminPassword", AdminPassword));
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



        public static bool Update(AdminRegistration adminReg)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE AdminRegistration SET AdminEmail=@AdminEmail, " +
                        "AdminPassword=@AdminPassword, AdminName=@AdminName, AdminContact=@AdminContact" +
                        "WHERE AdminId=@AdminId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@AdminId", adminReg.AdminId));
                    cmd.Parameters.Add(new SqlParameter("@AdminEmail", adminReg.AdminEmail));
                    cmd.Parameters.Add(new SqlParameter("@AdminPassword", adminReg.AdminPassword));
                    cmd.Parameters.Add(new SqlParameter("@AdminName", adminReg.AdminName));
                    cmd.Parameters.Add(new SqlParameter("@AdminContact", adminReg.AdminContact));
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






        public static List<AdminRegistration> GetAll()
        {
            List<AdminRegistration> adminReg = new List<AdminRegistration>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM AdminRegistration";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                AdminRegistration adminData = new AdminRegistration()
                                {
                                    AdminId = int.Parse(reader["AdminId"].ToString()),
                                    AdminEmail = reader["AdminEmail"].ToString(),
                                    AdminPassword = reader["AdminPassword"].ToString(),
                                    AdminName = reader["AdminName"].ToString(),
                                    AdminContact = float.Parse(reader["AdminContact"].ToString()),
                                };
                                adminReg.Add(adminData);
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

            return adminReg;
        }
    }
}





