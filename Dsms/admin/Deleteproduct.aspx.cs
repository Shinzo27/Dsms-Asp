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
    public partial class Deleteproduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        
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
                string id = Request.QueryString["pid"];
                string query = "select * from tblProduct where pid='" + id + "'";
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string stock = "delete from tblStock where pname='" + dr.GetString(1) + "'";
                    SqlCommand st = new SqlCommand(stock, con);
                    st.ExecuteNonQuery();
                    string delete = "delete from tblProduct where pid='" + id + "'";
                    SqlCommand com = new SqlCommand(delete, con);
                    com.ExecuteNonQuery();
                    Response.Redirect("product.aspx");
                }
                
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }
}