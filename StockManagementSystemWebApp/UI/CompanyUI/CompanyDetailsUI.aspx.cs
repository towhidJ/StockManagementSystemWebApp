using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;

namespace StockManagementSystemWebApp.UI.CompanyUI
{
    public partial class CompanyDetailsUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public CompanyDetailsUI()
        {
            companyManager = new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyGridView.DataSource = companyManager.GetAllCompany();
                companyGridView.DataBind();
            }
            
        }

        protected void ActionList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList cont = (DropDownList)sender;

            if (cont.SelectedValue == "update")
            {
                DataControlFieldCell cell = cont.Parent as DataControlFieldCell;
                GridViewRow row = cell.Parent as GridViewRow;
                HiddenField hiddenField = row.FindControl("HiddenField") as HiddenField;
                Response.Redirect("CompanyUpdateUI.aspx?Id=" + hiddenField.Value);
            }
            else if (cont.SelectedValue == "delete")
            {
                DataControlFieldCell cell = cont.Parent as DataControlFieldCell;
                GridViewRow row = cell.Parent as GridViewRow;
                HiddenField hiddenField = row.FindControl("HiddenField") as HiddenField;
                Response.Redirect("CompanyDeleteUI.aspx?Id=" + hiddenField.Value);
            }
        }
    }
}