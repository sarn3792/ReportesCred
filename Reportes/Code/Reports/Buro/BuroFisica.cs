using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Reportes
{
    public class BuroFisica : Report
    {
        public override String CreateFile(DataTable data)
        {
            String fileName = FileSettings.fileName("BuroFisica");
            try
            {
                using (StreamWriter file = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(FileSettings.filePath + fileName), false, Encoding.ASCII))
                {
                    //header
                    INTF intf = new INTF();
                    //intf.version = this.GetFolio().PadLeft(2, '0'); //consecutive folio
                    file.Write(intf.ToString());
                    file.Write("\n"); //new line

                    //body
                    PN pn = new PN(); //nombre del cliente
                    PA pa = new PA(); //dirección del cliente
                    TL tl = new TL(); //crédito del cliente
                    for (int i=0; i < data.Rows.Count; i++)
                    {
                        //nombre del cliente
                        pn.apellidoPaterno.Descripcion = data.Rows[i]["APELLIDO PATERNO"].ToString();
                        pn.apellidoMaterno.Descripcion = data.Rows[i]["APELLIDO MATERNO"].ToString();
                        pn.apellidoAdicional.Descripcion = data.Rows[i]["APELLIDO ADICIONAL"].ToString();
                        pn.primerNombre.Descripcion = data.Rows[i]["PRIMER NOMBRE"].ToString();
                        pn.segundoNombre.Descripcion = data.Rows[i]["SEGUNDO NOMBRE"].ToString();
                        pn.fechaNacimiento.Descripcion = data.Rows[i]["FECHA DE NACIMIENTO"].ToString();
                        pn.RFC.Descripcion = data.Rows[i]["RFC"].ToString();
                        pn.prefifoPersonal.Descripcion = data.Rows[i]["PREFIJO PERSONAL O PROFESIONAL"].ToString();
                        pn.nacionalidad.Descripcion = data.Rows[i]["NACIONALIDAD"].ToString();
                        pn.tipoResidencia.Descripcion = data.Rows[i]["TIPO DE RESIDENCIA"].ToString();
                        pn.numeroLicenciaConducir.Descripcion = data.Rows[i]["NUMERO DE LICENCIA DE CONDUCIR"].ToString();
                        pn.estadoCivil.Descripcion = data.Rows[i]["ESTADO CIVIL"].ToString();
                        pn.sexo.Descripcion = data.Rows[i]["SEXO"].ToString();
                        pn.numeroCedulaProfesional.Descripcion = data.Rows[i]["NUMERO DE CEDULA PROFESIONAL"].ToString();
                        pn.numeroRegistroElectoral.Descripcion = data.Rows[i]["NUMERO DE REGISTRO ELECTORAL"].ToString();
                        pn.CURP.Descripcion = data.Rows[i]["CLAVE DE IDENTIFICACION UNICA"].ToString();
                        pn.clavePais.Descripcion = data.Rows[i]["CLAVE DEL PAIS"].ToString();
                        pn.numeroDependientes.Descripcion = data.Rows[i]["NUMERO DE DEPENDIENTES"].ToString() != String.Empty && data.Rows[i]["NUMERO DE DEPENDIENTES"].ToString().Trim() != "0" ? data.Rows[i]["NUMERO DE DEPENDIENTES"].ToString().PadLeft(2, '0') : String.Empty;
                        file.Write(pn.ToString());
                        file.Flush();

                        //dirección del cliente
                        pa.direccion.Descripcion = data.Rows[i]["PRIMER LINEA DE DIRECCION"].ToString();
                        pa.direccion2.Descripcion = data.Rows[i]["SEGUNDA LINEA DE DIRECCION"].ToString();
                        pa.colonia.Descripcion = data.Rows[i]["COLONIA O  POBLACION"].ToString();
                        pa.municipio.Descripcion = data.Rows[i]["DELEGACION O MUNICIPIO"].ToString();
                        pa.ciudad.Descripcion = data.Rows[i]["CIUDAD"].ToString();
                        pa.estado.Descripcion = data.Rows[i]["ESTADO"].ToString();
                        pa.codigoPostal.Descripcion = data.Rows[i]["CODIGO POSTAL"].ToString();
                        pa.numeroTelefono.Descripcion = data.Rows[i]["NUMERO DE TELEFONO"].ToString();
                        file.Write(pa.ToString());
                        file.Flush();

                        //crédito del cliente
                        tl.numeroCuenta.Descripcion = data.Rows[i]["NUMERO DE CUENTA O CREDITO ACTUAL"].ToString();
                        tl.tipoResponsabilidadCuenta.Descripcion = data.Rows[i]["TIPO DE RESPONSABILIDAD DE LA CUENTA"].ToString();
                        tl.tipoCuenta.Descripcion = data.Rows[i]["TIPO DE CUENTA"].ToString();
                        tl.tipoContrato.Descripcion = data.Rows[i]["TIPO DE CONTRATO O PRODUCTO"].ToString();
                        tl.monedaCredito.Descripcion = data.Rows[i]["MONEDA DEL CREDITO"].ToString();
                        tl.numeroPagos.Descripcion = data.Rows[i]["NUMERO DE PAGOS"].ToString();
                        tl.frecuenciaPagos.Descripcion = data.Rows[i]["FRECUENCIA DE PAGOS"].ToString();
                        tl.montoPagar.Descripcion = data.Rows[i]["MONTO A PAGAR"].ToString();
                        tl.fechaAperturaCredito.Descripcion = data.Rows[i]["FECHA DE APERTURA DE CUENTA O CREDITO"].ToString();
                        tl.fechaUltimoPago.Descripcion = data.Rows[i]["FECHA DE ULTIMO PAGO"].ToString();
                        tl.fechaUltimaDisposicion.Descripcion = data.Rows[i]["FECHA DE ULTIMA COMPRA O DISPOSICION"].ToString();
                        tl.fechaCierre.Descripcion = data.Rows[i]["FECHA DE CIERRE"].ToString();
                        tl.fechaReporteInformacion.Descripcion = data.Rows[i]["FECHA DE REPORTE DE INFORMACION"].ToString();
                        tl.creditoMaximoAutorizado.Descripcion = data.Rows[i]["CREDITO MAXIMO AUTORIZADO"].ToString();
                        tl.saldoActual.Descripcion = data.Rows[i]["SALDO ACTUAL"].ToString();
                        tl.limiteCredito.Descripcion = data.Rows[i]["LIMITE DE CREDITO"].ToString();
                        tl.saldoVencido.Descripcion = data.Rows[i]["SALDO VENCIDO"].ToString();
                        //tl.numeroPagosVencidos.Descripcion = data.Rows[i][""].ToString();
                        tl.formaPagoActual.Descripcion = data.Rows[i]["FORMA DE PAGO ACTUAL"].ToString();
                        tl.claveObservacion.Descripcion = data.Rows[i]["CLAVE DE OBSERVACION"].ToString();
                        tl.fechaPrimerIncumplimiento.Descripcion = data.Rows[i]["FECHA DE PRIMER INCUMPLIMIENTO"].ToString();
                        tl.saldoInsoluto.Descripcion = data.Rows[i]["SALDO INSOLUTO DEL PRINCIPAL"].ToString();
                        tl.montoUltimoPago.Descripcion = data.Rows[i]["MONTO DE ULTIMO PAGO"].ToString();
                        file.Write(tl.ToString());
                        file.Flush();

                        //file.Write("\n"); //new line
                        //file.Flush();
                    }

                    //footer
                    TR tr = new TR();
                    file.Write(tr.ToString());
                    file.Flush();
                    //this.UpdateFolio();
                }
            } catch (Exception ex)
            {
                throw ex;
            }

            return fileName;
        }

        public override DataTable ImplementReport(DateTime inicio, DateTime final)
        {
            try
            {
                base.query = "SELECT * FROM [dbo].[xvr_xBurodeCredito_F_X]";
                base.cmd = new SqlCommand(base.query, base.conn);
                base.cmd.CommandTimeout = 0;
                base.conn.Open();
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

        private String GetFolio()
        {
            try
            {
                String query = String.Format(@"SELECT *
                                              FROM xRptRuntime_Reportes");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);
                if(aux.Rows.Count > 0)
                {
                    return aux.Rows[0]["BuroFisicaVersion"].ToString();
                }

                throw new Exception("El folio no fue encontrado");
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateFolio()
        {
            try
            {
                String query = String.Format(@"UPDATE xRptRuntime_Reportes SET BuroFisicaVersion = BuroFisicaVersion + 1 WHERE RI_ID = 1");
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}