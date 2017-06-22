using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Reportes
{
    public static class FileSettings
    {
        public static String filePath = "~/Archivos/"; //File will be saved on this rute

        public static String fileName(String reportName)
        {
            String file = String.Empty;
            String claveSujetoObligado = "690753";
            String fecha;

            switch (reportName)
            {
                case "BuroFisica":
                    file = "ReporteINTF" + DateTime.Now.ToString("ddMMyyyy") + ".dat";
                    break;
                case "BuroMoral":
                    file = "BUROCREDPM" + DateTime.Now.ToString("ddMMyyyy") + ".CIB";
                    break;
                case "CNBVInusuales":
                    fecha = DateTime.Now.ToString("yyMMdd");
                    file = "2" + claveSujetoObligado + fecha + ".002" + ".txt";
                    //file = reportName + DateTime.Now.ToString("yyyyMMdd") +".txt";
                    break;
                case "24horas":
                    fecha = DateTime.Now.ToString("yyMMdd");
                    file = "4" + claveSujetoObligado + fecha + ".002" + ".txt";
                    //file = reportName + DateTime.Now.ToString("yyyyMMdd") +".txt";
                    break;
                case "CNBVPreocupantes":
                    fecha = DateTime.Now.ToString("yyMMdd");
                    file = "3" + claveSujetoObligado + fecha + ".002" + ".txt";
                    //file = reportName + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    break;
                case "CNBVRelevantes":
                    fecha = DateTime.Now.ToString("yyMM");
                    file = "1" + claveSujetoObligado + fecha + ".002" + ".txt";
                    //file = reportName + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    break;
                case "PLDFisica":
                    file = reportName + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                    break;
                case "PLDMoral":
                    file = reportName + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                    break;
            }
            return file;
        }

        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public static void CreateCSVFile(DataTable dt, string strFilePath, string tipoCliente, string tipoReporte)
        {
            try
            {
                
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.GetEncoding("iso-8859-1"));
                // First we will write the headers.
                //DataTable dt = m_dsProducts.Tables[0];

                //header
                sw.Write("CREDIJAL SA DE CV SOFOM ENR");
                sw.Write(sw.NewLine);
                sw.Write(sw.NewLine);

                if (tipoCliente != "Todos")
                {
                    sw.Write(String.Format("Clientes {0} {1}", tipoCliente, tipoReporte));
                }
                else
                {
                    sw.Write(String.Format("Todos los clientes {0} ", tipoReporte));
                }

                sw.Write(sw.NewLine);
                sw.Write(sw.NewLine);
                sw.Write(String.Format("Listado generado al: {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                sw.Write(sw.NewLine);
                sw.Write(sw.NewLine);
                //end header

                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write("\t");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString().Trim());   
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write("\t");
                        }
                    }

                    sw.Write(sw.NewLine);
                }
                sw.Close();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string CreateCSVFile(DataTable dt, string strFilePath)
        {
            try
            {

                // Create the CSV file to which grid data will be exported.
                string fileName = System.Web.HttpContext.Current.Server.MapPath(filePath + strFilePath + ".xls");
                StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("iso-8859-1"));
                // First we will write the headers.
                //DataTable dt = m_dsProducts.Tables[0];

                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write("\t");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {

                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString().Trim());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write("\t");
                        }
                    }

                    sw.Write(sw.NewLine);
                }
                sw.Close();
                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}