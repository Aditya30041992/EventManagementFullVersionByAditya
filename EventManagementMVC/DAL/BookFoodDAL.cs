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
    public class BookFoodDAL
    {
        private static string conString = string.Empty;
        static BookFoodDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(BookFood bookfood)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into BookFood(FoodType,MealType,DishType,DishName,CustomerId) " +
                        "Values(@FoodType,@MealType,@DishType,@DishName,@CustomerId)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@FoodType", bookfood.FoodType));
                    cmd.Parameters.Add(new SqlParameter("@MealType", bookfood.MealType));
                    cmd.Parameters.Add(new SqlParameter("@DishType", bookfood.DishType));
                    cmd.Parameters.Add(new SqlParameter("@DishName", bookfood.DishName));
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", bookfood.CustomerId));
                    //cmd.Parameters.Add(new SqlParameter("@FoodId", bookfood.FoodId));

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

        


        public static bool Update(string CustomerId, BookFood bookfood)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE BookFood SET FoodType=@FoodType, " +
                        "MealType=@MealType, DishType=@DishType, DishName=@DishName, " +
                        "WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@FoodType", bookfood.FoodType));
                    cmd.Parameters.Add(new SqlParameter("@MealType", bookfood.MealType));
                    cmd.Parameters.Add(new SqlParameter("@DishType", bookfood.DishType));
                    cmd.Parameters.Add(new SqlParameter("@DishName", bookfood.DishName));
                    //cmd.Parameters.Add(new SqlParameter("@BookingId", bookfood.FoodId));

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
                    string query = "delete from BookFood where CustomerId=@CustomerId";
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




        public static List<BookFood> GetAll()
        {
            List<BookFood> bookfoods = new List<BookFood>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM BookFood";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BookFood bookfood = new BookFood()
                                {
                                    FoodType = reader["FoodType"].ToString(),
                                    MealType = reader["MealType"].ToString(),
                                    DishType = reader["DishType"].ToString(),
                                    DishName = reader["DishName"].ToString(),
                                    CustomerId = int.Parse(reader["CustomerId"].ToString()),
                                    //FoodId = reader["FoodId"].ToString()
                                };
                                bookfoods.Add(bookfood);
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

            return bookfoods;
        }
    }


}

