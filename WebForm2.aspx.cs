using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Basic_Bank
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ITR;Integrated Security=True";
        string sid = "";
        string rid = "";
        string sname = "";
        string rname = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd1=new SqlCommand("SELECT NAME,ID FROM CUSTOMERS WHERE ID=@id", con))
                {                  
                    cmd1.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sid = reader["id"].ToString();
                            sname = reader["name"].ToString();
                        }
                    }
                }
                using (SqlCommand cmd2 = new SqlCommand("SELECT NAME,ID FROM CUSTOMERS WHERE NAME=@name", con))
                {
                    cmd2.Parameters.AddWithValue("@name", DropDownList1.SelectedValue);
                    using (SqlDataReader reader1 = cmd2.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            rid = reader1["id"].ToString();
                            rname = reader1["name"].ToString();
                        }
                    }
                }

            }
            //string sender1 = Server.UrlEncode(Request.QueryString["name"]);
            Response.Redirect("WebForm3.aspx?"+"sid=" + sid + "&rid="+ rid + "&sname="+ sname + "&rname=" + rname);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx?");
        }
    }
}