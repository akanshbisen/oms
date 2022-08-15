using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;


namespace DAL
{
    public class AdminDao
    {
        public static string conString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        public static MySqlConnection con = new MySqlConnection(conString);
        public static MySqlCommand cmd = new MySqlCommand();
       
        public static bool Validate(string email, string password)
        {
            bool status = false;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from admin where email='" + email + "'and password='" + password + "'";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                reader.Close();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }
        
    }
}
