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
    public class CustomerRegistrationDAL
    {
            private static string conString = string.Empty;
            static CustomerRegistrationDAL()
            {
                conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

            }

            public static bool Insert(CustomerRegistration customerReg)
            {
                bool status = false;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string qyery = "Insert into CustomerRegistration(CustomerId,CustomerName,CustomerAddress,CustomerContact,CustomerCity,CustomerEmail,CustomerPassword,CustomerConfirmPassword,CustomerGender)" +
                            "Values(@CustomerId,@CustomerName,@CustomerAddress,@CustomerContact,@CustomerCity,@CustomerEmail,@CustomerPassword,@CustomerConfirmPassword,@CustomerGender);";
                        SqlCommand cmd = new SqlCommand(qyery, con);
                        cmd.Parameters.Add(value:new SqlParameter("@CustomerId", customerReg.CustomerId));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerName", customerReg.CustomerName));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerAddress", customerReg.CustomerAddress));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerContact", customerReg.CustomerContact));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerCity", customerReg.CustomerCity));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerEmail", customerReg.CustomerEmail));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerPassword", customerReg.CustomerPassword));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerConfirmPassword", customerReg.CustomerConfirmPassword));
                        cmd.Parameters.Add(value: new SqlParameter("@CustomerGender", customerReg.CustomerGender));
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


            public static CustomerRegistration Check(int CustomerId, string CustomerPassword)
            {
            //CustomerRegistration customerslist = new CustomerRegistration();
            CustomerRegistration customers = null;
            try
            {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "SELECT * FROM CustomerRegistration WHERE CustomerId=@CustomerId and CustomerPassword = @CustomerPassword";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerPassword", CustomerPassword));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                                customers = new CustomerRegistration()
                                {
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    CustomerAddress = reader["CustomerAddress"].ToString(),
                                    CustomerContact = double.Parse(reader["CustomerContact"].ToString()),
                                    CustomerCity = reader["CustomerCity"].ToString(),
                                    CustomerEmail = reader["CustomerEmail"].ToString(),
                                    CustomerPassword = reader["CustomerPassword"].ToString(),
                                    CustomerConfirmPassword = reader["CustomerConfirmPassword"].ToString(),
                                    CustomerGender = reader["CustomerGender"].ToString(),


                                };
                            
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

            return customers;
        }



        public static bool Update(CustomerRegistration customerReg)
            {
                bool status = false;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "UPDATE CustomerRegistration SET CustomerName=@CustomerName, CustomerAddress=@CustomerAddress," +
                            "CustomerContact=@CustomerContact, CustomerCity=@CustomerCity, CustomerEmail=@CustomerEmail, CustomerPassword=@CustomerPassword,  CustomerConfirmPassword=@CustomerConfirmPassword, CustomerGender=@CustomerGender " +
                            "WHERE CustomerId=@CustomerId";
                        SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", customerReg.CustomerId));
                    cmd.Parameters.Add(new SqlParameter("@CustomerName", customerReg.CustomerName));
                    cmd.Parameters.Add(new SqlParameter("@CustomerAddress", customerReg.CustomerAddress));
                    cmd.Parameters.Add(new SqlParameter("@CustomerContact", customerReg.CustomerContact));
                    cmd.Parameters.Add(new SqlParameter("@CustomerCity", customerReg.CustomerCity));
                    cmd.Parameters.Add(new SqlParameter("@CustomerEmail", customerReg.CustomerEmail));
                    cmd.Parameters.Add(new SqlParameter("@CustomerPassword", customerReg.CustomerPassword));
                    cmd.Parameters.Add(new SqlParameter("@CustomerConfirmPassword", customerReg.CustomerConfirmPassword));
                    cmd.Parameters.Add(new SqlParameter("@CustomerGender", customerReg.CustomerGender));
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






            public static List<CustomerRegistration> GetAll()
            {
                List<CustomerRegistration> customerslist = new List<CustomerRegistration>();
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "SELECT * FROM CustomerRegistration";
                        SqlCommand cmd = new SqlCommand(query, con);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                CustomerRegistration customers = new CustomerRegistration()
                                    {
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    CustomerAddress = reader["CustomerAddress"].ToString(),
                                    CustomerContact = double.Parse(reader["CustomerContact"].ToString()),
                                    CustomerCity = reader["CustomerCity"].ToString(),
                                    CustomerEmail = reader["CustomerEmail"].ToString(),
                                    CustomerPassword = reader["CustomerPassword"].ToString(),
                                    CustomerConfirmPassword = reader["CustomerConfirmPassword"].ToString(),
                                    CustomerGender = reader["CustomerGender"].ToString(),


                                };
                                customerslist.Add(customers);
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

                return customerslist;
            }


        }
    }
