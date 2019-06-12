using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class rezerveFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string showFlights(string username, string departure, string destination, string date) {
            string html = "<tr><td>Flight Name</td><th></th></tr>";
            utils.DbUtils dbUtils = new utils.DbUtils();
            List<String> flights = dbUtils.selectFlights(departure, destination, date);
            for (int i = 0; i < flights.Count; i++)
            {
                html += "<tr><td>" + flights[i] + "</td>" 
                    +"<td onclick =\"rezerveFlight('" + username + "','" + flights[i] + "')\">Rezerve</td></tr>";
            }
            HttpContext.Current.Session["date"] = date;
            HttpContext.Current.Session["city"] = destination;
            System.Diagnostics.Debug.Write(HttpContext.Current.Session["city"]);
            return html;
        }

        [WebMethod]
        public static void addRezervation(string username, string flightName)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            int id = dbUtil.getIdOfFlight(flightName);
            dbUtil.addRezervation(id,username);
            dbUtil.decreaseSeatsFlight(id);
            HttpContext.Current.Session["flight"] = flightName;
        }
    }
}