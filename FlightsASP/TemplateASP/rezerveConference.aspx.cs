using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class rezerveConference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string showConferences(string username, string date, string city)
        {
            System.Diagnostics.Debug.Write(date);
            System.Diagnostics.Debug.Write(username);
            System.Diagnostics.Debug.Write(city);
            string html = "<tr><td>Conference Name</td><th></th></tr>";
            utils.DbUtils dbUtils = new utils.DbUtils();
            List<String> confs = dbUtils.selectConferences(date, city);
            for (int i = 0; i < confs.Count; i++)
            {
                html += "<tr><td>" + confs[i] + "</td>"
                     + "<td onclick =\"rezerveConference('" + username + "','" + confs[i] + "')\">Register</td></tr>";
            }
            return html;
        }

        [WebMethod]
        public static void addRezConf(string username, string confName)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            int id = dbUtil.getIdOfConference(confName);
            if (dbUtil.areSlots(confName))
            {
                System.Diagnostics.Debug.Write("YUHUUUUUUUUUU");
                dbUtil.addRezervationConference(id, username);
                dbUtil.decreaseSeatsConference(id);
            }
            else
            {
                dbUtil.cancelAnything(username, HttpContext.Current.Session["hotel"].ToString(), HttpContext.Current.Session["flight"].ToString());
            }
        }
    }
}