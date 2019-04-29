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
    public partial class updateNews : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=news_service;User Id=root;password=''");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }

        }
        protected void updateNewsButton_Click(object sender, EventArgs e)
        {
            String date = System.DateTime.Now.ToString("yyyy-MM-dd");
            String username = Session["username"].ToString();
            String currentUser = getUserFromNews(title.Text);
            if (currentUser == username)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;                
                cmd.CommandText = "UPDATE news SET text='" + text.Text + "', date='"+date+"' WHERE title='"+title.Text+"';";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Response.Redirect("indexLogged.aspx");
        }
        protected String getUserFromNews(String title)
        {
            conn.Open();
            MySqlCommand com = conn.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT u.username FROM users u INNER JOIN news n ON n.producer=u.id WHERE n.title='" + title + "'";
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            da.Fill(dt);
            conn.Close();
            return dt.Rows[0]["username"].ToString();
        }
    }
}