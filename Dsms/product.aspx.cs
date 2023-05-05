﻿using System;
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
                DropDownList ddPtype = (DropDownList)(e.Item.FindControl("ddPtype"));

                if (txt.Text.Equals("") || txt.Text == "0")
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
                            int q = Convert.ToInt32(txt.Text);
                            string ptype = ddPtype.SelectedItem.Text.ToString();
                            double kg = 0;
                            if(ptype == "250gm")
                            {
                                kg = q * 0.25;
                            }
                            else if(ptype == "500gm")
                            {
                                kg = q * 0.5;
                            }
                            else if(ptype == "1kg")
                            {
                                kg = q * 1;
                            }

                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            if (cq > kg)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float kgp = Convert.ToInt32(dr.GetValue(4));
                                float price = 0;
                                if(ptype == "250gm")
                                {
                                    price = kgp / 4;
                                }
                                else if(ptype == "500gm")
                                {
                                    price = kgp / 2;
                                }
                                else if(ptype == "1kg")
                                {
                                    price = kgp / 1;
                                }
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "' and ptype='"+ptype+"'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date,ptype) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE(), '"+ptype+"')";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    int current = reader.GetInt32(4);
                                    int newq = current + q;
                                    double curtotal = Convert.ToDouble(reader.GetValue(5).ToString());
                                    double newtot = curtotal + total;
                                    reader.Close();
                                    string update = "update tblCart set quantity='"+newq+"', total='"+newtot+"' where pname='"+pname+"' and uid='"+uid+"' and ptype='"+ptype+"'";
                                    SqlCommand upd = new SqlCommand(update, con);
                                    int i = upd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Updated!', 'Quantity updated because product is already added to the cart!', 'success');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
                con.Close();
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
                TextBox txt = (TextBox)(e.Item.FindControl("txtQuantity2"));
                DropDownList ddPtype = (DropDownList)(e.Item.FindControl("ddPtype2"));

                if (txt.Text.Equals("") || txt.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Enter Quantity!', 'Please mention quantity', 'error');", true);
                }
                else
                {
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
                            int q = Convert.ToInt32(txt.Text);
                            string ptype = ddPtype.SelectedItem.Text.ToString();
                            double kg = 0;
                            if (ptype == "250gm")
                            {
                                kg = q * 0.25;
                            }
                            else if (ptype == "500gm")
                            {
                                kg = q * 0.5;
                            }
                            else if (ptype == "1kg")
                            {
                                kg = q * 1;
                            }

                            float cq = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                            if (cq > kg)
                            {
                                string pname = dr.GetValue(1).ToString();
                                float kgp = Convert.ToInt32(dr.GetValue(4));
                                float price = 0;
                                if (ptype == "250gm")
                                {
                                    price = kgp / 4;
                                }
                                else if (ptype == "500gm")
                                {
                                    price = kgp / 2;
                                }
                                else if (ptype == "1kg")
                                {
                                    price = kgp / 1;
                                }
                                float total = q * price;

                                string select = "select * from tblCart where pname='" + dr.GetValue(1).ToString() + "' and uid='" + uid + "' and ptype='" + ptype + "'";
                                SqlCommand sel = new SqlCommand(select, con);
                                dr.Close();
                                SqlDataReader reader = sel.ExecuteReader();
                                if (reader.Read() != true)
                                {
                                    reader.Close();
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date,ptype) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE(), '" + ptype + "')";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    int current = reader.GetInt32(4);
                                    int newq = current + q;
                                    double curtotal = Convert.ToDouble(reader.GetValue(5).ToString());
                                    double newtot = curtotal + total;
                                    reader.Close();
                                    string update = "update tblCart set quantity='" + newq + "', total='" + newtot + "' where pname='" + pname + "' and uid='" + uid + "' and ptype='" + ptype + "'";
                                    SqlCommand upd = new SqlCommand(update, con);
                                    int i = upd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Updated!', 'Quantity updated because product is already added to the cart!', 'success');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
                con.Close();
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
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date,ptype) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE(), 'pkt')";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    int current = reader.GetInt32(4);
                                    int newq = current + q;
                                    double curtotal = Convert.ToDouble(reader.GetValue(5).ToString());
                                    double newtot = curtotal + total;
                                    reader.Close();
                                    string update = "update tblCart set quantity='" + newq + "', total='" + newtot + "' where pname='" + pname + "' and uid='" + uid + "' and ptype='pkt'";
                                    SqlCommand upd = new SqlCommand(update, con);
                                    int i = upd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Updated!', 'Quantity updated because product is already added to the cart!', 'success');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
                con.Close();
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
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date,ptype) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE(),'pkt')";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    int current = reader.GetInt32(4);
                                    int newq = current + q;
                                    double curtotal = Convert.ToDouble(reader.GetValue(5).ToString());
                                    double newtot = curtotal + total;
                                    reader.Close();
                                    string update = "update tblCart set quantity='" + newq + "', total='" + newtot + "' where pname='" + pname + "' and uid='" + uid + "' and ptype='pkt'";
                                    SqlCommand upd = new SqlCommand(update, con);
                                    int i = upd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Updated!', 'Quantity updated because product is already added to the cart!', 'success');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
                con.Close();
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
                                    string insert = "insert into tblCart(uid,pname,price,quantity,total,date,ptype) values (" + uid + ",'" + pname + "','" + price + "','" + q + "','" + total + "',GETDATE(), 'pkt')";
                                    SqlCommand ins = new SqlCommand(insert, con);
                                    int i = ins.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Success!', 'Added to the cart!', 'success');", true);
                                    }
                                }
                                else
                                {
                                    int current = reader.GetInt32(4);
                                    int newq = current + q;
                                    double curtotal = Convert.ToDouble(reader.GetValue(5).ToString());
                                    double newtot = curtotal + total;
                                    reader.Close();
                                    string update = "update tblCart set quantity='" + newq + "', total='" + newtot + "' where pname='" + pname + "' and uid='" + uid + "' and ptype='bottle'";
                                    SqlCommand upd = new SqlCommand(update, con);
                                    int i = upd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Updated!', 'Quantity updated because product is already added to the cart!', 'success');", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "k", "swal('Not Enough Quantity!', 'Current Quantity is : " + cq + "', 'error');", true);
                            }
                        }
                    }
                }
                con.Close();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            dbcon.Open();
            Label lbl = (Label)e.Item.FindControl("pid");
            Label lblOS = (Label)e.Item.FindControl("lblOS");
            Button btn = (Button)e.Item.FindControl("btnAddtocart");
            string query = "select * from tblProduct where pid='" + lbl.Text + "'";
            SqlCommand com = new SqlCommand(query, dbcon);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                SqlCommand check = new SqlCommand(checkqty, dbcon);
                SqlDataReader checkdr = check.ExecuteReader();
                if (checkdr.Read() == true)
                {
                    float stock = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                    if(stock == 0)
                    {
                        btn.Visible = false;
                        lblOS.Visible = true;
                    }
                }
            }
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            SqlConnection dbcon2 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            dbcon2.Open();
            Label lbl = (Label)e.Item.FindControl("pid");
            Label lblOS = (Label)e.Item.FindControl("lblOS2");
            Button btn = (Button)e.Item.FindControl("btnAddtocart");
            string query = "select * from tblProduct where pid='" + lbl.Text + "'";
            SqlCommand com = new SqlCommand(query, dbcon2);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                SqlCommand check = new SqlCommand(checkqty, dbcon2);
                SqlDataReader checkdr = check.ExecuteReader();
                if (checkdr.Read() == true)
                {
                    float stock = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                    if (stock == 0)
                    {
                        btn.Visible = false;
                        lblOS.Visible = true;
                    }
                }
            }
        }

        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            SqlConnection dbcon3 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            dbcon3.Open();
            Label lbl = (Label)e.Item.FindControl("pid");
            Label lblOS = (Label)e.Item.FindControl("lblOS3");
            Button btn = (Button)e.Item.FindControl("btnAddtocart");
            string query = "select * from tblProduct where pid='" + lbl.Text + "'";
            SqlCommand com = new SqlCommand(query, dbcon3);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                SqlCommand check = new SqlCommand(checkqty, dbcon3);
                SqlDataReader checkdr = check.ExecuteReader();
                if (checkdr.Read() == true)
                {
                    float stock = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                    if (stock == 0)
                    {
                        btn.Visible = false;
                        lblOS.Visible = true;
                    }
                }
            }
        }

        protected void DataList4_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            SqlConnection dbcon4 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            dbcon4.Open();
            Label lbl = (Label)e.Item.FindControl("pid");
            Label lblOS = (Label)e.Item.FindControl("lblOS4");
            Button btn = (Button)e.Item.FindControl("btnAddtocart");
            string query = "select * from tblProduct where pid='" + lbl.Text + "'";
            SqlCommand com = new SqlCommand(query, dbcon4);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                SqlCommand check = new SqlCommand(checkqty, dbcon4);
                SqlDataReader checkdr = check.ExecuteReader();
                if (checkdr.Read() == true)
                {
                    float stock = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                    if (stock == 0)
                    {
                        btn.Visible = false;
                        lblOS.Visible = true;
                    }
                }
            }
        }

        protected void DataList5_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            SqlConnection dbcon5 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            dbcon5.Open();
            Label lbl = (Label)e.Item.FindControl("pid");
            Label lblOS = (Label)e.Item.FindControl("lblOS5");
            Button btn = (Button)e.Item.FindControl("btnAddtocart");
            string query = "select * from tblProduct where pid='" + lbl.Text + "'";
            SqlCommand com = new SqlCommand(query, dbcon5);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                string checkqty = "select * from tblStock where pname='" + dr.GetString(1).ToString() + "'";
                SqlCommand check = new SqlCommand(checkqty, dbcon5);
                SqlDataReader checkdr = check.ExecuteReader();
                if (checkdr.Read() == true)
                {
                    float stock = (float)Convert.ToDouble(checkdr.GetValue(2).ToString());
                    if (stock == 0)
                    {
                        btn.Visible = false;
                        lblOS.Visible = true;
                    }
                }
            }
        }
    }
}