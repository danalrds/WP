using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class rezerveHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string showHotels(string username, string date, string city)
        {
            System.Diagnostics.Debug.Write(date);
            System.Diagnostics.Debug.Write(username);
            string html = "<tr><td>Flight Name</td><th></th></tr>";
            utils.DbUtils dbUtils = new utils.DbUtils();
            List<String> hotels = dbUtils.selectHotels(date, city);
            for (int i = 0; i < hotels.Count; i++)
            {
                html += "<tr><td>" + hotels[i] + "</td>"
                    + "<td onclick =\"rezerveHotel('" + username + "','" + hotels[i] + "')\">Rezerve</td></tr>";
            }
          
            return html;
        }


        [WebMethod]
        public static void addRezervation(string username, string hotelName)
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            int id = dbUtil.getIdOfHotel(hotelName);
            dbUtil.addRezervationHotel(id, username);
            dbUtil.decreaseSeatsHotel(id);
            HttpContext.Current.Session["hotel"] =hotelName;
        }
    }
}