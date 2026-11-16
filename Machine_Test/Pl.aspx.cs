
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Machine_Test
{
    public partial class Pl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Hi " + Session["UserId"].ToString();

                BindGrid();
            }
        }

        void BindGrid()
        {
            string query = "SELECT * FROM MT_Product";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender,
            GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime mfg = Convert.ToDateTime(
                    DataBinder.Eval(e.Row.DataItem, "ManufactureDate"));

                DateTime exp = Convert.ToDateTime(
                    DataBinder.Eval(e.Row.DataItem, "ExpiryDate"));

                int days = (exp - mfg).Days;

                Label lbl = (Label)e.Row.FindControl("lblDays");

                if (lbl != null)
                {
                    if (days < 0)
                        lbl.Text = "IsExpired";
                    else
                        lbl.Text = days.ToString();
                }
            }
        }

        protected void GridView1_RowCommand(object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                if (index >= 0 && index < GridView1.DataKeys.Count)
                {
                    string id = GridView1.DataKeys[index].Value.ToString();

                    Response.Redirect("Ipd.aspx?Id=" + id);
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}
