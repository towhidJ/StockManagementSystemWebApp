using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StockManagementSystemWebApp.BLL.Models
{
    public class Item
    {
        public int CatagoryId { get; set; }
        public string ItemName { get; set; }
        public int Reorder { get; set; }
        public int CompanyId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}