using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class CNBVPreocupantes : Report
    {
        public override String CreateFile(DataTable data)
        {
            String fileName = FileSettings.fileName("CNBVPreocupantes");

            using (StreamWriter file = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(FileSettings.filePath + fileName), false))
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    CNBVPreocupantesBean information = new CNBVPreocupantesBean(true); //the class validate the fields and set its correct format

                    information.PeriodoReporte = DateTime.Now.ToString("yyyyMMdd");
                    information.Folio = Convert.ToString(1 + i);
                    information.OrganoSupervisor = data.Rows[i][4].ToString();
                    information.ClaveSujetoObligado = data.Rows[i][5].ToString();
                    information.Localidad = data.Rows[i][6].ToString();
                    information.CodigoPostal = data.Rows[i][7].ToString();
                    information.TipoOperacion = data.Rows[i][8].ToString();
                    information.InstrumentoMonetario = data.Rows[i][9].ToString();
                    information.NumeroCuenta = data.Rows[i][10].ToString();
                    //information.Monto = Convert.ToDecimal(data.Rows[i][11].ToString());
                    information.Monto = 0;
                    information.Moneda = data.Rows[i][12].ToString();
                    information.FechaOperacion = data.Rows[i][13].ToString();
                    information.FechaDeteccion = data.Rows[i][14].ToString();
                    information.Nacionalidad = data.Rows[i][15].ToString();
                    information.TipoPersona = data.Rows[i][16].ToString();
                    information.RazonSocial = data.Rows[i][17].ToString();
                    information.Nombre = data.Rows[i][18].ToString();
                    information.ApellidoPaterno = data.Rows[i][19].ToString();
                    information.ApellidoMaterno = data.Rows[i][20].ToString();
                    information.RFC = data.Rows[i][21].ToString();
                    information.CURP = data.Rows[i][22].ToString();
                    information.FechaNacimiento = data.Rows[i][23].ToString();
                    information.Domicilio = data.Rows[i][24].ToString();
                    information.Colonia = data.Rows[i][25].ToString();
                    information.Ciudad = data.Rows[i][26].ToString();
                    information.Telefono = data.Rows[i][27].ToString();
                    information.ActividadEconomica = data.Rows[i][28].ToString();
                    information.ConsecutivoCuentas = data.Rows[i][29].ToString();
                    information.NumeroCuentaC = data.Rows[i][30].ToString();
                    information.ClaveSujetoObligadoC = data.Rows[i][31].ToString();
                    information.NombreTitularCuenta = data.Rows[i][32].ToString();
                    information.ApellidoPaternoC = data.Rows[i][33].ToString();
                    information.ApellidoMaternoC = data.Rows[i][34].ToString();
                    information.DescripcionOperacion = data.Rows[i][35].ToString();
                    information.Razones = data.Rows[i][36].ToString();
                    file.Write(information.ToString());
                    file.Write(Environment.NewLine);
                }
                file.Close();
            }

            return fileName;
        }

        public override DataTable ImplementReport(DateTime inicio, DateTime final)
        {
            base.query = ReportsOperations.GetQueryReportsApproved("3", inicio, final);
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