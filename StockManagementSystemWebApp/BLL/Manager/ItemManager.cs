using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class ItemManager
    {
        private ItemGetway itemGetway;
        

        public ItemManager()
        {
            itemGetway = new ItemGetway();
        }
        public string Save(Item item)
        {

            bool isItemExixts = itemGetway.IsItemExists(item.ItemName);

            if (isItemExixts)
            {
                return "Item Already Exists";
            }
            else
            {
                int rowAffect = itemGetway.Sava(item);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";

                }
            }



        }
        public List<Company> GetAllCompany()
        {
            return itemGetway.GetAllCompany();
        }
        public List<Catagory> GetAllCatagory()
        {
            return itemGetway.GetAllCatagory();
        }

        public Item GetltemById(int itemId)
        {
            return itemGetway.GetltemById(itemId);
        }
    }
}