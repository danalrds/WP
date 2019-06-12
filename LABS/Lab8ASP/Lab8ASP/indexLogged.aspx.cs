using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace Lab8ASP
{
    public partial class indexlogged : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        MySqlConnection conn = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=news_service;User Id=root;password=''");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
            String category = Request.QueryString["category"];
            String startDate = "";
            String endDate = "";
            if (Request.QueryString["startDate"] != null)
            {
                startDate = Request.QueryString["startDate"];

            }
            if (Request.QueryString["endDate"] != null)
            {
                endDate = Request.QueryString["endDate"];
            }
            String sql = "";
            conn.Open();
            if (category == null)
            {
                category = "all";
            }
            if (category.Equals("all"))
            {
                if ((startDate != "") && (endDate != ""))
                {
                    sql = "SELECT n.title, n.text, n.date, u.username, c.cname FROM news n INNER JOIN users u ON n.producer=u.id INNER JOIN  categories c " +
                        "ON c.id=n.cid WHERE n.date BETWEEN '" + startDate + "' AND '" + endDate + "';";

                }
                else
                {
                    sql = "SELECT n.title, n.text, n.date, u.username, c.cname FROM news n INNER JOIN users u ON n.producer=u.id INNER JOIN  categories c ON c.id=n.cid;";

                }
            }
            else
            {
                if ((startDate != "") && (endDate != ""))
                {
                    sql = "SELECT n.title, n.text, n.date, u.username, c.cname FROM news n INNER JOIN users u ON n.producer=u.id INNER JOIN  categories c ON c.id=n.cid" +
                   " WHERE c.cname='" + category + "' AND n.date BETWEEN '" + startDate + "' AND '" + endDate + "';";


                }
                else
                {
                    sql = "SELECT n.title, n.text, n.date, u.username, c.cname FROM news n INNER JOIN users u ON n.producer=u.id INNER JOIN  categories c ON c.id=n.cid" +
                    " WHERE c.cname='" + category + "';";
                }
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Title</th> <th>Text</th> <th>Date</th> <th>Producer</th> <th>Category</th></tr>");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + reader[0] + "</td>");
                    table.Append("<td>" + reader[1] + "</td>");
                    table.Append("<td>" + ((DateTime)reader[2]).ToString("yyyy-MM-dd") + "</td>");
                    table.Append("<td>" + reader[3] + "</td>");
                    table.Append("<td>" + reader[4] + "</td>");
                    table.Append("</tr>");
                }
            }
            table.Append("</table>");
            placeHolder1.Controls.Clear();
            placeHolder1.Controls.Add(new Literal { Text = table.ToString() });
            reader.Close();
            conn.Close();

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addNews.aspx");
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateNews.aspx");
        }
        protected void filterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("indexLogged.aspx?category=" + dropDownListIndex.SelectedValue + "&startDate=" + startDate.Text + "&endDate=" + endDate.Text);
        }
    }
}