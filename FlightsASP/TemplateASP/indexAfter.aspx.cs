using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateASP
{
    public partial class indexAfter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            utils.DbUtils db = new utils.DbUtils();
            string res=db.selectPopular();
            string p = "<p>" + res + "</p>";    
            confP.Controls.Clear();
            confP.Controls.Add(new Literal { Text = p.ToString() });

        }
    }
}