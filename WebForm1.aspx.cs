using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Basic_Bank
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ITR;Integrated Security=True";
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Button2.Visible = true;
            Button1.Visible = false;
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                using(SqlCommand cmd=new SqlCommand("SELECT NAME FROM CUSTOMERS", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DropDownList1.Items.Add(reader["name"].ToString());
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using(SqlConnection con1=new SqlConnection(connectionString))
            {
                using(SqlCommand cmd1=new SqlCommand("SELECT ID FROM CUSTOMERS WHERE NAME=@name", con1))
                {
                    con1.Open();
                    //string id="";
                    cmd1.Parameters.AddWithValue("@name", DropDownList1.SelectedValue);
                    using(SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Server.UrlEncode(reader["id"].ToString());
                        }
                    }
                }
            }
            //string name = Server.UrlEncode(DropDownList1.SelectedValue);
            Response.Redirect("WebForm2.aspx?id="+id);
        }
    }
}