using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8ASP
{
    public partial class updateNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }

        }
        protected void updateNewsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("indexLogged.aspx");
        }
    }
}