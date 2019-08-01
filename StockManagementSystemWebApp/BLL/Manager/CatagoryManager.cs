using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Models;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class CatagoryManager
    {
        private CatagoryGetway catagoryGetway;

        public CatagoryManager()
        {
            catagoryGetway = new CatagoryGetway();
        }

        public string Save(Catagory catagory)
        {

            bool isCatagoryNameExixts = catagoryGetway.IsCatagoryExists(catagory.CatagoryName);

            if (isCatagoryNameExixts)
            {
                return "Catagory Alrady Exixts";
            }
            else
            {
                int rowAffect = catagoryGetway.Sava(catagory);
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

        public List<Catagory> GetAllCatagory()
        {
            return catagoryGetway.GetAllCatagory();
        }


        public Catagory GetCatagoryById(int id)
        {
            return catagoryGetway.GetCatagoryById(id);
        }

        public string UpdateStudentById(Catagory catagory)
        {
            int rowAffect = catagoryGetway.UpdateCatagoyById(catagory);
            if (rowAffect > 0)
            {
                return "Update Successful";
            }
            else
            {
                return "Update Failed";
            }
        }

        public string DeleteCatagoryById(Catagory catagory)
        {
            int rowAffect = catagoryGetway.DeleteCatagoyById(catagory);
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