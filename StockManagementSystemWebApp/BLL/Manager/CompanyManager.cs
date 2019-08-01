using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class CompanyManager
    {
         private CompanyGetway companyGetway;

        public CompanyManager()
        {
            companyGetway = new CompanyGetway();
        }
        public string Save(Company company)
        {

            bool isCompanyExixts = companyGetway.IsCompanyExists(company.CompanyName);

            if (isCompanyExixts)
            {
                return "Company Already Exists";
            }
            else
            {
                int rowAffect = companyGetway.Sava(company);
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
            return companyGetway.GetAllCompany();
        }


        public Company GetCompanyById(int id)
        {
            return companyGetway.GetCompanyById(id);
        }

        public string UpdateCompanyById(Company company)
        {
            int rowAffect = companyGetway.UpdateCompanyById(company);
            if (rowAffect > 0)
            {
                return "Update Successful";
            }
            else
            {
                return "Update Failed";
            }
        }

        public string DeleteCompanyById(Company company)
        {
            int rowAffect = companyGetway.DeleteCompanyById(company);
            if (rowAffect > 0)
            {
                return "Delete Successful";
            }
            else
            {
                return "Delete Failed";
            }
        }
    }
}