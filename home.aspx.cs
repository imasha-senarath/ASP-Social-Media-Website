using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Social_Media_Web_Site
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UserEmail"] != null)
            {
                String UserEmail = Request.Cookies["UserEmail"].Value;

                String CS = ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd1 = new SqlCommand("select * from Users where user_email='" + UserEmail + "'", con);
                    con.Open();
                    SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
      
                        userName.Text = sqlDataReader["user_name"].ToString();
                       
                    }        
                }
            }
            else
            {
                Response.Redirect("~/welcome.aspx");
            }
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            Session["UserEmail"] = null;
            Response.Redirect("~/welcome.aspx");
        }
    }
}