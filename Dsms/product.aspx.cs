using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dsms
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(Session["loggedin"] != null) 
            {
                con.Open();
                int uid = (int)Session["uid"];
                TextBox txt = (TextBox)(e.Item.FindControl("txtQuantity1"));
                if (txt.Text.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else{
                    Label lbl = (Label)(e.Item.FindControl("pid"));
                    string query = "select * from tblProduct where pid='" + lbl.Text + "'";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                        SqlCommand check = new SqlCommand(checkqty, con);
                        SqlDataReader checkdr = check.ExecuteReader();
                        if (checkdr.Read() == true)
                        {
                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            int q = Convert.ToInt32(txt.Text);
                            if (cq > q)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float price = Convert.ToInt32(dr.GetValue(4));
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE())";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Already Added!', 'Item is already in the cart!', 'error');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                con.Open();
                int uid = (int)Session["uid"];
                TextBox txt = (TextBox)e.Item.FindControl("txtQuantity2");
                if (txt.Text.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else
                {
                    Label lbl = (Label)e.Item.FindControl("pid");
                    string query = "select * from tblProduct where pid='" + lbl.Text + "'";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                        SqlCommand check = new SqlCommand(checkqty, con);
                        SqlDataReader checkdr = check.ExecuteReader();
                        if (checkdr.Read() == true)
                        {
                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            int q = Convert.ToInt32(txt.Text);
                            if (cq > q)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float price = Convert.ToInt32(dr.GetValue(4));
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE())";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Already Added!', 'Item is already in the cart!', 'error');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                con.Open();
                int uid = (int)Session["uid"];
                TextBox txt = (TextBox)e.Item.FindControl("txtQuantity3");
                if (txt.Text.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else
                {
                    Label lbl = (Label)e.Item.FindControl("pid");
                    string query = "select * from tblProduct where pid='" + lbl.Text + "'";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                        SqlCommand check = new SqlCommand(checkqty, con);
                        SqlDataReader checkdr = check.ExecuteReader();
                        if (checkdr.Read() == true)
                        {
                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            int q = Convert.ToInt32(txt.Text);
                            if (cq > q)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float price = Convert.ToInt32(dr.GetValue(4));
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE())";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Already Added!', 'Item is already in the cart!', 'error');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void DataList4_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                con.Open();
                int uid = (int)Session["uid"];
                TextBox txt = (TextBox)e.Item.FindControl("txtQuantity4");
                if (txt.Text.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else
                {
                    Label lbl = (Label)e.Item.FindControl("pid");
                    string query = "select * from tblProduct where pid='" + lbl.Text + "'";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                        SqlCommand check = new SqlCommand(checkqty, con);
                        SqlDataReader checkdr = check.ExecuteReader();
                        if (checkdr.Read() == true)
                        {
                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            int q = Convert.ToInt32(txt.Text);
                            if (cq > q)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float price = Convert.ToInt32(dr.GetValue(4));
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE())";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Already Added!', 'Item is already in the cart!', 'error');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void DataList5_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["loggedin"] != null)
            {
                con.Open();
                int uid = (int)Session["uid"];
                TextBox txt = (TextBox)e.Item.FindControl("txtQuantity5");
                if (txt.Text.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else
                {
                    Label lbl = (Label)e.Item.FindControl("pid");
                    string query = "select * from tblProduct where pid='" + lbl.Text + "'";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                        SqlCommand check = new SqlCommand(checkqty, con);
                        SqlDataReader checkdr = check.ExecuteReader();
                        if (checkdr.Read() == true)
                        {
                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            int q = Convert.ToInt32(txt.Text);
                            if (cq > q)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float price = Convert.ToInt32(dr.GetValue(4));
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE())";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Already Added!', 'Item is already in the cart!', 'error');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}