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
    public partial class index : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=news_service;User Id=root;password=''");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM users WHERE username='" + username.Text + "' and password='" + password.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Session["username"] = dr["username"].ToString();
                Response.Redirect("indexLogged.aspx");
            }
            conn.Close();

        }

    }
}