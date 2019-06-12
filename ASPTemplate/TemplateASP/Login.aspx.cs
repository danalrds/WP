using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TemplateASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void DoLogin(object sender, EventArgs e)
        {
            Console.WriteLine("YUHUUU");
            utils.DbUtils db = new utils.DbUtils();
            if (db.findUser(username.Text, password.Text)) {
                Console.WriteLine("YUHUUU FOUND");
                Session["username"] = username.Text;
                Response.Redirect("indexLogged.aspx");
            }
        }
    }
}