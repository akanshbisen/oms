using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;

namespace DAL
{
    public class ProductDao
    {
        public static string conString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        public static MySqlConnection con = new MySqlConnection(conString);
        public static MySqlCommand cmd = new MySqlCommand();

        public static List<Product> GetAllProducts()
        {
            List<Product> product = new List<Product>();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from products";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Product p = new Product();
                    p.Pid = int.Parse(reader["pid"].ToString());
                    p.Name = reader["name"].ToString();
                    p.Company = reader["company"].ToString();
                    p.Category = reader["category"].ToString();
                    p.Quantity = int.Parse(reader["quantity"].ToString());
                    p.Price = int.Parse(reader["price"].ToString());
                    p.Description = reader["description"].ToString();
                    p.Imgurl = reader["imgurl"].ToString();
                    product.Add(p);

                }
                reader.Close();
                con.Close();

            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return product;
        }
        public static Product GetProductById(int id)
        {
           Product p = null;
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from products where pid=" + id;
                con.Open();
                MySqlDataReader resultSet = cmd.ExecuteReader();
                if (resultSet.Read())
                {
                    p = new Product();
                    p.Pid = int.Parse(resultSet["pid"].ToString());
                    p.Name = resultSet["name"].ToString();
                    p.Company = resultSet["company"].ToString();
                    p.Category = resultSet["category"].ToString();
                    p.Quantity = int.Parse(resultSet["quantity"].ToString());
                    p.Price = int.Parse(resultSet["price"].ToString());
                    p.Description = resultSet["description"].ToString();
                    p.Imgurl = resultSet["imgurl"].ToString();

                }
                resultSet.Close();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return p;
        }
        public static bool InsertMedicine(Product p)
        {
            bool status = false;
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into products(name,company,category,quantity,price,description,imgurl) values(@name,@company,@category,@quantity,@price,@description,@imgurl)";
                cmd.Parameters.AddWithValue("@name", p.Name.ToString());
                cmd.Parameters.AddWithValue("@company",p.Company.ToString());
                cmd.Parameters.AddWithValue("@category", p.Category.ToString());
                cmd.Parameters.AddWithValue("@quantity", int.Parse(p.Quantity.ToString()));
                cmd.Parameters.AddWithValue("@price",int.Parse(p.Price.ToString()));
                cmd.Parameters.AddWithValue("@description", p.Description.ToString());
                cmd.Parameters.AddWithValue("@imgurl", p.Imgurl.ToString());
                
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
        public static bool UpdateMedicine(Product p)
        {
            bool status = false;
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update products set name=@name,company=@company,category=@category,quantity=@quantity,price=@price,description=@description,imgurl=@imgurl where pid=@id";
                cmd.Parameters.AddWithValue("@id", int.Parse(p.Pid.ToString()));
                cmd.Parameters.AddWithValue("@name", p.Name.ToString());
                cmd.Parameters.AddWithValue("@company", p.Company.ToString());
                cmd.Parameters.AddWithValue("@category", p.Category.ToString());
                cmd.Parameters.AddWithValue("@quantity", int.Parse(p.Quantity.ToString()));
                cmd.Parameters.AddWithValue("@price", int.Parse(p.Price.ToString()));
                cmd.Parameters.AddWithValue("@description", p.Description.ToString());
                cmd.Parameters.AddWithValue("@imgurl", p.Imgurl.ToString());
          
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
        public static bool DeleteMedicine(int id)
        {
            bool status = false;
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from products where pid=" + id;
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

        public static List<Product> GetProductByCategory(string category)
        {
            List<Product> list = new List<Product>();
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from products where category=@cat";
                cmd.Parameters.AddWithValue("@cat", category);
                con.Open();
                MySqlDataReader resultSet = cmd.ExecuteReader();
                while (resultSet.Read())
                {
                    Product p = new Product();
                    p.Pid = int.Parse(resultSet["pid"].ToString());
                    p.Name = resultSet["name"].ToString();
                    p.Company = resultSet["company"].ToString();
                    p.Category = resultSet["category"].ToString();
                    p.Quantity = int.Parse(resultSet["quantity"].ToString());
                    p.Price = int.Parse(resultSet["price"].ToString());
                    p.Description = resultSet["description"].ToString();
                    p.Imgurl = resultSet["imgurl"].ToString();
                    list.Add(p);

                }
                resultSet.Close();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        public static List<Product> GetProductBySearch(string search)
        {
            List<Product> list = new List<Product>();
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from products where name=@name or company=@company";
                cmd.Parameters.AddWithValue("@name", search);
                cmd.Parameters.AddWithValue("@company", search);
                con.Open();
                MySqlDataReader resultSet = cmd.ExecuteReader();
                while (resultSet.Read())
                {
                    Product p = new Product();
                    p.Pid = int.Parse(resultSet["pid"].ToString());
                    p.Name = resultSet["name"].ToString();
                    p.Company = resultSet["company"].ToString();
                    p.Category = resultSet["category"].ToString();
                    p.Quantity = int.Parse(resultSet["quantity"].ToString());
                    p.Price = int.Parse(resultSet["price"].ToString());
                    p.Description = resultSet["description"].ToString();
                    p.Imgurl = resultSet["imgurl"].ToString();
                    list.Add(p);

                }
                resultSet.Close();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
    }
}

