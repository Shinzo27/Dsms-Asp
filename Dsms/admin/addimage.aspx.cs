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
    public partial class addimage : System.Web.UI.Page
    {
        string path;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-B85NU0HM\\SQLEXPRESS;Initial Catalog=dbDsms;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/images/" + FileUpload1.FileName.ToString());
            path = "images/" + FileUpload1.FileName.ToString();
            string query = "insert into tblImages(path) values ('"+path.ToString()+"')";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Image Added Successfully!', 'success').then(function() {window.location.href = 'image.aspx'}); ", true);
            con.Close();
        }
    }
}