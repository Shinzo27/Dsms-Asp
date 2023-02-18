using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsms.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["adminloggedin"] == null)
            {
                Response.Redirect("../index.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["adminloggedin"] = null;
            Response.Redirect("../login.aspx");
        }
    }
}