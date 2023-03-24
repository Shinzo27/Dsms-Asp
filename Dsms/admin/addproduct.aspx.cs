using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Dsms.admin
{
    public partial class addproduct : System.Web.UI.Page
    {
        string path;
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            string checkprod = "select * from tblProduct where pname='" + txtPname.Text + "'";
            SqlCommand checkcom = new SqlCommand(checkprod, con);
            SqlDataReader reader = checkcom.ExecuteReader();
            if (reader.Read())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Error!', 'Product Already Added!', 'error');", true);
            }
            else {
                reader.Close();
                   FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/Images/" + FileUpload1.FileName.ToString());
                   path = "Images/" + FileUpload1.FileName.ToString();
                   string query = "insert into tblProduct(pname,price,category,image,date) values ('" + txtPname.Text + "','" + txtPrice.Text + "','" + ddCategory.SelectedValue.ToString() + "','" + path.ToString() + "', GETDATE())";
                   SqlCommand com = new SqlCommand(query, con);
                   com.ExecuteNonQuery();
                   string stock = "insert into tblStock(pname,stock) values ('" + txtPname.Text + "','" + txtStock.Text + "')";
                   SqlCommand stkquery = new SqlCommand(stock, con);
                   stkquery.ExecuteNonQuery();
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Product Added Successfully!', 'success').then(function() {window.location.href = 'index.aspx'}); ", true);
                   con.Close();
            }
        }
    }
}