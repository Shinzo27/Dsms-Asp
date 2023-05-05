using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;

namespace Dsms
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            int pin = Convert.ToInt32(txtPin.Text);
            string query = "select * from Pincode where Pincode='" + pin + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            if(dr.Read())
            {
                Session["email"] = txtEmail.Text;
                Session["contact"] = txtContact.Text;
                Session["address"] = txtAddress.Text;
                Label1.Visible = true;
                Label1.Text = "Available!";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Not Available!";
            }
        }
    }
}