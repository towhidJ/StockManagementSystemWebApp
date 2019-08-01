using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace StockManagementSystemWebApp.UI.StockOutUI
{
    public partial class StockOutSetupUI : System.Web.UI.Page
    {
        private StockOutManager stockOutManager;
        private ItemManager itemManager;
        private BaseGetway baseGetway;
        DataTable dt = new DataTable();
        List<StockOut> stockOutList = new List<StockOut>();

        public StockOutSetupUI()
        {
            stockOutManager = new StockOutManager();
            itemManager = new ItemManager();
            baseGetway = new BaseGetway();
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
            companyDropDownList.DataSource = stockOutManager.GetAllCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select  company", "0"));
            itemDropDownList.Items.Insert(0, new ListItem("Select  item", "0"));
        }



        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(companyDropDownList.SelectedValue);
            itemDropDownList.DataSource = stockOutManager.GetAllItemsByCompanyId(id);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select item", "0"));
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
            int id = Convert.ToInt32(itemDropDownList.SelectedValue);
            if (id == 0)
            {
                reorderLevelTextBox.Text = "0";
            }
            else
            {
                Item item = stockOutManager.GetReorderLevelByItemId(id);
                reorderLevelTextBox.Text = item.Reorder.ToString();
            }
            StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
            int quantity = stockIn.Quantity;
            if (quantity == 0)
            {
                availableQuantityTextBox.Text = "0";
            }
            else
            {
                availableQuantityTextBox.Text = quantity.ToString();
            }




        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            int stock = Convert.ToInt32(availableQuantityTextBox.Text) - Convert.ToInt32(stockOutQuantityTextBox.Text);
            if (companyDropDownList.SelectedIndex > 0)
            {

                if (itemDropDownList.SelectedIndex > 0)
                {
                    if (stockOutQuantityTextBox.Text != "" || stockOutQuantityTextBox.Text != "0")
                    {
                        if (stock >= 0)
                        {
                            int id = Convert.ToInt32(itemDropDownList.SelectedValue);
                            StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                            int quantity = stockIn.Quantity;
                            StockOut stockOut = new StockOut();
                            stockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                            stockOut.CompanyName = companyDropDownList.SelectedItem.ToString();
                            stockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                            stockOut.ItemName = itemDropDownList.SelectedItem.ToString();
                            stockOut.AvailableQuentity = quantity;
                            stockOut.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                            stockOut.Reoeder = Convert.ToInt32(reorderLevelTextBox.Text);
                            if (ViewState["StockOut"] == null)
                            {
                                stockOutList.Add(stockOut);
                                ViewState["StockOut"] = stockOutList;
                                stockOutGridView.DataSource = stockOutList;
                                stockOutGridView.DataBind();
                            }
                            else
                            {
                                List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
                                int count = 0;
                                foreach (StockOut stockout in stockOutList)
                                {
                                    int entryItemId = stockout.ItemId;
                                    int entryCompanyId = stockout.CompanyId;
                                    int companyId = stockOut.CompanyId;
                                    int itemId = stockOut.ItemId;
                                    if (entryCompanyId == companyId && entryItemId == itemId)
                                    {
                                        stockOut.Quantity += stockout.Quantity;
                                        if (stockOut.Quantity > stockOut.AvailableQuentity)
                                        {
                                            stockOut.Quantity = stockout.Quantity;
                                            stockOutList.RemoveAt(count);
                                            messageLabel.Text = "Stock out of Available Quantity!";
                                            break;
                                        }
                                        else
                                        {
                                            stockOutList.RemoveAt(count);
                                            count++;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        count++;
                                        continue;
                                    }
                                }
                                stockOutList.Add(stockOut);
                                ViewState["StockOut"] = stockOutList;
                                stockOutGridView.DataSource = stockOutList;
                                stockOutGridView.DataBind();
                            }
                        }
                        else
                        {
                            messageLabel.Text = "Stock out gets out of range!";
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Stock out quantity must be greater than 0!";
                    }
                }
                else
                {
                    messageLabel.Text = "Select an item!";
                }
            }
            else
            {
                messageLabel.Text = "Select a company!";
            }
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            string action = "Damage";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.Quantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.Quantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuentity = grossQuantity;
                    stockOut.Type = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items set as damaged " + stockOutManager.Save(stockOut);

                    companyDropDownList.SelectedValue = "0";
                    itemDropDownList.SelectedValue = "0";
                    availableQuantityTextBox.Text = "";
                    reorderLevelTextBox.Text = "";
                    stockOutQuantityTextBox.Text = "";
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
            }
            else
            {
                messageLabel.Text = "No data";
            }
            
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            string action = "Lost";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.Quantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.Quantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuentity = grossQuantity;
                    stockOut.Type = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items set as lost " + stockOutManager.Save(stockOut);
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
            }
            else
            {
                messageLabel.Text = "No data";
            }
        }



        protected void sellButton_Click(object sender, EventArgs e)
        {
            string action = "Sell";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.Quantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.Quantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuentity = grossQuantity;
                    stockOut.Type = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items sold " + stockOutManager.Save(stockOut);
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
            }
            else
            {
                messageLabel.Text = "No data";
            }
        }
    }
}