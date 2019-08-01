using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.UI.StockInUI
{
    public partial class StockInSetup : System.Web.UI.Page
    {
        private StockInManager stockInManager;
        private BaseGetway baseGetway;

        public StockInSetup()
        {
            stockInManager = new StockInManager();
            baseGetway = new BaseGetway();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CascadingDropdown();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            StockIn stockIn = new StockIn();

            if (availableQuantityTextBox.Text=="")
            {
                stockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                stockIn.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                string message = stockInManager.Save(stockIn);
                stockInQuantityTextBox.Text = "";
                reorderLevelTextBox.Text = "";
                itemDropDownList.SelectedValue = "0";
                messageLabel.Text = message;

            }
            else
            {
                stockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                int quantity = Convert.ToInt32(availableQuantityTextBox.Text);
                stockIn.Quantity = quantity+Convert.ToInt32(stockInQuantityTextBox.Text);
                string message = stockInManager.UpdateStockInById(stockIn);
                stockInQuantityTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                reorderLevelTextBox.Text = "";
                itemDropDownList.SelectedValue = "0";
                messageLabel.Text = message;
            }
        }

        public void CascadingDropdown()
        {
            companyDropDownList.DataSource = stockInManager.GetAllCompany();
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0,new ListItem("Select Company","0"));
            itemDropDownList.Items.Insert(0,new ListItem("Select Item","0"));
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex>0)
            {
                int id = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.DataSource = stockInManager.GetAllItemsByCompanyId(id);
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataValueField = "Id";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, new ListItem("Select item", "0"));
            }
            else
            {
                reorderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                stockInQuantityTextBox.Text = "";
                messageLabel.Text = "Does't Select Any Item";
                stockInQuantityTextBox.Enabled = false;
            }
            
        }

        protected void itemDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex > 0)
            {
                messageLabel.Text = "";
                stockInQuantityTextBox.Enabled = true;
                baseGetway.Connection.Open();
                int id = Convert.ToInt32(itemDropDownList.SelectedValue);
                string query = "SELECT * FROM ItemsTB WHERE Id = " + id;
                baseGetway.Command = new SqlCommand(query, baseGetway.Connection);
                baseGetway.Command.CommandType = CommandType.Text;
                baseGetway.DataAdapter = new SqlDataAdapter(baseGetway.Command);
                DataTable dt = new DataTable();
                baseGetway.DataAdapter.Fill(dt);
                reorderLevelTextBox.Text = dt.Rows[0]["Reorder"].ToString();
                baseGetway.Connection.Close();

                
                string query1 =
                    "SELECT * FROM StockInTB INNER JOIN ItemsTB on StockInTB.ItemId = ItemsTB.Id WHERE ItemsTB.Id=" + id;
                baseGetway.Command = new SqlCommand(query1, baseGetway.Connection);
                baseGetway.Command.CommandType = CommandType.Text;
                baseGetway.Connection.Open();
                baseGetway.Command.Parameters.AddWithValue(id.ToString(), itemDropDownList.SelectedValue);
                SqlDataReader reader = baseGetway.Command.ExecuteReader();
                if (reader.Read())
                {
                    availableQuantityTextBox.Text = reader["Quantity"].ToString();
                }
                else
                {
                    availableQuantityTextBox.Text = "";
                }

                

                baseGetway.Connection.Close();
            }
            else
            {
                reorderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                stockInQuantityTextBox.Text = "";
                messageLabel.Text = "Does't Select Any Item";
                stockInQuantityTextBox.Enabled = false;
            }


        }

       
    }
}