using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class StockOutManager
    {
        private StockOutGetWay stockOutGetWay;

        public StockOutManager()
        {
            stockOutGetWay = new StockOutGetWay();
        }

        public List<Company> GetAllCompany()
        {
            return stockOutGetWay.GetAllCompany();
        }
        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            return stockOutGetWay.GetAllItemsByCompanyId(companyId);
        }

        public Item GetReorderLevelByItemId(int itemId)
        {
            return stockOutGetWay.GetReorderLevelByItemId(itemId);
        }

        public StockIn GetAvailableQuantityByItemId(int itemId)
        {
            return stockOutGetWay.GetAvailableQuantityByItemId(itemId);
        }

        public int UpdateAvailableQuantity(StockOut stockOut)
        {
            int rowAffect = stockOutGetWay.UpdateAvailableQuantity(stockOut);
            return rowAffect;
        }

        public string Save(StockOut stockOut)
        {
            int rowAffect = stockOutGetWay.Save(stockOut);
            if (rowAffect > 0)
            {
                return "successfully!";
            }
            else
            {
                return "Failed to";
            }
        }
    }
}