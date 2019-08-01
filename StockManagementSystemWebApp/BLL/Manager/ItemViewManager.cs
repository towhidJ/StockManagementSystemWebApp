using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class ItemViewManager
    {
        private ItemViewGetWay itemViewGetWay;

        public ItemViewManager()
        {
            itemViewGetWay = new ItemViewGetWay();
        }
        public List<Company> GetAllCompany()
        {
            return itemViewGetWay.GetAllCompany();
        }
        public List<Catagory> GetAllCatagory()
        {
            return itemViewGetWay.GetAllCatagory();
        }

        public List<ItemView> GetAllItemSummery(int companyId, int catagoryId)
        {
            return itemViewGetWay.GetAllItemSummery(companyId, catagoryId);
        }
    }
}