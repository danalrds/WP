using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateASP.utils
{
    public class DbUtils
    {
        string myConnectionString = "server=localhost;uid=root;pwd=;database=urls;";
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

        public string getNameOfUserId(int userId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where id='" + userId + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    return myreader.GetString("username");
                }
                myreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return "no";

        }


        public List<Url> getAllUrls(string username)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            List<Url> slist = new List<Url>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from urls WHERE owner!='" + username + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    System.Diagnostics.Debug.Write("In for stuff");
                    Url url = new Url(myreader.GetInt32("id"), myreader.GetString("url"), myreader.GetString("owner"), myreader.GetString("sharingusers"));
                    slist.Add(url);
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

        public List<String> getSharedUrls(string username)
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
                cmd.CommandText = "select * from urls WHERE sharingusers LIKE '" + "%" + username + "%'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetString("url"));
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

        public List<string> getLikedUrls(string username)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            List<string> slist = new List<string>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users WHERE username='" + username + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string s = myreader.GetString("likes");
                    string[] vals = s.Split(',');
                    for(int i=0;i<vals.Length-1;i++)
                        slist.Add(vals[i]);
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


        public List<String> getUrlsOfUser(string username)
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
                cmd.CommandText = "select * from urls WHERE owner='"+username+"'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetString("url"));
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
        public bool hasNotLiked(string username, string owner, string url) {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string pattern = owner + " " + url;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where likes LIKE '"+"%"+pattern+"%'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    return false;
                }
                myreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return true;

        }


        public bool addLike(string username, string owner, string url)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                if (hasNotLiked(username, owner, url)){
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update users set likes=concat(likes,'" + owner + " ',+'" + url + ",') WHERE username='" + username + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true; }
                else
                    return false;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return false;

        }

        public void addShare(string username, int urlId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            { 
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update urls set sharingusers=concat(sharingusers,'" + username+ ",') WHERE id='" + urlId + "'";
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