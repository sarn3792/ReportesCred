using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Reportes
{
    public abstract class Report
    {
        protected String connectionString;
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected String query = String.Empty;
        protected DataTable data = new DataTable();

        public Report()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Testing"].ConnectionString;
            conn = new SqlConnection(connectionString);           
        }

        public abstract DataTable ImplementReport(DateTime inicio, DateTime final);
        public abstract String CreateFile(DataTable data);
    }
}