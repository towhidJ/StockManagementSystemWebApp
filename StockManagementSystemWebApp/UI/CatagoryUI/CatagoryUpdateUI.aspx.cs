using System;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.CatagoryUI
{
    public partial class CatagoryUpdateUI : System.Web.UI.Page
    {
        private CatagoryManager catagoryManager;
        public CatagoryUpdateUI()
        {
         catagoryManager = new CatagoryManager();   
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                Catagory catagory = catagoryManager.GetCatagoryById(id);

                idHiddenField.Value = catagory.Id.ToString();
                catagoryNameTextBox.Text = catagory.CatagoryName;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Catagory catagory = new Catagory();
            catagory.Id = Convert.ToInt32(idHiddenField.Value);
            catagory.CatagoryName = catagoryNameTextBox.Text;

            catagoryManager.UpdateStudentById(catagory);
            Response.Redirect("CatagoryDetailsUI.aspx");
        }
    }
}