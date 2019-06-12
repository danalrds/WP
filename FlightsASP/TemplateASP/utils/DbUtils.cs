using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateASP.utils
{
    public class DbUtils
    {
        string myConnectionString = "server=localhost;uid=root;pwd=;database=flights;";
        public int getIdOfFlight(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from flights where name='" + name+ "'";
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

        public int getIdOfHotel(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from hotels where name='" + name + "'";
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

        public int getIdOfConference(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from conferences where name='" + name + "'";
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

        public bool areSlots(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from conferences where name='" + name + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    if (myreader.GetInt32("slots") > 0)
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


        public string selectPopular()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT c.city, Count(*) as counter FROM conferences c INNER JOIN conferencerez cr ON c.id=cr.confid " +
                    "GROUP BY c.name ORDER BY counter DESC";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    return myreader.GetString("city");
                }
                myreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }
            return "";

        }

        public List<String> selectFlights(string departure, string destination, string date)
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
                cmd.CommandText = "select * from flights WHERE departure='"+departure+"' AND destination='"+destination+"' AND date='"+date+"'";
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

        public List<String> selectHotels (string date, string city)
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
                cmd.CommandText = "select * from hotels WHERE date='" + date+ "' AND city='"+city+"'";
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

        public List<String> selectConferences(string date, string city)
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
                cmd.CommandText = "select * from conferences WHERE date='" + date + "' AND city='"+city+"'";
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


        public void addRezervation(int id, string username)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into flightrez(flightid,client) values ('" + id.ToString() + "','" + username.ToString() + "');";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }


        public void addRezervationHotel(int id, string username)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into hotelrez(hotelid,client) values ('" + id.ToString() + "','" + username.ToString() + "');";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }

        public void addRezervationConference(int id, string username)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into conferencerez(confid,client) values ('" + id.ToString() + "','" + username.ToString() + "');";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }
        public void decreaseSeatsFlight(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update flights set seats=seats-1 WHERE id=" +id.ToString()+";";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }

        public void decreaseSeatsHotel(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update hotels set rooms=rooms-1 WHERE id=" + id.ToString() + ";";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }

        public void decreaseSeatsConference(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update conferences set slots=slots-1 WHERE id=" + id.ToString() + ";";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

        }

        public void cancelAnything(string username, string hotel, string flight)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from  hotelrez WHERE client='" + username.ToString() + "';";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from  flightrez WHERE client='" + username.ToString() + "';";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update hotels set rooms=rooms+1 WHERE name='" + hotel.ToString() + "';";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update flights set seats=seats+1 WHERE name='" + flight.ToString() + "';";
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