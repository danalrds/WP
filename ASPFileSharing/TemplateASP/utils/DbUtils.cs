using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateASP.utils
{
    public class DbUtils
    {
        string myConnectionString = "server=localhost;uid=root;pwd=;database=file_sharing;";
        public int getId(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from files where file='" + name + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    return myreader.GetInt32("id");
                }
                myreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return 0;

        }

        public List<string> getFiles(string keywords)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;

            List<string> finalList = new List<string>();
            List<Tuple<string, int>> slist = new List<Tuple<string, int>>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string[] vals = keywords.Split(',');
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from files";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string fileName = myreader.GetString("file");
                    string keys = myreader.GetString("keywords");
                    int counter = 0;
                    for (int i = 0; i < vals.Count() - 1; i++)
                    {
                        if (keywords.Contains(vals[i]))
                        {
                            counter++;
                        }
                    }
                    if (counter > 0)
                    {
                        var myTuple = Tuple.Create(fileName, counter);
                        slist.Add(myTuple);
                    }
                    slist.Sort((x, y) => x.Item1.CompareTo(y.Item1));
                    finalList = slist.Select(t => t.Item1).ToList();
                    System.Diagnostics.Debug.Write(slist);
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return finalList;

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

        public List<int> getChunksFile(int fileId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            List<int> slist = new List<int>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from chunks WHERE fileid=" + fileId + "";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetInt32("id"));
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

        public List<String> getPeersChunk(int id)
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
                cmd.CommandText = "select * from peers WHERE chunks LIKE '" + "%" + id.ToString() + "%'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetString("name"));
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

        public List<String> getPeers()
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
                cmd.CommandText = "select * from peers";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {

                    slist.Add(myreader.GetString("name"));
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

        public bool addLike(string username, string owner, string url)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update users set likes=concat(likes,'" + owner + " ',+'" + url + ",') WHERE username='" + username + "'";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return false;

        }

    }
}