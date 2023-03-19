using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Dsms
{
    public partial class WebForm8 : System.Web.UI.Page
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
            if (Session["loggedin"] == null)
            {

                Response.Redirect("login.aspx");
            }
            calculateSum();
        }

        public void calculateSum()
        {
            if (GridView1.Rows.Count > 0)
            {
                int uid = (int)Session["uid"];
                DataTable dt = new DataTable();
                string query = "select * from tblCart where uid='" + uid + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = com;
                DataSet ds = new DataSet();
                sda.Fill(dt);
                GridView1.FooterRow.Cells[3].Text = "Grand Total : ";
                GridView1.FooterRow.Cells[4].Text = dt.Compute("Sum(total)", "").ToString();
            }
        }
    }
}