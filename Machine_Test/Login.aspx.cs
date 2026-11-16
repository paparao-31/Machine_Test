
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Machine_Test
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Visible = false;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string query = @"SELECT COUNT(*) FROM Users
                             WHERE UserName=@u AND [Password]=@p";

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@u", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    con.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        Session["UserId"] = txtUserName.Text.Trim();
                        Response.Redirect("TestMenu.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Sorry, User Credentials are wrong";
                        lblMsg.Visible = true;
                    }
                }
            }
        }
    }
}
