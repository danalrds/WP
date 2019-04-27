using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8ASP
{
    public partial class addNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //{
            //    Response.Redirect("index.aspx");
            //}
        }
        protected void addNewsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}