using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.BLL.Models;

namespace StockManagementSystemWebApp.DAL
{
    public class CatagoryGetway :BaseGetway
    {
       
        public int Sava(Catagory catagory)
        {
           
            string query = "INSERT INTO CatagoryTB VALUES('" +catagory.CatagoryName  + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }


        public bool IsCatagoryExists(string catagoryName)
        {
            
            string query = "SELECT * FROM CatagoryTB WHERE CatagoryName = '" + catagoryName+ "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
           Reader = Command.ExecuteReader();
            bool isCatagoryExists = Reader.HasRows;
            Connection.Close();
            return isCatagoryExists;
        }

        public List<Catagory> GetAllCatagory()
        {
            
            string query = "SELECT * FROM CatagoryTB";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
             Reader = Command.ExecuteReader();

            List<Catagory> companyList = new List<Catagory>();

            while (Reader.Read())
            {
                Catagory ctagory = new Catagory();
                ctagory.Id = Convert.ToInt32(Reader["Id"]);
                ctagory.CatagoryName = Reader["CatagoryName"].ToString();

                companyList.Add(ctagory);
            }
            Connection.Close();

            return companyList;
        }

        public Catagory GetCatagoryById(int id)
        {
           
            string query = "SELECT * FROM CatagoryTB WHERE Id =" + id;
             Command = new SqlCommand(query, Connection);
            Connection.Open();
             Reader = Command.ExecuteReader();
            Catagory catagory = null;

            if (Reader.Read())
            {
                catagory = new Catagory();
                catagory.Id = Convert.ToInt32(Reader["Id"]);
                catagory.CatagoryName = Reader["CatagoryName"].ToString();
                
            }
            Connection.Close();
            return catagory;
        }


        public int UpdateCatagoyById(Catagory catagory)
        {
            
            string query = "UPDATE CatagoryTB SET CatagoryName ='" + catagory.CatagoryName + "' WHERE Id =" + catagory.Id + " ";
             Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int DeleteCatagoyById(Catagory catagory)
        {
            
            string query = "Delete CatagoryTB  WHERE Id =" + catagory.Id + " ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

    }
}