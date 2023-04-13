using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Dsms
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        int id;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["uid"].ToString());
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if (Session["email"] != null)
            {
                con.Open();
                string expecteddate = DateTime.Now.AddDays(2).ToString();
                string oid = "select max(onum) as ID from tblOrderDetails ";
                SqlCommand cm = new SqlCommand(oid, con);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    id = Convert.ToInt32(dr["Id"].ToString()) + 1;
                }
                string uname = Session["username"].ToString();
                string email = Session["email"].ToString();
                string address = Session["address"].ToString();
                string contact = Session["contact"].ToString();
                float total = (float)Convert.ToDouble(Session["total"].ToString());
                double c = (double)Convert.ToDouble(contact);
                string date = DateTime.Now.ToString();
                string query = "insert into tblOrderDetails(uname,email,address,contact,date,total) values ('" + uname + "','" + email + "','" + address + "','" + c + "','" + date + "','"+total+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {   
                    foreach (GridViewRow gr in gvProduct.Rows)
                    {
                        string query1 = "insert into tblOrderProduct(oid,pname,price,quantity,total,date,ptype) values ('" + id + "','" + gr.Cells[0].Text + "','" + gr.Cells[1].Text + "','" + gr.Cells[2].Text + "','" + gr.Cells[3].Text + "','" + gr.Cells[5].Text + "','" + gr.Cells[4].Text + "')";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.ExecuteNonQuery();
                    }
                    string query2 = "delete from tblCart where uid='" + uid + "'";
                    SqlCommand cmd2 = new SqlCommand(query2,con);
                    cmd2.ExecuteNonQuery();                    
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            Label1.Text = DateTime.Now.AddDays(2).ToShortDateString();
        }
    }
}