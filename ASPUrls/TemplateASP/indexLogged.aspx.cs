using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class indexLogged : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                utils.DbUtils dbUtils = new utils.DbUtils();
                string username = Session["username"].ToString();
                List<string> urls = dbUtils.getUrlsOfUser(username);
                System.Text.StringBuilder table = new System.Text.StringBuilder();
                table.Append("<table border='1'>");
                table.Append("<tr><th>Url</th></tr>");
                for (int i = 0; i < urls.Count; i++)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + urls[i] + "</td>");
                    table.Append("</tr>");
                }
                table.Append("</table>");
                urlsTable.Controls.Clear();
                urlsTable.Controls.Add(new Literal { Text = table.ToString() });
            }
        }
        [WebMethod]
        public static string selectAllUrls(string username)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>Username</th><th></th></tr>";
            List<Url> slist = dbUtil.getAllUrls(username);
            for (int i = 0; i < slist.Count; i++)
            {
                html += "<tr><td>" + slist[i].url + "</td><td onclick=\"addLike('" + username + "','" + slist[i].owner + "','" + slist[i].url + "')\">Like</td>" 
                    +"<td onclick =\"addShare('" + username + "','" + slist[i].id +"')\">Share</td>" +
                    "</tr>";
            }
            return html;
        }

        [WebMethod]
        public static string selectLiked(string username)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>Username</th><th>Owner</th></tr>";
            List<string> slist = dbUtil.getLikedUrls(username);
            for (int i = 0; i < slist.Count; i++)
            {
                string[] vals = slist[i].Split(' ');
                html += "<tr><td>" + vals[1] + "</td><td>" + vals[0] + "</td><td</tr>";
            }
            return html;
        }

        [WebMethod]
        public static string sharedUrls(int userId)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>Shared Url</th></tr>";
            String username = dbUtil.getNameOfUserId(userId);
            if (username == "no")
                return "";
            else
            {
                List<string> slist = dbUtil.getSharedUrls(username);
                for (int i = 0; i < slist.Count; i++)
                {
                    html += "<tr><td>" + slist[i] + "</td><td</tr>";
                }
                return html;
            }
        }

        [WebMethod]
        public static string addLike(string username, string owner, string url)
        {
            Console.WriteLine(username, owner, url);
            utils.DbUtils dbUtil = new utils.DbUtils();
            if (dbUtil.addLike(username, owner, url))
                return "yes";
            else
                return "no";

        }

        [WebMethod]
        public static void addShare(string username, int urlId)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            dbUtil.addShare(username, urlId) ;

        }
    }
}