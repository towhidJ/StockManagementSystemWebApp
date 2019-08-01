using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class StockOutGetWay:BaseGetway
    {
        public List<Company> GetAllCompany()
        {

            string query = "SELECT * FROM CompanyTB";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Company> companyList = new List<Company>();
            bool Select = true;
            while (Reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.CompanyName = Reader["CompanyName"].ToString();

                companyList.Add(company);
            }
            Connection.Close();

            return companyList;
        }


        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM ItemsTB WHERE CompanyId = " + companyId + " ";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            List<Item> items = new List<Item>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.ItemName = Reader["ItemName"].ToString();

                items.Add(item);
            }
            Connection.Close();

            return items;
        }

        public Item GetReorderLevelByItemId(int itemId)
        {
            string query = "SELECT Reorder FROM ItemsTB WHERE Id = " + itemId + " ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Item item = new Item();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                item.Reorder = Convert.ToInt32(Reader["Reorder"]);
            }
            Connection.Close();
            return item;
        }

        public StockIn GetAvailableQuantityByItemId(int itemId)
        {
            string query = "SELECT Quantity FROM StockInTB WHERE ItemId =" + itemId + " ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            StockIn stockIn = new StockIn();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                stockIn.Quantity = Convert.ToInt32(Reader["Quantity"]);
            }
            Connection.Close();

            return stockIn;
        }

        public int UpdateAvailableQuantityByItemId(StockIn stockIn)
        {
            string query = "UPDATE StockInTB SET Quantity = " + stockIn.Quantity + " WHERE ItemId =" + stockIn.ItemId + "  ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public int UpdateAvailableQuantity(StockOut stockOut)
        {
            string query = "UPDATE StockInTB SET Quantity = " + stockOut.AvailableQuentity + " WHERE ItemId = " + stockOut.ItemId + " ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int Save(StockOut stockOut)
        {
            string query = "INSERT INTO StockOutTB(ItemId,Quantity,Type,Reorder) VALUES(" + stockOut.ItemId + "," + stockOut.Quantity + ",'" + stockOut.Type + "'," + stockOut.Reoeder + ")";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

       
    }
}