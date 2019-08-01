using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class SearchViewGetWay:BaseGetway
    {
        private SearchView searchView;

        public SearchViewGetWay()
        {
            searchView = new SearchView();
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
        public List<SearchView> SearchByDate(string fromDate, string toDate)
        {

            string query = "SELECT  ItemName, CompanyName,SUM(Quantity) AS Quantity  FROM SearchView WHERE Type='sell' AND Date BETWEEN '" + fromDate + "' AND '" + toDate + "' GROUP BY ItemName,CompanyName";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<SearchView> stockList = new List<SearchView>();
            while (Reader.Read())
            {
                searchView = new SearchView();
                //searchView.Id = Convert.ToInt32(Reader["Id"]);
                searchView.CompanyName = Reader["CompanyName"].ToString();
                searchView.ItemName = Reader["ItemName"].ToString();
                //searchView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchView.Quantity = Convert.ToInt32(Reader["Quantity"]);
                //searchView.Date = Reader["Date"].ToString();
               // searchView.Reorder = Convert.ToInt32(Reader["Reorder"]);



                stockList.Add(searchView);
            }
            Connection.Close();

            return stockList;
        }



        public List<SearchView> GetAllSaleSummery(int companyId,int catagoryId)
        {

            string query = "SELECT ItemName, CompanyName,Quantity,AvailableQuantity ,Reorder FROM SearchView WHERE Type='sell' AND CompanyId =" + companyId + " AND CatagoryId =" + catagoryId ;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<SearchView> stockList = new List<SearchView>();
            while (Reader.Read())
            {
                searchView = new SearchView();
                //searchView.Id = Convert.ToInt32(Reader["Id"]);
                //searchView.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                searchView.CompanyName = Reader["CompanyName"].ToString();
                searchView.ItemName = Reader["ItemName"].ToString();
                searchView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                searchView.Quantity = Convert.ToInt32(Reader["Quantity"]);
                //searchView.Date = Reader["Date"].ToString();
                searchView.Reorder = Convert.ToInt32(Reader["Reorder"]);



                stockList.Add(searchView);
            }
            Connection.Close();

            return stockList;
        }

    }
}