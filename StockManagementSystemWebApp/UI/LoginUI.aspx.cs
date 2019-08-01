using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        private string connectionString =
         WebConfigurationManager.ConnectionStrings["StockManagementSystemConString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) From login Where username = '" + userNameTextBox.Text + "' and password = '" + passwordTextBox.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Response.Redirect("IndexUI.aspx");

            }
            else
            {
                messageLabel.Text = "Incorret Username or Password";
            }
        }
    }
}