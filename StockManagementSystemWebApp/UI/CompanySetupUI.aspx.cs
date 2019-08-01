using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI
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
            Company company = new Company();
            company.CompanyName = companyNameTextBox.Text;
            string message = companyManager.Save(company);
            companyMessageLabel.Text = message;
        }
    }
}