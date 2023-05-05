using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Dsms.admin
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-B85NU0HM\\SQLEXPRESS;Initial Catalog=dbDsms;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if (Session["adminloggedin"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                totalSale();
                totalProducts();
                totalUser();
                totalLq();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["adminloggedin"] = null;
            Response.Redirect("../index.aspx");
        }

        public void totalSale()
        {
            con.Open();
            string query = "SELECT SUM(total) as total FROM tblOrderDetails";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblSale.Text = dr["total"].ToString();
            }
            dr.Close();
        }

        public void totalProducts()
        {
            string query = "SELECT COUNT(pname) as product FROM tblProduct ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblProduct.Text = dr["product"].ToString();
            }
            dr.Close();
        }

        public void totalUser()
        {
            string query = "SELECT COUNT(username) as us FROM tblUser";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblUser.Text = dr["us"].ToString();
            }
            dr.Close();
        }

        public void totalLq()
        {
            string query = "SELECT COUNT(pname) as pn FROM tblStock where stock<3";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblLq.Text = dr["pn"].ToString();
            }
            dr.Close();
        }
    }
}