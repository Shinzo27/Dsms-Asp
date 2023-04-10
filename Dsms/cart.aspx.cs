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
            if (!IsPostBack)
            {
                BindingGridViewData();
                calculateSum();
            }
            
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
        protected void BindingGridViewData()
        {
            int uid = Convert.ToInt32(Session["uid"].ToString());
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select cid,pname,price,quantity,total from tblCart where uid='"+uid+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int uid = Convert.ToInt32(Session["uid"].ToString());
            con.Open();

            string query = "select * from tblCart where cid='"+id+"' and uid = '" + uid + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            TextBox price = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPrice");
            TextBox quantity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtQuantity");
            TextBox pname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPname");
            float p = (float)Convert.ToDouble(price.Text.ToString());
            int q = Convert.ToInt32(quantity.Text.ToString());
            float total = p * q;
            if (dr.Read() == true)
            {
                dr.Close();
                SqlCommand cmd = new SqlCommand("update tblCart set price='"+p+"', quantity='"+q+"', total='"+total+"' where uid='"+uid+"' and cid='"+id+"' ", con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'User Information updated successfully!', 'success');", true);
                }
            }
            con.Close();

            GridView1.EditIndex = -1;
            BindingGridViewData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindingGridViewData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int uid = Convert.ToInt32(Session["uid"].ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from tblCart where uid = '" + uid + "' and cid='"+id+"'", con);
            int i = cmd.ExecuteNonQuery();

            con.Close();
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Order Removed successfully!', 'success');", true);
            }
            GridView1.EditIndex = -1;
            BindingGridViewData();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindingGridViewData();
        }
    }
}