using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.ViewSalesBetweenTwoDates
{
    public partial class ViewSalesBetweenTwoDatesUI : System.Web.UI.Page
    {
        private SearchViewManager searchViewManager;

        public ViewSalesBetweenTwoDatesUI()
        {
            searchViewManager = new SearchViewManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            SearchView searchView = new SearchView();
            
            string fromDate = String.Format("{0:dd/MM/yy}", fromDateTextBox.Text);
            string toDate = String.Format("{0:dd/MM/yy}", toDateTextBox.Text);

            searchView.FromDate = fromDate;
            searchView.ToDate = toDate;

            searchResultGridView.DataSource = searchViewManager.SearchByDate(fromDate, toDate);
            searchResultGridView.DataBind();
            fromDateTextBox.Text = String.Empty;
            toDateTextBox.Text = String.Empty;
        }
    }
}