using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Models
{
    public class SearchView
    {
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int Reorder { get; set; }
        public int AvailableQuantity { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}