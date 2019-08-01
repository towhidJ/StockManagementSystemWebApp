using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Models
{
    public class ItemView
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Reorder { get; set; }
    }
}