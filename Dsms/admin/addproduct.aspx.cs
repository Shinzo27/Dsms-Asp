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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0VBFBDN\\SQLEXPRESS;Initial Catalog=dbDsms;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["adminloggedin"] == null)
            {
                Response.Redirect("../index.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/images/" + FileUpload1.FileName.ToString());
            path = "images/" + FileUpload1.FileName.ToString();
            string query = "insert into tblProduct(pname,price,category,image,date) values ('" + txtPname.Text + "','" + txtPrice.Text + "','" + ddCategory.SelectedValue.ToString() + "','" + path.ToString() + "', GETDATE())";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Product Added Successfully!', 'success').then(function() {window.location.href = 'index.aspx'}); ", true);
            con.Close();
        }
    }
}