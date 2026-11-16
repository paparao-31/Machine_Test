
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Machine_Test
{
    public partial class Ipd : System.Web.UI.Page
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

                sbProductType.Items.Add(new ListItem("--Select--", ""));
                sbProductType.Items.Add(new ListItem("SKU", "1"));
                sbProductType.Items.Add(new ListItem("Bin", "2"));
                sbProductType.Items.Add(new ListItem("Kit", "3"));

                sbUom.Items.Add(new ListItem("--Select--", ""));
                sbUom.Items.Add(new ListItem("Meter", "1"));
                sbUom.Items.Add(new ListItem("Foot", "2"));
                sbUom.Items.Add(new ListItem("Inch", "3"));
                sbUom.Items.Add(new ListItem("Centimeter", "4"));
                sbUom.Items.Add(new ListItem("Pound", "5"));
                sbUom.Items.Add(new ListItem("Kilogram", "6"));

                rblReturnable.SelectedValue = "false";

                if (Request.QueryString["Id"] != null)
                {
                    int id;

                    if (int.TryParse(Request.QueryString["Id"], out id))
                    {
                        GetData(id);
                        btnInsert.Text = "Update";
                    }
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            decimal weight;
            DateTime mdate, edate;

            if (txtCName.Text.Trim() == "" ||
                txtPName.Text.Trim() == "" ||
                sbProductType.SelectedValue == "" ||
                sbUom.SelectedValue == "" ||
                txtWeight.Text.Trim() == "" ||
                txtMDate.Text.Trim() == "" ||
                txtEDate.Text.Trim() == "")
            {
                ShowMessage("Please fill all fields", false);
                return;
            }

            if (!decimal.TryParse(txtWeight.Text, out weight) || weight < 0)
            {
                ShowMessage("Invalid weight", false);
                return;
            }

            if (!DateTime.TryParseExact(txtMDate.Text, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out mdate))
            {
                ShowMessage("Invalid Manufacture Date. Use yyyy-MM-dd", false);
                return;
            }

            if (!DateTime.TryParseExact(txtEDate.Text, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out edate))
            {
                ShowMessage("Invalid Expiry Date. Use yyyy-MM-dd", false);
                return;
            }

            if (rblReturnable.SelectedValue == "")
            {
                ShowMessage("Please select Returnable option", false);
                return;
            }

            bool isUpdate = Request.QueryString["Id"] != null;

            string query;

            if (isUpdate)
            {
                query = @"UPDATE MT_Product SET
                CustomerName=@c,
                ProductName=@p,
                ProductType=@pt,
                Uom=@u,
                Weight=@w,
                ManufactureDate=@md,
                ExpiryDate=@ed,
                Returnable=@r,
                Status=@s
                WHERE Id=@id";
            }
            else
            {
                query = @"INSERT INTO MT_Product
                (CustomerName,ProductName,ProductType,Uom,Weight,
                ManufactureDate,ExpiryDate,Returnable,Status)
                VALUES
                (@c,@p,@pt,@u,@w,@md,@ed,@r,@s)";
            }

            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@c", txtCName.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", txtPName.Text.Trim());
                        cmd.Parameters.AddWithValue("@pt", Convert.ToInt32(sbProductType.SelectedValue));
                        cmd.Parameters.AddWithValue("@u", Convert.ToInt32(sbUom.SelectedValue));
                        cmd.Parameters.AddWithValue("@w", weight);
                        cmd.Parameters.AddWithValue("@md", mdate);
                        cmd.Parameters.AddWithValue("@ed", edate);
                        cmd.Parameters.AddWithValue("@r", Convert.ToBoolean(rblReturnable.SelectedValue));
                        cmd.Parameters.AddWithValue("@s", chkStatus.Checked);

                        if (isUpdate)
                        {
                            int id = Convert.ToInt32(Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue("@id", id);
                        }

                        con.Open();

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            if (isUpdate)
                            {
                                ShowMessage("Product details updated successfully", true);
                            }
                            else
                            {
                                ShowMessage("Person details inserted successfully", true);
                                ClearFields();
                            }
                        }
                        else
                        {
                            ShowMessage("Sorry, Internal error", false);
                        }
                    }
                }
            }
            catch (Exception)
            {
                ShowMessage("Sorry, Internal error", false);
            }
        }

        void GetData(int id)
        {
            string query = "SELECT * FROM MT_Product WHERE Id=@id";

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtCName.Text = dr["CustomerName"].ToString();
                            txtPName.Text = dr["ProductName"].ToString();
                            txtWeight.Text = dr["Weight"].ToString();

                            txtMDate.Text = Convert.ToDateTime(
                                dr["ManufactureDate"]).ToString("yyyy-MM-dd");

                            txtEDate.Text = Convert.ToDateTime(
                                dr["ExpiryDate"]).ToString("yyyy-MM-dd");

                            sbProductType.SelectedValue = dr["ProductType"].ToString();
                            sbUom.SelectedValue = dr["Uom"].ToString();

                            rblReturnable.SelectedValue =
                                Convert.ToBoolean(dr["Returnable"]) ? "true" : "false";

                            chkStatus.Checked = Convert.ToBoolean(dr["Status"]);
                        }
                        else
                        {
                            ShowMessage("Product record not found", false);
                        }
                    }
                }
            }
        }

        void ClearFields()
        {
            txtCName.Text = "";
            txtPName.Text = "";
            txtWeight.Text = "";
            txtMDate.Text = "";
            txtEDate.Text = "";

            sbProductType.SelectedIndex = 0;
            sbUom.SelectedIndex = 0;

            rblReturnable.SelectedValue = "false";
            chkStatus.Checked = true;
        }

        void ShowMessage(string message, bool success)
        {
            lblMsg.Text = message;
            lblMsg.Visible = true;

            if (success)
                lblMsg.ForeColor = System.Drawing.Color.Green;
            else
                lblMsg.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}
