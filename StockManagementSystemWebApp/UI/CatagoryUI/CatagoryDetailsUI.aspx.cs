using System;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;

namespace StockManagementSystemWebApp.UI.CatagoryUI
{
    public partial class CatagoryDetailsUI : System.Web.UI.Page
    {
        private CatagoryManager catagoryManager;
        public CatagoryDetailsUI()
        {
            catagoryManager = new CatagoryManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryGridView.DataSource = catagoryManager.GetAllCatagory();
                catagoryGridView.DataBind();
            }
                
            
        }

         protected void ActionList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList cont = (DropDownList) sender;

             if (cont.SelectedValue == "update")
             {
                 DataControlFieldCell cell = cont.Parent as DataControlFieldCell;
                 GridViewRow row = cell.Parent as GridViewRow;
                 HiddenField hiddenField = row.FindControl("HiddenField") as HiddenField;
                 Response.Redirect("CatagoryUpdateUI.aspx?Id=" + hiddenField.Value);
             }
             else if (cont.SelectedValue == "delete")
             {
                 DataControlFieldCell cell = cont.Parent as DataControlFieldCell;
                 GridViewRow row = cell.Parent as GridViewRow;
                 HiddenField hiddenField = row.FindControl("HiddenField") as HiddenField;
                 Response.Redirect("CatagoryDeleteUI.aspx?Id=" + hiddenField.Value);
             }
            
        }
    }
}