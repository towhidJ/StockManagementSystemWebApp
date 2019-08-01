using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemWebApp.DAL
{
    public class BaseGetway
    {
        private string connectionString =
          WebConfigurationManager.ConnectionStrings["StockManagementSystemConString"].ConnectionString;

        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlDataAdapter DataAdapter { get; set; }

        public BaseGetway()
        {
            Connection = new SqlConnection(connectionString);
        }

    }
}