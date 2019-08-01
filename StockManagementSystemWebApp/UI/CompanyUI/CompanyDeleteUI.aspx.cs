using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.CompanyUI
{
    public partial class CompanyDeleteUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;
        public CompanyDeleteUI()
        {
            companyManager = new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                Company company = companyManager.GetCompanyById(id);
                idHiddenField.Value = company.Id.ToString();
                companyNameTextBox.Text = company.CompanyName;
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Id = Convert.ToInt32(idHiddenField.Value);
            company.CompanyName = companyNameTextBox.Text;

            companyManager.DeleteCompanyById(company);
            Response.Redirect("CompanyDetailsUI.aspx");
        }
    }
}