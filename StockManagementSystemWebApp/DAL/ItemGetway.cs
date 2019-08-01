using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class ItemGetway :BaseGetway
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

        public List<Catagory> GetAllCatagory()
        {

            string query = "SELECT * FROM CatagoryTB";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Catagory> catagoryList = new List<Catagory>();


            while (Reader.Read())
            {
                Catagory ctagory = new Catagory();
                ctagory.Id = Convert.ToInt32(Reader["Id"]);
                ctagory.CatagoryName = Reader["CatagoryName"].ToString();

                catagoryList.Add(ctagory);
            }
            Connection.Close();

            return catagoryList;
        }

        public Item GetltemById(int itemId)
        {
            string query = "SELECT * FROM Item WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();

            Item item = new Item();
            item.Id = Convert.ToInt32(Reader["ItemID"]);
            item.ItemName = Convert.ToString(Reader["ItemName"]);
            item.Reorder = Convert.ToInt32(Reader["ReorderLevel"]);
            item.Quantity = Convert.ToInt32(Reader["AvailableQuantity"]);

            Connection.Close();

            return item;
        }
        public int Sava(Item item)
        {
            
            string query = "INSERT INTO ItemsTB VALUES('"+item.CatagoryId+"','"+item.CompanyId+"','"+item.ItemName+"',"+item.Reorder+")";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsItemExists(string ItemName)
        {
            
            string query = "SELECT * FROM ItemsTB WHERE ItemName = '" + ItemName + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isItemExists = Reader.HasRows;
            Connection.Close();
            return isItemExists;
        }



    }
}