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
    public partial class vieworder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            string id = Request.QueryString["id"];
            string query = "select * from view_all_data where onum='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblName.Text = dr.GetValue(1).ToString();
                lblContact.Text = dr.GetValue(4).ToString();
                lblTotal.Text = dr.GetValue(5).ToString();
                lblAdd.Text = dr.GetValue(3).ToString();
            }
        }
    }
}