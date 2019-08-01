using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.SearchAndViewItemsSummary
{
    public partial class SearchAndViewItemsSummaryUI : System.Web.UI.Page
    {
        
        private ItemViewManager itemViewManager;

        public SearchAndViewItemsSummaryUI()
        {
            itemViewManager = new ItemViewManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CascadingDropdown();
            }
        }

        public void CascadingDropdown()
        {
            companyDropDownList.DataSource = itemViewManager.GetAllCompany();
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));

            catagoryDropDownList.DataSource = itemViewManager.GetAllCatagory();
            catagoryDropDownList.DataBind();
            catagoryDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {

            SearchView searchView = new SearchView();

            if (companyDropDownList.SelectedValue == "0")
            {
                messageLabel.Text = "Does't Select Any Company";

            }
            else if (catagoryDropDownList.SelectedValue == "0")
            {
                messageLabel.Text = "Does't Select Any Catagory";

            }
            else
            {
                messageLabel.Text = "";
                searchView.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                searchView.CatagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                searchResultGridView.DataSource = itemViewManager.GetAllItemSummery(searchView.CompanyId, searchView.CatagoryId);
                searchResultGridView.DataBind();
                companyDropDownList.SelectedValue= "0";
                catagoryDropDownList.SelectedValue = "0";
            }
        }

       
    }
}