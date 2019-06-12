using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateASP.utils
{
    public class DbUtils
    {
        string myConnectionString = "server=localhost;uid=root;pwd=;database=news_service;";
        public bool findUser(string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + username + "' AND password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    return true;
                }
                myreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return false;

        }

        public List<String> selectUsers()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            List<String> slist = new List<String>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetString("username"));
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return slist;

        }

        public void addUser(string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into users(username, password) values ('" + username.ToString() + "','" + password.ToString() + "');";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }
      

    }
}