using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class CompanyGetway : BaseGetway
    {
       
        public int Sava(Company company)
        {

            string query = "INSERT INTO CompanyTB(CompanyName) VALUES('" + company.CompanyName + "')";
             Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsCompanyExists(string companyName)
        {
            
            string query = "SELECT * FROM CompanyTB WHERE CompanyName = '" + companyName + "'";
             Command = new SqlCommand(query, Connection);
            Connection.Open();
             Reader = Command.ExecuteReader();
            bool isCompanyExists = Reader.HasRows;
            Connection.Close();
            return isCompanyExists;
        }

        public List<Company> GetAllCompany()
        {
            
            string query = "SELECT * FROM CompanyTB  ORDER BY CompanyName ASC";
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


        public Company GetCompanyById(int id)
        {
            
            string query = "SELECT * FROM CompanyTB WHERE Id =" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
             Reader = Command.ExecuteReader();
            Company company = null;

            if (Reader.Read())
            {
                company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.CompanyName = Reader["CompanyName"].ToString();

            }
            Connection.Close();
            return company;
        }


        public int UpdateCompanyById(Company company)
        {
           
            string query = "UPDATE CompanyTB SET CompanyName ='" + company.CompanyName + "' WHERE Id =" + company.Id + " ";
             Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int DeleteCompanyById(Company company)
        {
           
            string query = "Delete CompanyTB  WHERE Id =" + company.Id + " ";
            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}