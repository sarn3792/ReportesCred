using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Reportes
{
    public static class LlenarDropDowns
    {
        /// <summary>
        /// Se obtiene el/los número(s) de contrato(s)
        /// </summary>
        /// <param name="ddl"></param>
        public static void NumeroControl(DropDownList ddl, String cusID)
        {
            try
            {
                String query = String.Format(@"select DISTINCT custid, RTRIM(user5) + '-' + LTRIM(user6) as 'Contrato'
                                            from ardoc 
                                            where doctype = 'IN' and user5 <>'' and CustId = '{0}'
                                            order by custid", cusID);
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);
                ddl.Items.Insert(0, new ListItem("--Seleccionar número de control--", "0"));
                List<ListItem> data = aux.AsEnumerable().Select(m => new ListItem()
                {
                    Value = m.Field<String>("Contrato"),
                    Text = m.Field<String>("Contrato"),
                }).ToList();

                int i = 1;
                foreach (ListItem item in data)
                {
                    ddl.Items.Insert(i, item);
                    i++;
                }
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InstrumentoMonetario(DropDownList ddl)
        {
            try
            {
                String query = String.Format(@"SELECT IDInstrumentoMonetario, InstrumentoMonetario
                                                FROM xCNBVInstrumentoMonetario");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                ddl.Items.Insert(0, new ListItem("--Seleccionar instrumento monetario--", "0"));
                List<ListItem> data = aux.AsEnumerable().Select(m => new ListItem()
                {
                    Value = m.Field<String>("IDInstrumentoMonetario"),
                    Text = m.Field<String>("InstrumentoMonetario"),
                }).ToList();

                int i = 1;
                foreach (ListItem item in data)
                {
                    ddl.Items.Insert(i, item);
                    i++;
                }
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void TipoOperacion(DropDownList ddl)
        {
            try
            {
                String query = String.Format(@"SELECT X.IDTipoOperacion, X.TipoOperacion
                                                FROM xCNBVTipoOperacion X");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                ddl.Items.Insert(0, new ListItem("--Seleccionar tipo de operación--", "0"));
                List<ListItem> data = aux.AsEnumerable().Select(m => new ListItem()
                {
                    Value = m.Field<String>("IDTipoOperacion"),
                    Text = m.Field<String>("TipoOperacion"),
                }).ToList();

                int i = 1;
                foreach (ListItem item in data)
                {
                    ddl.Items.Insert(i, item);
                    i++;
                }
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DescripcionOperacion(DropDownList ddl)
        {
            try
            {
                String query = String.Format(@"SELECT x.IDCriterio, x.Criterio
                                                FROM xCNBVCriterios X
                                                WHERE X.TipoOpcion = 'OpCrit'");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                ddl.Items.Insert(0, new ListItem("--Seleccionar descripción de la operación--", "0"));
                List<ListItem> data = aux.AsEnumerable().Select(m => new ListItem()
                {
                    Value = Convert.ToString(m.Field<int>("IDCriterio")),
                    Text = m.Field<String>("Criterio"),
                }).ToList();

                int i = 1;
                foreach (ListItem item in data)
                {
                    ddl.Items.Insert(i, item);
                    i++;
                }
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AutorizadoPor(DropDownList ddl)
        {
            try
            {
                String query = String.Format("SELECT * FROM xPldGeneral");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);
                ddl.Items.Insert(0, new ListItem("--Seleccionar persona--", "0"));

                if (aux.Rows.Count > 0)
                {
                    int i = 1;

                    if(aux.Rows[0]["Integrante1"] != null && aux.Rows[0]["Integrante1"] != DBNull.Value && aux.Rows[0]["Integrante1"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["Integrante1"].ToString().Trim(), "1"));
                        i++;
                    }

                    if (aux.Rows[0]["Integrante2"] != null && aux.Rows[0]["Integrante2"] != DBNull.Value && aux.Rows[0]["Integrante2"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["Integrante2"].ToString().Trim(), "2"));
                        i++;
                    }

                    if (aux.Rows[0]["Integrante3"] != null && aux.Rows[0]["Integrante3"] != DBNull.Value && aux.Rows[0]["Integrante3"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["Integrante3"].ToString().Trim(), "3"));
                        i++;
                    }

                    if (aux.Rows[0]["Integrante4"] != null && aux.Rows[0]["Integrante4"] != DBNull.Value && aux.Rows[0]["Integrante4"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["Integrante4"].ToString().Trim(), "4"));
                        i++;
                    }

                    if (aux.Rows[0]["AuditorInt"] != null && aux.Rows[0]["AuditorInt"] != DBNull.Value && aux.Rows[0]["AuditorInt"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["AuditorInt"].ToString().Trim(), "5"));
                        i++;
                    }

                    if (aux.Rows[0]["OficialdeCum"] != null && aux.Rows[0]["OficialdeCum"] != DBNull.Value && aux.Rows[0]["OficialdeCum"].ToString().Trim() != String.Empty)
                    {
                        ddl.Items.Insert(i, new ListItem(aux.Rows[0]["OficialdeCum"].ToString().Trim(), "6"));
                    }
                }

                ddl.DataBind();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void MotivoNoReportar(DropDownList ddl)
        {
            try
            {
                String query = String.Format(@"SELECT x.IDCriterio, x.Criterio
                                                FROM xCNBVCriterios X
                                                WHERE X.TipoOpcion = 'NoRept'");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                ddl.Items.Insert(0, new ListItem("--Seleccionar motivo--", "0"));
                List<ListItem> data = aux.AsEnumerable().Select(m => new ListItem()
                {
                    Value = Convert.ToString(m.Field<int>("IDCriterio")),
                    Text = m.Field<String>("Criterio"),
                }).ToList();

                int i = 1;
                foreach (ListItem item in data)
                {
                    ddl.Items.Insert(i, item);
                    i++;
                }
                ddl.DataBind();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}