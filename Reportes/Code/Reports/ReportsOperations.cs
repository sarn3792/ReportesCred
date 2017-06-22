using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class ReportsOperations
    {
        public static void Save(CNBVPreocupantesBean data)
        {
            try
            {
                String query = String.Format(@"INSERT INTO xCnbvSOFOMES (FechaOperacion, ApellidoPaterno1, ApellidoMaterno1, Nombre, Domicilio, Ciudad, Colonia, Telefono, 
                                               FechaNacCons, Nacionalidad, RFC, CURP, Localidad, RazConsInusual, TipoReporte,
                                                OrganoSup, ClaveSujOb1, CodigoPostSuc,
                                                FechaDetOper, PeriodoRep, TipoPersona, RazonSocial) 
                                                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',
                                               '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', 
                                                '{15}', '{16}', '{17}',
                                                '{18}', '{19}', '{20}', '{21}')", DateTime.Now.ToString("yyyyMMdd"), data.ApellidoPaterno, data.ApellidoMaterno,
                                               data.Nombre, data.Domicilio, data.Ciudad, data.Colonia, data.Telefono, data.FechaNacimiento, data.Nacionalidad, data.RFC,
                                               data.CURP, data.Localidad, data.Razones, "3",
                                               data.OrganoSupervisor, data.ClaveSujetoObligado, data.CodigoPostal,
                                               DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMM"), data.TipoPersona, data.RazonSocial);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Save(CNBVInusualesBean data, String tipoReporte)
        {
            try
            {
                String query = String.Format(@"INSERT INTO xCnbvSOFOMES (FechaOperacion, ApellidoPaterno1, ApellidoMaterno1, Nombre, Domicilio, Ciudad, Colonia, Telefono, 
                                               FechaNacCons, Nacionalidad, RFC, CURP, Localidad, RazConsInusual, TipoReporte, Moneda, InstrumentoMon, TipoOperacion, DescrOpera, 
                                                RazonSocial, TipoPersona, OrganoSup, ClaveSujOb1, CodigoPostSuc, NumCueConOpe, Monto,
                                                FechaDetOper, ActividadEco, PeriodoRep) 
                                                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', 
                                                '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', {25},
                                                '{26}', '{27}', '{28}')", DateTime.Now.ToString("yyyyMMdd"), data.ApellidoPaterno, data.ApellidoMaterno,
                                               data.Nombre, data.Domicilio, data.Ciudad, data.Colonia, data.Telefono, data.FechaNacimiento, data.Nacionalidad, data.RFC,
                                               data.CURP, data.Localidad, data.Razones, tipoReporte, data.Moneda, data.InstrumentoMonetario, data.TipoOperacion, 
                                               data.DescripcionOperacion, data.RazonSocial, data.TipoPersona, data.OrganoSupervisor, data.ClaveSujetoObligado, /*data.Localidad , */ data.CodigoPostal, data.NumeroCuenta, data.Monto,
                                               data.FechaDeteccion, data.ActividadEconomica, DateTime.Now.ToString("yyyyMM"));
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CNBVInusualesBean Get(String cusID)
        {
            CNBVInusualesBean data = new CNBVInusualesBean(true);
            try
            {
                String query = String.Format(@"select case when D.DESCR = 'MEXICO' then '1' else '2' end as 'Nacionalidad',
                                            case when A.clave <> '9' then '1' else '2' end  AS 'TipoPersona',
                                            C.OrganoSupervisor,
                                            C.ClaveSujetoObligado,
                                            C.Localidad,
                                            C.CodigoPostal,
                                            A.[RazonSocial],
                                            A.[Nombre],
                                            A.[ApellidoPaterno],
                                            A.[ApellidoMaterno],
                                            A.[taxlocid] RFC,
                                            A.[CURP],
                                            --[FechaNacCons],
                                            A.[Domicilio],
                                            A.[Colonia],
                                            A.[Ciudad],
                                            A.[Phone] Telefono,
                                            AP.new_ClaveSITI 
                                            from xDatosGenerales C, xSOAddress A
                                            LEFT JOIN PaymentsCustomer B ON A.CUSTID = B.PKCUSTOMERSL
											LEFT OUTER JOIN COUNTRY D ON A.COUNTRY = D.CountryID
                                            LEFT JOIN PaymentsOportunity PO on B.PKCustomer = PO.FKCliente
                                            LEFT JOIN [HERMES].[CREDIJAL_MSCRM].dbo.Opportunity O ON O.opportunityID = PO.PKOportunity
                                            LEFT JOIN [HERMES].[CREDIJAL_MSCRM].dbo.new_ActividadPreponderante AP ON AP.new_actividadpreponderanteId = O.new_actividadpreponderante
                                            where A.custid = '{0}'", cusID);
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);
                if (aux.Rows.Count > 0)
                {
                    data.Nacionalidad = aux.Rows[0]["Nacionalidad"] != DBNull.Value ? aux.Rows[0]["Nacionalidad"].ToString() : String.Empty;
                    data.RazonSocial = aux.Rows[0]["RazonSocial"] != DBNull.Value ? aux.Rows[0]["RazonSocial"].ToString() : String.Empty;
                    data.Nombre = aux.Rows[0]["Nombre"] != DBNull.Value ? aux.Rows[0]["Nombre"].ToString() : String.Empty;
                    data.ApellidoPaterno = aux.Rows[0]["ApellidoPaterno"] != DBNull.Value ? aux.Rows[0]["ApellidoPaterno"].ToString() : String.Empty;
                    data.ApellidoMaterno = aux.Rows[0]["ApellidoMaterno"] != DBNull.Value ? aux.Rows[0]["ApellidoMaterno"].ToString() : String.Empty;
                    data.RFC = aux.Rows[0]["RFC"] != DBNull.Value ? aux.Rows[0]["RFC"].ToString() : String.Empty;
                    data.CURP = aux.Rows[0]["CURP"] != DBNull.Value ? aux.Rows[0]["CURP"].ToString() : String.Empty;
                    data.Domicilio = aux.Rows[0]["Domicilio"] != DBNull.Value ? aux.Rows[0]["Domicilio"].ToString() : String.Empty;
                    data.Colonia = aux.Rows[0]["Colonia"] != DBNull.Value ? aux.Rows[0]["Colonia"].ToString() : String.Empty;
                    data.Ciudad = aux.Rows[0]["Ciudad"] != DBNull.Value ? aux.Rows[0]["Ciudad"].ToString() : String.Empty;
                    data.Telefono = aux.Rows[0]["Telefono"] != DBNull.Value ? aux.Rows[0]["Telefono"].ToString() : String.Empty;
                    //
                    data.TipoPersona = aux.Rows[0]["TipoPersona"] != DBNull.Value ? aux.Rows[0]["TipoPersona"].ToString() : String.Empty;
                    data.OrganoSupervisor = aux.Rows[0]["OrganoSupervisor"] != DBNull.Value ? aux.Rows[0]["OrganoSupervisor"].ToString() : String.Empty;
                    data.ClaveSujetoObligado = aux.Rows[0]["ClaveSujetoObligado"] != DBNull.Value ? aux.Rows[0]["ClaveSujetoObligado"].ToString() : String.Empty;
                    data.Localidad = aux.Rows[0]["Localidad"] != DBNull.Value ? aux.Rows[0]["Localidad"].ToString() : String.Empty;
                    data.CodigoPostal = aux.Rows[0]["CodigoPostal"] != DBNull.Value ? aux.Rows[0]["CodigoPostal"].ToString() : String.Empty;

                    //
                    data.FechaOperacion = DateTime.Now.ToString("yyyyMMdd");
                    data.FechaDeteccion = DateTime.Now.ToString("yyyyMMdd");
                    data.ActividadEconomica = aux.Rows[0]["new_ClaveSITI"] != DBNull.Value ? aux.Rows[0]["new_ClaveSITI"].ToString() : String.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public static CNBVPreocupantesBean Get()
        {
            CNBVPreocupantesBean data = new CNBVPreocupantesBean(true);
            try
            {
                String query = String.Format(@"SELECT *
                                            FROM xDatosGenerales");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                if(aux.Rows.Count > 0)
                {
                    data.OrganoSupervisor = aux.Rows[0]["OrganoSupervisor"] != DBNull.Value ? aux.Rows[0]["OrganoSupervisor"].ToString() : String.Empty;
                    data.ClaveSujetoObligado = aux.Rows[0]["ClaveSujetoObligado"] != DBNull.Value ? aux.Rows[0]["ClaveSujetoObligado"].ToString() : String.Empty;
                    data.Localidad = aux.Rows[0]["Localidad"] != DBNull.Value ? aux.Rows[0]["Localidad"].ToString() : String.Empty;
                    data.CodigoPostal = aux.Rows[0]["CodigoPostal"] != DBNull.Value ? aux.Rows[0]["CodigoPostal"].ToString() : String.Empty;
                }

            } catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        public static String GetQueryReports(String value)
        {
            try
            {
                String query = String.Empty;
                switch (value)
                {
                    case "1":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 'Relevante' as 'Tipo reporte', 
                                            x.RazonSocial as 'Nombre', 
                                            x.NumCueConOpe 'Número de control', CASE WHEN x.Estatus IS NULL THEN 'SI' ELSE 'NO' END as Reportar, 
                                            T.TipoOperacion 'Tipo de operación', FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', 
											x.Localidad, x.Monto, 
                                            x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.TipoReporte = '1' ");
                        break;

                    case "2":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 'Inusual' as 'Tipo reporte', 
                                            x.RazonSocial as 'Nombre',
                                            x.NumCueConOpe 'Número de control', CASE WHEN x.Estatus IS NULL THEN 'SI' ELSE 'NO' END as Reportar, 
                                            T.TipoOperacion 'Tipo de operación',  FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', 
											x.Localidad, x.Monto, 
                                            x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.TipoReporte = '2' ");
                        break;

                    case "3":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 'Interna preocupante' as 'Tipo reporte', 
                                            x.RazonSocial as 'Nombre', 
                                            x.NumCueConOpe 'Número de control', CASE WHEN x.Estatus IS NULL THEN 'SI' ELSE 'NO' END as Reportar, 
                                            T.TipoOperacion 'Tipo de operación', FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', 
											x.Localidad, x.Monto, 
                                            x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.TipoReporte = '3' ");
                        break;

                    case "4":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', '24 horas' as 'Tipo reporte', 
                                            x.RazonSocial as 'Nombre',
                                            x.NumCueConOpe 'Número de control', CASE WHEN x.Estatus IS NULL THEN 'SI' ELSE 'NO' END as Reportar, 
                                            T.TipoOperacion 'Tipo de operación', FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', 
											x.Localidad, x.Monto, 
                                            x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.TipoReporte = '4' ");
                        break;

                    case "5":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 
                                            CASE x.TipoReporte WHEN 1 THEN 'Relevante' WHEN 2 THEN 'Inusual' WHEN 3 THEN 'Preocupante' WHEN 4 THEN '24 horas' END as 'Tipo Reporte', 
                                            x.RazonSocial as 'Nombre', 
                                            x.NumCueConOpe 'Número de control', 'SI' as Reportar, T.TipoOperacion 'Tipo de operación', 
                                            FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', x.Localidad, x.Monto, x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.Estatus IS NULL ");
                        break;

                    case "6":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 
                                            CASE x.TipoReporte WHEN 1 THEN 'Relevante' WHEN 2 THEN 'Inusual' WHEN 3 THEN 'Preocupante' WHEN 4 THEN '24 horas' END as 'Tipo Reporte', 
                                            x.RazonSocial as 'Nombre', 
                                            x.NumCueConOpe 'Número de control', 'SI' as Reportar, T.TipoOperacion 'Tipo de operación', 
                                            FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', x.Localidad, x.Monto, x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.Estatus = 'SI' OR x.Estatus IS NULL ");
                        break;

                    case "7":
                        query = String.Format(@"SELECT x.xCnbvSOFOMES as ID, FORMAT(convert(datetime,convert(varchar(10),x.FechaOperacion,120)), 'dd/MM/yyyy') 'Fecha operación', 
                                            CASE x.TipoReporte WHEN 1 THEN 'Relevante' WHEN 2 THEN 'Inusual' WHEN 3 THEN 'Preocupante' WHEN 4 THEN '24 horas' END as 'Tipo Reporte', 
                                            x.RazonSocial as 'Nombre', 
                                            x.NumCueConOpe 'Número de control', 'NO' as Reportar, T.TipoOperacion 'Tipo de operación', 
                                            FORMAT(convert(datetime,convert(varchar(10),x.FechaDetOper, 120)), 'dd/MM/yyyy') 'Periodo detectado', x.Localidad, x.Monto, x.Moneda
                                            FROM xCnbvSOFOMES x LEFT JOIN xCNBVTipoOperacion T ON X.TipoOperacion =  T.IDTipoOperacion
                                            WHERE x.Estatus = 'NO' ");
                        break;
                }

                return query;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetQueryReports(String value, DateTime initialDate, DateTime finalDate)
        {
            try
            {
                initialDate = initialDate.AddMinutes(-1);
                finalDate = finalDate.AddHours(23);
                finalDate = finalDate.AddMinutes(59);

                String query = String.Format(@"{0} AND convert(datetime,convert(varchar(10),x.FechaOperacion,120)) between '{1}' AND '{2}'", GetQueryReports(value),
                                            initialDate.ToString("yyyy-MM-dd HH:mm:ss"), finalDate.ToString("yyyy-MM-dd HH:mm:ss"));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetQueryToExport(String value)
        {
            try
            {
                String query = String.Empty;
                switch (value)
                {
                    case "1":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '1' ");
                        break;

                    case "2":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '2' ");
                        break;

                    case "3":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '3' ");
                        break;

                    case "4":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '4' ");
                        break;

                    case "5":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.Estatus IS NULL ");
                        break;

                    case "6":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.Estatus = 'SI' OR x.Estatus IS NULL ");
                        break;

                    case "7":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.Estatus = 'NO' ");
                        break;
                }

                return query;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetQueryToExport(String value, DateTime initialDate, DateTime finalDate)
        {
            try
            {
                initialDate = initialDate.AddMinutes(-1);
                finalDate = finalDate.AddHours(23);
                finalDate = finalDate.AddMinutes(59);

                String query = String.Format(@"{0} AND convert(datetime,convert(varchar(10),x.FechaOperacion,120)) between '{1}' AND '{2}'", GetQueryToExport(value),
                                            initialDate.ToString("yyyy-MM-dd HH:mm:ss"), finalDate.ToString("yyyy-MM-dd HH:mm:ss"));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetQueryReportsApproved(String value)
        {
            try
            {
                String query = String.Empty;
                switch (value)
                {
                    case "1":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '1' AND (x.Estatus = 'SI' OR x.Estatus IS NULL)");
                        break;

                    case "2":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '2' AND (x.Estatus = 'SI' OR x.Estatus IS NULL)");
                        break;

                    case "3":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '3' AND (x.Estatus = 'SI' OR x.Estatus IS NULL)");
                        break;

                    case "4":
                        query = String.Format(@"SELECT *
                                            FROM xCnbvSOFOMES x
                                            WHERE x.TipoReporte = '4' AND (x.Estatus = 'SI' OR x.Estatus IS NULL)");
                        break;
                }

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetQueryReportsApproved(String value, DateTime initialDate, DateTime finalDate)
        {
            try
            {
                initialDate = initialDate.AddMinutes(-1);
                finalDate = finalDate.AddHours(23);
                finalDate = finalDate.AddMinutes(59);

                String query = String.Format(@"{0} AND convert(datetime,convert(varchar(10),x.FechaOperacion,120)) between '{1}' AND '{2}'", GetQueryReportsApproved(value),
                                            initialDate.ToString("yyyy-MM-dd HH:mm:ss"), finalDate.ToString("yyyy-MM-dd HH:mm:ss"));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String GetDescripcionOperacion(String IDReport)
        {
            try
            {
                String query = String.Format("SELECT RazConsInusual FROM xCnbvSOFOMES WHERE xCnbvSOFOMES = {0}", IDReport);
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);
                if (aux.Rows.Count > 0)
                {
                    return aux.Rows[0]["RazConsInusual"].ToString();
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateRegistro(String ID, String autorizadoPor, String motivoNoReportar)
        {
            try
            {
                String query = String.Format("UPDATE xCnbvSOFOMES SET AutorizadoPor = '{0}', FechaDetOper = '{1}', DescrOpera = '{2}', Estatus = 'NO' WHERE xCnbvSOFOMES = {3}",
                                autorizadoPor, DateTime.Now.ToString("yyyyMMdd"), motivoNoReportar, ID);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePeriod(DateTime date)
        {
            try
            {
                date = date.AddHours(23);
                date = date.AddMinutes(59);
                String query = String.Format("UPDATE xRptRuntime_Reportes SET RepEndDate = '{0}' WHERE RI_ID = 1", date.ToString("yyyy-MM-dd HH:mm:ss"));
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}