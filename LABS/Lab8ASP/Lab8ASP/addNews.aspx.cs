using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab8ASP
{
    public partial class addNews : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=news_service;User Id=root;password=''");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void addNewsButton_Click(object sender, EventArgs e)
        {

            String date = System.DateTime.Now.ToString("yyyy-MM-dd");
            String username = Session["username"].ToString();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int producer = getUserId(username);
            int cid = getCategoryId(dropDownList.SelectedValue);
            cmd.CommandText = "INSERT INTO news(text, title, date, cid, producer) VALUES ('" + text.Text + "','" + title.Text + "','" + date
                + "','" + cid.ToString() + "','" + producer.ToString() + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("indexLogged.aspx");
        }
        protected int getUserId(String username)
        {
            MySqlCommand com = conn.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT id FROM users WHERE username='" + username+"'";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            da.Fill(dt);
            int id = (int)dt.Rows[0]["id"];
            return id;
        }
        protected int getCategoryId(String category)
        {
            MySqlCommand com = conn.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT id FROM categories WHERE cname='" + category+"'";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            da.Fill(dt);
            int id = (int)dt.Rows[0]["id"];
            return id;
        }
    }
}