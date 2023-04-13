using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using Newtonsoft.Json;

namespace Dsms
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        
        public double total;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if (Session["loggedin"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if(Session["total"] == null)
            {
                Response.Redirect("login.aspx");
            }
            total = Convert.ToDouble(Session["total"]) * 100;
            lblTotal.Text = "₹ " + Convert.ToDouble(Session["total"].ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["email"] = txtEmail.Text;
            Session["contact"] = txtContact.Text;
            Session["address"] = txtAddress.Text;
        }
    }
}