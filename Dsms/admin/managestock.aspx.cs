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
    public partial class managestock : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        int crst = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if (Session["adminloggedin"] != null)
            {
                con.Open();
                string pname = Request.QueryString["pname"];
                string query = "select * from tblStock where pname='" + pname + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtPname.Text = dr.GetValue(1).ToString();
                    Label1.Text = "Current Stock : " + dr.GetValue(2).ToString();
                    crst = Convert.ToInt32(dr.GetValue(2).ToString());
                }
                dr.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int newst = crst + Convert.ToInt32(txtStock.Text);
            string query = "update tblStock set stock='" + newst + "' where pname = '" + txtPname.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            if(i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Stock Updated Successfully!', 'success').then(function() {window.location.href = 'index.aspx'}); ", true);
            }
        }
    }
}