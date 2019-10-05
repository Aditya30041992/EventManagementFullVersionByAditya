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
    public class FoodDetailsDAL
    {

        private static string conString = string.Empty;
        static FoodDetailsDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

        }

        public static bool Insert(FoodDetails foodDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string qyery = "Insert into FoodDetails(FoodId,FoodName,FoodCost)" +
                        "Values(@FoodId,@FoodName,@FoodCost)";
                    SqlCommand cmd = new SqlCommand(qyery, con);
                    cmd.Parameters.Add(new SqlParameter("@FoodId", foodDetails.FoodId));
                  //  cmd.Parameters.Add(new SqlParameter("@FoodType", foodDetails.FoodType));
                  //  cmd.Parameters.Add(new SqlParameter("@MealType", foodDetails.MealType));
                  //  cmd.Parameters.Add(new SqlParameter("@DishType", foodDetails.DishType));
                    cmd.Parameters.Add(new SqlParameter("@FoodName", foodDetails.FoodName));
                 //   cmd.Parameters.Add(new SqlParameter("@FoodFileName", foodDetails.FoodFileName));
                 //   cmd.Parameters.Add(new SqlParameter("@FoodFilePath", foodDetails.FoodFilePath));
                   // cmd.Parameters.Add(new SqlParameter("@CreatedBy", foodDetails.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@FoodCost", foodDetails.FoodCost));

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




        public static bool Update(string FoodId, FoodDetails foodDetails)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE FoodDetails SET " +
                        "FoodName=@FoodName, FoodCost=@FoodCost " +
                        "WHERE FoodId=@FoodId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@FoodId", foodDetails.FoodId));
                  //  cmd.Parameters.Add(new SqlParameter("@FoodType", foodDetails.FoodType));
                  //  cmd.Parameters.Add(new SqlParameter("@MealType", foodDetails.MealType));
                  //  cmd.Parameters.Add(new SqlParameter("@DishType", foodDetails.DishType));
                    cmd.Parameters.Add(new SqlParameter("@FoodName", foodDetails.FoodName));
                  //  cmd.Parameters.Add(new SqlParameter("@FoodFileName", foodDetails.FoodFileName));
                   // cmd.Parameters.Add(new SqlParameter("@FoodFilePath", foodDetails.FoodFilePath));
                   // cmd.Parameters.Add(new SqlParameter("@CreatedBy", foodDetails.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@FoodCost", foodDetails.FoodCost));

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

        public static bool Delete(string FoodId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from FoodDetails where FoodId=@FoodId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@FoodId", FoodId));
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


        public static List<FoodDetails> Get(int CustomerId)
        {
            List<FoodDetails> foodlist = new List<FoodDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select FoodName, FoodCost from FoodDetails, BookFood " +
                        "where ( FoodDetails.FoodId = BookFood.FoodType or FoodDetails.FoodId = BookFood.MealType or FoodDetails.FoodId = BookFood.DishType or FoodDetails.FoodId = BookFood.DishName ) " +
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
                                FoodDetails food = new FoodDetails()
                                {
                                    FoodName = reader["FoodName"].ToString(),
                                    FoodCost = int.Parse(reader["FoodCost"].ToString())
                                };
                                foodlist.Add(food);
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
            return foodlist;
        }


        public static List<FoodDetails> GetAll()
        {
            List<FoodDetails> foodDetailsList = new List<FoodDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM FoodDetails";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FoodDetails foodDetails = new FoodDetails()
                                {
                                    FoodId = reader["FoodId"].ToString(),
                                    //FoodType = reader["FoodType"].ToString(),
                                    //MealType = reader["MealType"].ToString(),
                                    //DishType = reader["DishType"].ToString(),
                                    FoodName = reader["FoodName"].ToString(),
                                    //FoodFileName = reader["FoodFileName"].ToString(),
                                    //FoodFilePath = reader["FoodFilePath"].ToString(),
                                   // CreatedBy = reader["CreatedBy"].ToString(),
                                    FoodCost = int.Parse(reader["FoodCost"].ToString())



                                };
                                foodDetailsList.Add(foodDetails);
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

            return foodDetailsList;
        }


    }
}
