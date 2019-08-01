using System;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.CompanyUI
{
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public CompanySetupUI()
        {
            companyManager = new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company ctagory = new Company();
            ctagory.CompanyName = companyNameTextBox.Text;
            string message = companyManager.Save(ctagory);
            companyMessageLabel.Text = message;
        }


        protected void showcompanyDetailsButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CompanyDetailsUI.aspx");
        }
    }
}