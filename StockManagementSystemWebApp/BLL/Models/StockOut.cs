using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Models
{
    [Serializable]
    public class StockOut
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int AvailableQuentity { get; set; }
        public int Reoeder { get; set; }
    }
}