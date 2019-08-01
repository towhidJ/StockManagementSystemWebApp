using System;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.CatagoryUI
{
    public partial class CatagorySetupUI : System.Web.UI.Page
    {
        private CatagoryManager catagoryManager;

        public CatagorySetupUI()
        {
            catagoryManager = new CatagoryManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
                                
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Catagory catagory = new Catagory();
            catagory.CatagoryName = catagoryNameTextBox.Text;

            string message = catagoryManager.Save(catagory);
            catagoryMessageLabel.Text = message;
        }


        protected void showDetailsButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CatagoryDetailsUI.aspx");
        }
    }
}