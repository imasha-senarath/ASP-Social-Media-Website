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
    public partial class SignUp : System.Web.UI.Page
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
                        loginUserEmail.Text = sqlDataReader["user_email"].ToString();
                       
                        loginUserPassword.Attributes["value"] = sqlDataReader["user_password"].ToString();

                        //Response.Write("<script>alert('" + pass + "')</script>");
                    }
                }
            }
        }


        protected void userEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            if (signUpUserName.Text != "" && signUpUserPassword.Text != "" && signUpUserEmail.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd1 = new SqlCommand("select * from Users where user_email='" + signUpUserEmail.Text + "'", con);
                    con.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd1);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count != 0)
                    {
                        signUpErrorMsg.Text = "Email already registered.";
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("insert into Users values('" + signUpUserName.Text + "', '" + signUpUserPassword.Text + "', '" + signUpUserEmail.Text + "')", con);
                        cmd2.ExecuteNonQuery();

                        Session["UserEmail"] = signUpUserEmail.Text;
                        Response.Cookies["UserEmail"].Value = signUpUserEmail.Text;
                        Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(7);

                        Response.Redirect("~/home.aspx");
                    }
                }
            }
            else
            {
                signUpErrorMsg.Text = "Fields Cannot be empty";
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where user_email='"+loginUserEmail.Text+ "' and user_password = '"+loginUserPassword.Text+"'", con);
                con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count!=0)
                {
                    Session["UserEmail"] = loginUserEmail.Text;
                    Response.Cookies["UserEmail"].Value = loginUserEmail.Text;
                    Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(7);
                    Response.Redirect("~/home.aspx");
                }
                else
                {
                    loginErrorMsg.Text = "Invalid email or password.";
                }

            }
        }
    }
}