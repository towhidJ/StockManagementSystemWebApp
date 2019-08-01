using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.UI.ItemUI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        private ItemManager itemManager;
        private BaseGetway baseGetway;
        public ItemSetupUI()
        {
            baseGetway = new BaseGetway();
            itemManager = new ItemManager();
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryDropDownList.DataSource = itemManager.GetAllCatagory();
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0,new ListItem("Please Select Catagory","0"));


                companyDropDownList.DataSource = itemManager.GetAllCompany();
                companyDropDownList.DataBind();

                companyDropDownList.Items.Insert(0, new ListItem("Please Select Company","0"));
            }
            
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {

            Item item = new Item();

            if (companyDropDownList.SelectedValue == "0")
            {
                messageLabel.Text = "Does't Select Any Company";
                
            }
            else if (catagoryDropDownList.SelectedValue=="0")
            {
                messageLabel.Text = "Does't Select Any Catagory";
                
            }
            else if (itemNameTextBox.Text == "")
            {
                messageLabel.Text = "Item Does't Empty";
            }
            else
            {
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                item.CatagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                
                
                item.ItemName = itemNameTextBox.Text;
                if (reorderLevelTextBox.Text == "")
                {
                    item.Reorder = 0;
                }
                else
                {
                    item.Reorder = Convert.ToInt32(reorderLevelTextBox.Text);
                }
                string message = itemManager.Save(item);
                messageLabel.Text = message;
            }
            
            
        }
    }

}