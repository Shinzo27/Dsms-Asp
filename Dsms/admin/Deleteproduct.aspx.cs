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
            con.Open();
            string id = Request.QueryString["pid"];
            string delete = "delete from tblProduct where pid='" + id + "'";
            SqlCommand com = new SqlCommand(delete, con);
            com.ExecuteNonQuery();
            Response.Redirect("index.aspx");
        }
    }
}