using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class StockInManager
    {
        private StockInGetway stockInGetway;

        public StockInManager()
        {
            stockInGetway = new StockInGetway();
        }

       
        public string Save(StockIn stockIn)
        {
    
               int rowAffect = stockInGetway.Sava(stockIn);
                if (rowAffect > 0)
                {
                    return "Item Add Successful";
                }
                else
                {
                    return "Item Add Failed";

                }

        }

        public string UpdateStockInById(StockIn stockIn)
        {
            int rowAffect = stockInGetway.UpdateStockInById(stockIn);
            if (rowAffect > 0)
            {
                return "Item Add Successful";
            }
            else
            {
                return "Item Add Failed";
            }
        }

        public StockIn GetStockInById(int id)
        {
            return stockInGetway.GetStockInById(id);
        }
        public List<Company> GetAllCompany()
        {
            return stockInGetway.GetAllCompany();
        }
        public List<Item> GetAllItem()
        {
            return stockInGetway.GetAllItem();
        }
        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            return stockInGetway.GetAllItemsByCompanyId(companyId);
        }
    }
}