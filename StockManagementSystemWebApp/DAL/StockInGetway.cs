using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class StockInGetway:BaseGetway
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

        public bool IsItemExists(int itemId)
        {

            string query = "SELECT * FROM StockIn WHERE ItemId = '" + itemId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isItemExists = Reader.HasRows;
            Connection.Close();
            return isItemExists;
        }


        public List<Item> GetAllItem()
        {

            string query = "SELECT * FROM ItemsTB";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Item> itemList = new List<Item>();


            while (Reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.ItemName = Reader["ItemName"].ToString();

                itemList.Add(item);
            }
            Connection.Close();

            return itemList;
        }

        public int Sava(StockIn stockIn)
        {

            string query = "INSERT INTO StockInTB VALUES("+stockIn.ItemId+","+stockIn.Quantity+")";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public StockIn GetStockInById(int id)
        {

            string query = "SELECT * FROM StockInTB WHERE Id =" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            StockIn stockIn = null;

            if (Reader.Read())
            {
                stockIn = new StockIn();
                stockIn.Id = Convert.ToInt32(Reader["Id"]);
                stockIn.ItemId = Convert.ToInt32(Reader["ItemId"]);

                stockIn.Quantity = Convert.ToInt32(Reader["Quantity"]);

            }
            Connection.Close();
            return stockIn;
        }


        public int UpdateStockInById(StockIn stockIn)
        {

            string query = "UPDATE StockInTB SET Quantity ='" + stockIn.Quantity + "' WHERE ItemId =" + stockIn.ItemId + " ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}