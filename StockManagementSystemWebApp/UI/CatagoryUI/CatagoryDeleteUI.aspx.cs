using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.UI.CatagoryUI
{
    public partial class CtagoyDeleteUI : System.Web.UI.Page
    {
        private CatagoryManager catagoryManager;

        public CtagoyDeleteUI()
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

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Catagory catagory = new Catagory();
            catagory.Id = Convert.ToInt32(idHiddenField.Value);
            catagory.CatagoryName = catagoryNameTextBox.Text;

            catagoryManager.DeleteCatagoryById(catagory);
            Response.Redirect("CatagoryDetailsUI.aspx");
        }
    }
}