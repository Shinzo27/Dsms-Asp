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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        string path;
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
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                if(dr.Read() == true)
                {
                    lblPname.Text = "Current Name : " + dr.GetValue(1).ToString();
                    lblPrice.Text = "Current Price : " + dr.GetValue(4).ToString();
                    ddCategory.SelectedValue = dr.GetValue(2).ToString();
                }
                dr.Close();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["pid"];
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/Images/" + FileUpload1.FileName.ToString());
            path = "Images/" + FileUpload1.FileName.ToString();
            string query = "update tblProduct set pname='"+txtPname.Text+"',category='"+ddCategory.SelectedValue.ToString()+"',image='"+path.ToString()+"',price='"+txtPrice.Text+"' where pid='"+id+"'";
            SqlCommand com = new SqlCommand(query, con);
            int i = com.ExecuteNonQuery();
            if(i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Product Updated Successfully!', 'success').then(function() {window.location.href = 'index.aspx'}); ", true);
            }
           
            con.Close();
        }
    }
}