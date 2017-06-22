using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Reportes.Code
{
    public class Criterios
    {
        public String criterio;
        public String tipoOpcion;

        public Criterios()
        {

        }

        public Criterios (String criterio, String tipoOpcion)
        {
            this.criterio = criterio;
            this.tipoOpcion = tipoOpcion;
        }

        public DataTable Get()
        {
            try
            {
                String query = String.Format(@"SELECT *
                                            FROM xCNBVCriterios
                                            ORDER BY IDCriterio");
                DataBaseSettings db = new DataBaseSettings();
                return db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByID(String id)
        {
            try
            {
                String query = String.Format(@"SELECT *
                                            FROM xCNBVCriterios
                                            WHERE IDCriterio = {0}
                                            ORDER BY IDCriterio", id);
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = db.GetDataTable(query);

                if(aux.Rows.Count > 0)
                {
                    this.criterio = aux.Rows[0]["Criterio"].ToString();
                    this.tipoOpcion = aux.Rows[0]["TipoOpcion"].ToString();
                }
                else
                {
                    throw new Exception(String.Format("Criterio con el ID {0} no fue encontrado", id));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert()
        {
            try
            {
                String query = String.Format("INSERT INTO xCNBVCriterios (Criterio, TipoOpcion) VALUES ('{0}', '{1}')", criterio, tipoOpcion);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int idCriterio, String criterio, String tipoOpcion)
        {
            try
            {
                String query = String.Format("UPDATE xCNBVCriterios SET Criterio = '{0}', TipoOpcion = '{2}' WHERE IDCriterio = {1}", criterio, idCriterio, tipoOpcion);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idCriterio)
        {
            try
            {
                String query = String.Format("DELETE xCNBVCriterios WHERE IDCriterio = {0}", idCriterio);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get(String criterio)
        {
            try
            {
                String query = String.Format(@"SELECT *
                                            FROM xCNBVCriterios
                                            WHERE Criterio LIKE '%{0}%'
                                            ORDER BY IDCriterio", criterio);
                DataBaseSettings db = new DataBaseSettings();
                return db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}