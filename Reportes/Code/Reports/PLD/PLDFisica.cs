using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class PLDFisica : Report
    {
        public override String CreateFile(DataTable data)
        {
            try
            {
                String fileName = FileSettings.fileName("PLDFisica");
                String fullFileName = System.Web.HttpContext.Current.Server.MapPath(FileSettings.filePath + fileName);
                FileSettings.CreateCSVFile(data, fullFileName, 
                                          HttpContext.Current.Session["pldTipo"] != null && HttpContext.Current.Session["pldTipo"].ToString() != String.Empty ? HttpContext.Current.Session["pldTipo"].ToString() : String.Empty,
                                          HttpContext.Current.Session["pld"] != null && HttpContext.Current.Session["pld"].ToString() != String.Empty ? HttpContext.Current.Session["pld"].ToString() : String.Empty);
                return fileName;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable ImplementReport(DateTime inicio, DateTime final)
        {
            base.query = "SELECT * FROM xvr_pld_clientes_F";
            base.cmd = new SqlCommand(base.query, base.conn);
            try
            {
                base.conn.Open();
                base.cmd.CommandTimeout = 0;
                base.reader = base.cmd.ExecuteReader();
                base.data.Load(base.reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.conn.Close();
            }

            return base.data;
        }
    }
}