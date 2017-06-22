using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Reportes
{
    public class BuroMoral : Report
    {
        public override String CreateFile(DataTable data)
        {
            String fileName = FileSettings.fileName("BuroMoral");
            try
            {
                using (StreamWriter file = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(FileSettings.filePath + fileName), false, Encoding.ASCII))
                {
                    //header
                    HD header = new HD();
                    header.periodo.Descripcion = this.GetPeriod();
                    file.Write(header.ToString());
                    file.Write("\n");

                    //body
                    EM body = new EM();
                    //AC ac = new AC();
                    CR cr = new CR();
                    DE de = new DE();
                    AV av = new AV();
                    int totalCantidad = 0;

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        body.RFC.Descripcion = data.Rows[i]["RFC DEL ACREDITADO"].ToString();
                        body.CURP.Descripcion = data.Rows[i]["CODIGO DE CIUDADANO (CURP DE MEXICO)"].ToString();
                        body.nombreCompania.Descripcion = data.Rows[i]["NOMBRE DE LA COMPAÑIA"].ToString();
                        body.primerNombre.Descripcion = data.Rows[i]["PRIMER NOMBRE"].ToString();
                        body.segundoNombre.Descripcion = data.Rows[i]["SEGUNDO NOMBRE"].ToString();
                        body.apellidoPaterno.Descripcion = data.Rows[i]["APELLIDO PATERNO"].ToString();
                        body.apellidoMaterno.Descripcion = data.Rows[i]["APELLIDO MATERNO"].ToString();
                        body.nacionalidad.Descripcion = data.Rows[i]["NACIONALIDAD"].ToString();
                        body.calificacionCartera.Descripcion = data.Rows[i]["CALIFICACION DE CARTERA"].ToString();
                        body.actividadEconomica1.Descripcion = data.Rows[i]["ACTIVIDAD ECONÓMICA 1 BANXICO / SCIAN"].ToString().PadLeft(11, '0');
                        body.actividadEconomica2.Descripcion = data.Rows[i]["ACTIVIDAD ECONÓMICA 2 BANXICO / SCIAN"].ToString().PadLeft(11, '0'); 
                        body.actividadEconomica3.Descripcion = data.Rows[i]["ACTIVIDAD ECONÓMICA 3 BANXICO / SCIAN"].ToString().PadLeft(11, '0'); 
                        body.primerLineaDireccion.Descripcion = data.Rows[i]["PRIMER LINEA DE DIRECCION"].ToString();
                        body.segundaLineaDireccion.Descripcion = data.Rows[i]["SEGUNDA LINEA DE DIRECCION"].ToString();
                        body.colonia.Descripcion = data.Rows[i]["COLONIA O  POBLACION"].ToString();
                        body.municipio.Descripcion = data.Rows[i]["DELEGACION O MUNICIPIO"].ToString();
                        body.ciudad.Descripcion = data.Rows[i]["CIUDAD"].ToString();
                        body.nombreEstadoMexico.Descripcion = data.Rows[i]["NOMBRE DE ESTADO PARA DOMICILIOS EN MEXICO"].ToString();
                        body.codigoPostal.Descripcion = data.Rows[i]["CODIGO POSTAL"].ToString();
                        body.numeroTelefono.Descripcion = data.Rows[i]["NUMERO DE TELEFONO"].ToString();
                        body.extensionTelefonica.Descripcion = data.Rows[i]["EXTENSION TELEFONICA"].ToString();
                        body.numeroFax.Descripcion = data.Rows[i]["NUMERO DE FAX"].ToString();
                        body.tipoCliente.Descripcion = data.Rows[i]["TIPO DE CLIENTE"].ToString();
                        body.nombreEstadoExtranjero.Descripcion = data.Rows[i]["NOMBRE DE ESTADO EN EL PAIS EXTRANJERO"].ToString();
                        body.pais.Descripcion = data.Rows[i]["PAIS DE ORIGEN DEL DOMICILIO"].ToString();
                        body.claveConsolidacion.Descripcion = data.Rows[i]["CLAVE DE CONSOLIDACION"].ToString().PadLeft(8, '0');
                        body.filler.Descripcion = data.Rows[i]["FILLER"].ToString();

                        file.Write(body.ToString());

                        //accionista
                        //ac.RFCAccionista.Descripcion = data.Rows[i]["RFC DEL ACCIONISTA"].ToString();
                        //ac.CURP.Descripcion = data.Rows[i]["CODIGO DE CIUDADANO(CURP EN MEXICO) DEL ACCIONISTA"].ToString();
                        //ac.nombreCompaniaAccionista.Descripcion = data.Rows[i]["NOMBRE DE LA COMPAÑIA ACCIONISTA"].ToString();
                        //ac.primerNombreAccionista.Descripcion = data.Rows[i]["PRIMER NOMBRE DEL ACCIONISTA"].ToString();
                        //ac.segundoNombreAccionista.Descripcion = data.Rows[i]["SEGUNDO NOMBRE DEL ACCIONISTA"].ToString();
                        //ac.apellidoPaternoAccionista.Descripcion = data.Rows[i]["APELLIDO PATERNO DEL ACCIONISTA"].ToString();
                        //ac.apellidoMaternoAccionista.Descripcion = data.Rows[i]["APELLIDO MATERNO DEL ACCIONISTA"].ToString();
                        //ac.porcentajeAccionista.Descripcion = data.Rows[i]["PORCENTAJE DEL ACCIONISTA"].ToString();
                        //ac.primeraLineaDireccion.Descripcion = data.Rows[i]["PRIMER LINEA DE DIRECCION DEL ACCIONISTA"].ToString();
                        //ac.segundaLineaDireccion.Descripcion = data.Rows[i]["SEGUNDA LIBEA DE DIRECCION DEL ACCIONISTA"].ToString(); //error en la N
                        //ac.colonia.Descripcion = data.Rows[i]["COLONIA O POBLACION"].ToString();
                        //ac.municipio.Descripcion = data.Rows[i]["DELEGACION O MUNICIPIO*"].ToString();
                        //ac.ciudad.Descripcion = data.Rows[i]["CIUDAD*"].ToString();
                        //ac.nombreEstadoMexico.Descripcion = data.Rows[i]["NOMBRE DE ESTADO PARA DOMICILIOS EN MEXICO"].ToString();
                        //ac.codigoPostal.Descripcion = data.Rows[i]["CODIGO POSTAL"].ToString();
                        //ac.numeroTelefono.Descripcion = data.Rows[i]["NUMERO DE TELEFONO"].ToString();
                        //ac.extensionTelefonica.Descripcion = data.Rows[i]["EXTENSION TELEFONICA"].ToString();
                        //ac.numeroFax.Descripcion = data.Rows[i]["NUMERO DE FAX"].ToString();
                        //ac.tipoAccionista.Descripcion = data.Rows[i]["TIPO DE ACCIONISTA"].ToString();
                        //ac.estadoExtranjero.Descripcion = data.Rows[i]["NOMBRE DE ESTADO EN EL PAIS EXTRANJERO*"].ToString();
                        //ac.pais.Descripcion = data.Rows[i]["PAIS DE ORIGEN DEL DOMICILIO"].ToString();
                        //ac.filler.Descripcion = data.Rows[i]["FILLER*"].ToString();

                        //file.Write(ac.ToString());

                        //crédito
                        cr.RFC.Descripcion = data.Rows[i]["RFC DEL ACREDITADO*"].ToString();
                        cr.numeroExperienciasCrediticias.Descripcion = data.Rows[i]["NUMERO DE EXPERIENCIAS CREDITICIAS"].ToString();
                        cr.numeroCuenta.Descripcion = data.Rows[i]["NUMERO DE CUENTA,CREDITO O CONTRATO"].ToString().PadLeft(6, '0');
                        cr.numeroCuentaAnterior.Descripcion = data.Rows[i]["NUMERO DE CUENTA, CREDITO O CONTRATO ANTERIOR"].ToString();
                        cr.fechaAperturaCredito.Descripcion = data.Rows[i]["FECHA DE APERTURA DE CUENTA O CREDITO"].ToString().PadLeft(8, '0');
                        cr.plazo.Descripcion = data.Rows[i]["PLAZO"].ToString().PadLeft(5, '0');
                        cr.tipoCredito.Descripcion = data.Rows[i]["TIPO DE CREDITO"].ToString().PadLeft(4, '0');
                        cr.montoAutorizado.Descripcion = data.Rows[i]["MONTO AUTORIZADO DEL CREDITO"].ToString().PadLeft(20, '0');
                        cr.moneda.Descripcion = data.Rows[i]["MONEDA"].ToString().PadLeft(3, '0');
                        cr.numeroPagos.Descripcion = data.Rows[i]["NUMERO DE PAGOS"].ToString().PadLeft(4, '0');
                        cr.frecuenciaPagos.Descripcion = data.Rows[i]["FRECUENCIA DE PAGOS"].ToString().PadLeft(3, '0');
                        cr.importePago.Descripcion = data.Rows[i]["IMPORTE DE PAGO"].ToString().PadLeft(20, '0');
                        cr.fechaUltimoPago.Descripcion = data.Rows[i]["FECHA DE ULTIMO PAGO"].ToString().PadLeft(8, '0');
                        cr.fechaReestructura.Descripcion = data.Rows[i]["FECHA DE REESTRUCTURA"].ToString().PadLeft(8, '0');
                        cr.pagoFinalCuentaMorosa.Descripcion = data.Rows[i]["PAGO FINAL PARA CIERRE DE CUENTA MOROSA (PAGO ENEFECTIVO)"].ToString().PadLeft(20, '0');
                        cr.fechaLiquidacion.Descripcion = data.Rows[i]["FECHA DE LIQUIDACION"].ToString().PadLeft(8, '0');
                        cr.quita.Descripcion = data.Rows[i]["QUITA"].ToString().PadLeft(20, '0');
                        cr.dacionEnPago.Descripcion = data.Rows[i]["DACION EN PAGO"].ToString().PadLeft(20, '0');
                        cr.quebranto.Descripcion = data.Rows[i]["QUEBRANTO O CASTIGO"].ToString().PadLeft(20, '0');
                        cr.claveObservacion.Descripcion = data.Rows[i]["CLAVE DE OBSERVACION"].ToString();
                        cr.marcaCreditoEspecial.Descripcion = data.Rows[i]["MARCA PARA CREDITO ESPECIAL"].ToString();
                        cr.fechaPrimerIncumplimiento.Descripcion = data.Rows[i]["FECHA DE PRIMER INCUMPLIMIENTO"].ToString().PadLeft(8, '0');
                        cr.saldoInsolutoPrincipal.Descripcion = data.Rows[i]["FILLER**"].ToString().PadLeft(20, '0');

                        file.Write(cr.ToString());

                        //detalle crédito
                        de.RFC.Descripcion = data.Rows[i]["RFC DEL ACREDITADO**"].ToString();
                        de.numeroCuenta.Descripcion = data.Rows[i]["NUMERO DE CUENTA,CREDITO O CONTRATO*"].ToString();
                        de.numeroDias.Descripcion = data.Rows[i]["NUMERO DE DIAS DE VENCIDO"].ToString();
                        de.cantidad.Descripcion = data.Rows[i]["CANTIDAD(SALDO)"].ToString().PadLeft(20, '0');
                        totalCantidad += Convert.ToInt32(data.Rows[i]["CANTIDAD(SALDO)"].ToString());

                        file.Write(de.ToString());

                        //avales
                        av.RFC.Descripcion = data.Rows[i]["RFC DEL AVAL"].ToString();
                        av.CURP.Descripcion = data.Rows[i]["CODIGO DE CIUDADANO (CURP EN MEXICO) DEL AVAL"].ToString();
                        av.nombreCompania.Descripcion = data.Rows[i]["NOMBRE DE COMPAñA AVAL"].ToString(); //error ñ
                        av.primerNombre.Descripcion = data.Rows[i]["PRIMER NOMBRE DEL AVAL"].ToString();
                        av.segundoNombre.Descripcion = data.Rows[i]["SEGUNDO NOMBRE DEL AVAL"].ToString();
                        av.apellidoPaterno.Descripcion = data.Rows[i]["APELLIDO PATERNO DEL AVAL"].ToString();
                        av.apellidoMaterno.Descripcion = data.Rows[i]["APELLIDO MATERNO DEL AVAL"].ToString();
                        av.primeraLineaDireccion.Descripcion = data.Rows[i]["PRIMER LINEA DE DIRECCION DEL AVAL"].ToString();
                        av.segundaLineaDireccion.Descripcion = data.Rows[i]["SEGUNDA LINEA DE DIRECCION DEL AVAL"].ToString();
                        av.colonia.Descripcion = data.Rows[i]["COLONIA O POBLACION"].ToString();
                        av.municipio.Descripcion = data.Rows[i]["DELEGACION O MUNICIPIO**"].ToString();
                        av.ciudad.Descripcion = data.Rows[i]["CIUDAD**"].ToString();
                        av.nombreEstadoMexico.Descripcion = data.Rows[i]["NOMBRE DE ESTADO PARA DIRECCIONES EN MEXICO"].ToString();
                        av.codigoPostal.Descripcion = data.Rows[i]["CODIGO POSTAL**"].ToString();
                        av.numeroTelefono.Descripcion = data.Rows[i]["NUMERO DE TELEFONO"].ToString();
                        av.extensionTelefonica.Descripcion = data.Rows[i]["EXTENSION TELEFONICA"].ToString();
                        av.numeroFax.Descripcion = data.Rows[i]["NUMERO DE FAX"].ToString();
                        av.tipoAval.Descripcion = data.Rows[i]["TIPO DE AVAL"].ToString();
                        av.estadoExtranjero.Descripcion = data.Rows[i]["NOMBRE DE ESTADO EN EL PAIS EXTRANJERO**"].ToString();
                        av.pais.Descripcion = data.Rows[i]["PAIS DE ORIGEN DEL DOMICILIO**"].ToString();

                        file.Write(av.ToString());
                    }

                    //footer
                    TS ts = new TS();
                    ts.numeroCompaniasReportadas.Descripcion = data.Rows.Count.ToString().PadLeft(7, '0');
                    ts.totalCantidad.Descripcion = totalCantidad.ToString().PadLeft(30, '0');
                    file.Write(ts.ToString());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fileName;
        }

        public override DataTable ImplementReport(DateTime inicio, DateTime final)
        {
            try
            {
                base.query = "SELECT * FROM xvr_xBurodeCredito_M_X";
                base.cmd = new SqlCommand(base.query, base.conn);
                base.cmd.CommandTimeout = 0;
                base.conn.Open();
                base.reader = base.cmd.ExecuteReader(CommandBehavior.CloseConnection);
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

        private String GetPeriod()
        {
            try
            {
                String query = String.Format(@"SELECT FORMAT(convert(datetime,convert(varchar(10),x.RepEndDate,120)), 'MMyyyy') as RepEndDate  FROM xRptRuntime_Reportes x");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                if(aux.Rows.Count > 0)
                {
                    return aux.Rows[0]["RepEndDate"].ToString();
                }

                throw new Exception("El periodo no fue encontrado");
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}