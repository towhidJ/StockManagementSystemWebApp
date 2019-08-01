using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Models
{
    public class StockIn
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int Reorder { get; set; }
        public int Quantity { get; set; }
    }
}