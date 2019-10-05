using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BOL;
using DAL;
namespace DAL
{
    public class DBConnect
    {
        public MySqlConnection connection;
        public string server;
        public string database;
        public string uid;
        public string password;

        public object MessageBox { get; private set; }

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            server = "localhost";
            database = "EventManagement";
            uid = "root";
            password = "swap123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                ex.GetBaseException();
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

    }
}





public class MySqlDBTest 
{
    //  private static MySqlConnection connection;
    
        DBConnect db = new DBConnect();
   
        public List<AdminRegistration> GetAll()
    {
        
        string query = "select * from AdminRegistration ;";
        List<AdminRegistration> datalist = new List<AdminRegistration>();
        try
        {
            if (db.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AdminRegistration data = new AdminRegistration()
                            {
                                AdminId = int.Parse(reader["AdminId"].ToString()),
                                AdminEmail = reader["AdminEmail"].ToString(),
                                AdminPassword = reader["AdminPassword"].ToString(),
                                AdminName = reader["AdminName"].ToString(),
                                AdminContact = float.Parse(reader["AdminContact"].ToString())
                            };
                            datalist.Add(data);
                        }
                        reader.Close();

                    }

                }
                db.connection.Close();
            }
            

        }
        catch (Exception ex) { throw ex; }
        return datalist;

    }

}

