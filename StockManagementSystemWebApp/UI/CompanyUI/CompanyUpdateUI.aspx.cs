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
    public partial class CompanyUpdateUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public CompanyUpdateUI()
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
                companyyNameTextBox.Text = company.CompanyName;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Id = Convert.ToInt32(idHiddenField.Value);
            company.CompanyName = companyyNameTextBox.Text;

            companyManager.UpdateCompanyById(company);
            Response.Redirect("CompanyDetailsUI.aspx");
        }
    }
}