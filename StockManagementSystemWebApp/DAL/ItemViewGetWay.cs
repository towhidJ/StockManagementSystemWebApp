using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class ItemViewGetWay:BaseGetway
    {
        private ItemView itemView;

        public ItemViewGetWay()
        {
            itemView = new ItemView();
        }
        public List<Company> GetAllCompany()
        {

            string query = "SELECT * FROM CompanyTB";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Company> companyList = new List<Company>();
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
                Catagory catagory = new Catagory();
                catagory.Id = Convert.ToInt32(Reader["Id"]);
                catagory.CatagoryName = Reader["CatagoryName"].ToString();

                catagoryList.Add(catagory);
            }
            Connection.Close();

            return catagoryList;
        }
       

        public List<ItemView> GetAllItemSummery(int companyId, int catagoryId)
        {

            string query = "SELECT ItemName, CompanyName,Quantity,Reorder FROM ItemView WHERE CompanyId =" + companyId + " AND CatagoryId =" + catagoryId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<ItemView> stockList = new List<ItemView>();
            while (Reader.Read())
            {
                itemView = new ItemView();
                //itemView.Id = Convert.ToInt32(Reader["Id"]);
                //searchView.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                itemView.CompanyName = Reader["CompanyName"].ToString();
                itemView.ItemName = Reader["ItemName"].ToString();
                itemView.Quantity = Convert.ToInt32(Reader["Quantity"]);
                //searchView.Date = Reader["Date"].ToString();
                itemView.Reorder = Convert.ToInt32(Reader["Reorder"]);



                stockList.Add(itemView);
            }
            Connection.Close();

            return stockList;
        }
    }
}