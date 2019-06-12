using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DoSignUp(object sender, EventArgs e)
        {

            utils.DbUtils db = new utils.DbUtils();
            db.addUser(username.Text, password.Text);
           
                Response.Redirect("Login.aspx");
        }
}
}