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
    public class UserDao
    {
        public static string conString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        public static MySqlConnection con = new MySqlConnection(conString);
        public static MySqlCommand cmd = new MySqlCommand();

        public static bool ValidateUser(string email, string password)
        {
            bool status = false;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from user where email='" + email + "'and password='" + password + "'";
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

        public static bool RegisterUser(User u)
        {
            bool status = false;
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into user(first_name,last_name,email,password,address,city,state,country,pincode) values(@fname,@lname,@email,@password,@address,@city,@state,@country,@pincode)";
                cmd.Parameters.AddWithValue("@fname", u.First_Name.ToString());
                cmd.Parameters.AddWithValue("@lname", u.Last_Name.ToString());
                cmd.Parameters.AddWithValue("@email", u.Email.ToString());
                cmd.Parameters.AddWithValue("@password", u.Password.ToString());
                cmd.Parameters.AddWithValue("@address", u.Address.ToString());
                cmd.Parameters.AddWithValue("@city", u.City.ToString());
                cmd.Parameters.AddWithValue("@state", u.State.ToString());
                cmd.Parameters.AddWithValue("@country", u.Country.ToString());
                cmd.Parameters.AddWithValue("@pincode", int.Parse(u.Pincode.ToString()));

                con.Open();
                int linesAffected = cmd.ExecuteNonQuery();
                status = true;
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
