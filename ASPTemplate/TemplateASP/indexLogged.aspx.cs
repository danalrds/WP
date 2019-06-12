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

        }
        [WebMethod]
        public static string selectUsers()
        {
            utils.DbUtils dbUtil = new utils.DbUtils();
            string html = "<tr><th>Username</th></tr>";
            List<string> slist = dbUtil.selectUsers();
            for (int i = 0; i < slist.Count; i++)
            {
                Console.WriteLine("YUHUUU");
                html += "<tr><td>" + slist[i] + "</td></tr>";
            }
            return html;
        }
    }
}