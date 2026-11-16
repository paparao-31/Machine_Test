
using System;

namespace Machine_Test
{
    // Method Overloading
    public class Shape
    {
        // Rectangle Volume
        public double CalculateVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        // Cylinder Volume
        public double CalculateVolume(double diameter, double height)
        {
            double radius = diameter / 2;

            return Math.PI * radius * radius * height;
        }
    }

    // Object Method Calling
    public class VolumeResult
    {
        public string DisplayVolume(Shape shape,
            double length, double width, double height)
        {
            double result = shape.CalculateVolume(length, width, height);

            return result.ToString("0.00");
        }
    }

    public partial class Own : System.Web.UI.Page
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

                pnlRectangle.Visible = false;
                pnlCylinder.Visible = false;
            }
        }

        protected void ddlShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShape.SelectedValue == "1")
            {
                pnlRectangle.Visible = true;
                pnlCylinder.Visible = false;

                txtDiameter.Text = "";
                txtCHeight.Text = "";
                txtCVolume.Text = "";
            }
            else if (ddlShape.SelectedValue == "2")
            {
                pnlRectangle.Visible = false;
                pnlCylinder.Visible = true;

                txtLength.Text = "";
                txtWidth.Text = "";
                txtHeight.Text = "";
                txtRectVolume.Text = "";
            }
            else
            {
                pnlRectangle.Visible = false;
                pnlCylinder.Visible = false;
            }

            lblMessage.Text = "";
        }

        protected void btnRectangleVolume_Click(object sender, EventArgs e)
        {
            double l, w, h;

            if (!double.TryParse(txtLength.Text, out l) ||
                !double.TryParse(txtWidth.Text, out w) ||
                !double.TryParse(txtHeight.Text, out h))
            {
                lblMessage.Text = "Please enter valid numeric values";
                return;
            }

            if (l <= 0 || w <= 0 || h <= 0)
            {
                lblMessage.Text = "Values must be greater than zero";
                return;
            }

            Shape shape = new Shape();
            VolumeResult obj = new VolumeResult();

            txtRectVolume.Text = obj.DisplayVolume(shape, l, w, h);

            lblMessage.Text = "";
        }

        protected void btnCylinderVolume_Click(object sender, EventArgs e)
        {
            double d, h;

            if (!double.TryParse(txtDiameter.Text, out d) ||
                !double.TryParse(txtCHeight.Text, out h))
            {
                lblMessage.Text = "Please enter valid numeric values";
                return;
            }

            if (d <= 0 || h <= 0)
            {
                lblMessage.Text = "Values must be greater than zero";
                return;
            }

            Shape shape = new Shape();

            double result = shape.CalculateVolume(d, h);

            txtCVolume.Text = result.ToString("0.00");

            lblMessage.Text = "";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");
        }
    }
}
