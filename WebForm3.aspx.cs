using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Basic_Bank
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ITR;Integrated Security=True";
        int amount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            try
            {
                amount = Int32.Parse(TextBox1.Text);
            }
            catch(Exception ex)
            {
                //Label2.Text = "Invalid amount entered";
            }
            int bal = 0;
            int rbal = 0;
            bool flag = false;
            int temp = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using(SqlCommand cmd1=new SqlCommand("SELECT BALANCE FROM CUSTOMERS WHERE ID=@sid", con))
                {
                    cmd1.Parameters.AddWithValue("@sid", Request.QueryString["sid"]);
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bal = Int32.Parse(reader["balance"].ToString());
                            if (amount < 0)
                            {
                                Label2.ForeColor = System.Drawing.Color.Red;
                                Label2.Text = "Amount cannot be Negative!";                               
                            }
                            else if (amount == 0)
                            {
                                Label2.ForeColor = System.Drawing.Color.Red;
                                Label2.Text = "Invalid Amount!";
                            }
                            else if (amount < bal)
                            {
                                Label2.ForeColor = System.Drawing.Color.LimeGreen;
                                Label2.Text = "Transaction Successfull! Thank you";
                                Button2.Visible = true;
                                Button1.Enabled = false;
                                flag = true;
                            }
                            else if(amount > bal)
                            {
                                Label2.ForeColor = System.Drawing.Color.Red;
                                Label2.Text = "Insufficient Balance to carry the transaction, please check the amount entered!";
                            }
                        }
                    }   
                }
                if (flag)
                {
                    Button1.Visible = false;
                    TextBox1.Enabled = false;
                    using (SqlCommand cmd2 = new SqlCommand("SELECT BALANCE FROM CUSTOMERS WHERE ID=@rid", con))
                    {
                        cmd2.Parameters.AddWithValue("@rid", Request.QueryString["rid"]);
                        using (SqlDataReader reader1 = cmd2.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                rbal= Int32.Parse(reader1["balance"].ToString());
                            }
                        }
                    }
                    using (SqlCommand upd1 = new SqlCommand("UPDATE CUSTOMERS SET BALANCE=@bal WHERE ID=@sid", con))
                    {
                        bal = bal - amount;
                        upd1.Parameters.AddWithValue("@bal", bal);
                        upd1.Parameters.AddWithValue("@sid", Request.QueryString["sid"]);
                        upd1.ExecuteNonQuery();
                    }
                    using (SqlCommand upd2 = new SqlCommand("UPDATE CUSTOMERS SET BALANCE=@rbal WHERE ID=@rid", con))
                    {
                        rbal = rbal + amount;
                        upd2.Parameters.AddWithValue("@rbal", rbal);
                        upd2.Parameters.AddWithValue("@rid", Request.QueryString["rid"]);
                        upd2.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TRANSFERS VALUES(@id,@sid,@sname,@rid,@rname,@money,@date)", con))
                    {
                        Random rand = new Random();
                        temp = rand.Next(1000, 100000);
                        Session["tid"] = temp;
                        cmd1.Parameters.AddWithValue("@id", temp);
                        cmd1.Parameters.AddWithValue("@sid", Request.QueryString["sid"]);
                        cmd1.Parameters.AddWithValue("@sname", Request.QueryString["sname"]);
                        cmd1.Parameters.AddWithValue("@rid", Request.QueryString["rid"]);
                        cmd1.Parameters.AddWithValue("@rname", Request.QueryString["rname"]);
                        cmd1.Parameters.AddWithValue("@money", amount);
                        DateTime dt3 = DateTime.Now;
                        cmd1.Parameters.AddWithValue("@date", dt3);
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Label3.Text = "Transaction Details : ";
            GridView1.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //TextBox1.Enabled = false;
            //RequiredFieldValidator1.EnableClientScript = false;
            Response.Redirect("WebForm1.aspx?");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //RequiredFieldValidator1.EnableClientScript = false;
            Response.Redirect("WebForm2.aspx?" + "id=" + Request.QueryString["sid"]);
        }
    }
}