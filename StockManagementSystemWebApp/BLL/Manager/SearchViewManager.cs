using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class SearchViewManager
    {
        private SearchViewGetWay searchViewGetWay;

        public SearchViewManager()
        {
            searchViewGetWay = new SearchViewGetWay();
        }
        public List<SearchView> SearchByDate(string fromDate, string toDate)
        {
            return searchViewGetWay.SearchByDate(fromDate, toDate);
        }

        public List<Company> GetAllCompany()
        {
            return searchViewGetWay.GetAllCompany();
        }
        public List<Catagory> GetAllCatagory()
        {
            return searchViewGetWay.GetAllCatagory();
        }

        public List<SearchView> GetAllSaleSummery(int companyId, int catagoryId)
        {
            return searchViewGetWay.GetAllSaleSummery(companyId,catagoryId);
        }
    }
}