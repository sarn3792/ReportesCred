using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Criterios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Code.Criterios ct = new Code.Criterios(txtCriterio.Text.Trim(), rblTipoOpcion.SelectedValue);
        //        ct.Insert();
        //        LimpiarCampos();
        //        BindData();
        //        MostarMensaje(true);
        //    } catch (Exception ex)
        //    {
        //        MostarMensaje(false);
        //    }
        //}

        private void BindData()
        {
            LimpiarCampos();
            gvCriterios.DataSource = txtBuscarCriterio.Text.Trim() == String.Empty ? new Code.Criterios().Get() : new Code.Criterios().Get(txtBuscarCriterio.Text.Trim());
            gvCriterios.DataBind();
        }

        private void LimpiarCampos()
        {
            txtCriterio.Text = String.Empty;
        }
        private void MostarMensaje(bool error)
        {
            if (error)
            {
                lblMensaje.Text = "Información guardada correctamente";
                lblMensaje.CssClass = "successfully";
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Text = "Ha ocurrido un error. Contacte al administrador";
                lblMensaje.CssClass = "error";
                lblMensaje.Visible = true;
            }
        }

        private void MostarMensaje(bool error, String mensaje)
        {
            if (error)
            {
                lblMensaje.Text = mensaje;
                lblMensaje.CssClass = "successfully";
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Text = mensaje;
                lblMensaje.CssClass = "error";
                lblMensaje.Visible = true;
            }
        }

        protected void gvCriterios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCriterios.PageIndex = e.NewPageIndex;
                BindData();
                gvCriterios.SelectedIndex = -1;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCriterios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCriterios, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCriterios.Rows)
            {
                if (row.RowIndex == gvCriterios.SelectedIndex) //when row is selected
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = String.Empty;
                    string id = gvCriterios.SelectedRow.Cells[0].Text;
                    Code.Criterios information = new Code.Criterios();
                    information.GetByID(id);
                    txtCriterio.Text = information.criterio;
                    rblTipoOpcion.SelectedValue = information.tipoOpcion;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void gvCriterios_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCriterios.SelectedRow != null) //row es selected
                {
                    Code.Criterios cl = new Code.Criterios();
                    cl.Update(Convert.ToInt32(gvCriterios.SelectedRow.Cells[0].Text), txtCriterio.Text.Trim(), rblTipoOpcion.SelectedItem.Value);
                    this.BindData();
                    gvCriterios.SelectedIndex = -1;
                    MostarMensaje(true, "Criterio editado exitosamente");
                }
                else
                {
                    MostarMensaje(false, "Favor de seleccionar el registro a editar");
                }
            } catch (Exception ex)
            {
                MostarMensaje(false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCriterios.SelectedRow != null) //row es selected
                {
                    Code.Criterios ct = new Code.Criterios();
                    ct.Delete(Convert.ToInt32(gvCriterios.SelectedRow.Cells[0].Text));
                    this.BindData();
                    gvCriterios.SelectedIndex = -1;
                    MostarMensaje(true, "Criterio eliminado exitosamente");
                }
                else
                {
                    MostarMensaje(false, "Favor de seleccionar el registro a eliminar");
                }
            }
            catch (Exception ex)
            {
                MostarMensaje(false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(gvCriterios.SelectedRow == null) //no row es selected
                {
                    if (txtCriterio.Text.Trim() != String.Empty)
                    {
                        Code.Criterios ct = new Code.Criterios(txtCriterio.Text.Trim(), rblTipoOpcion.SelectedValue);
                        ct.Insert();
                        LimpiarCampos();
                        BindData();
                        MostarMensaje(true);
                    }
                    else
                    {
                        MostarMensaje(false, "Favor de ingresar descripción de criterio");
                    }
                }
            }
            catch (Exception ex)
            {
                MostarMensaje(false);
            }
        }

        protected void btnBuscarCriterio_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindData();
            } catch(Exception ex)
            {
                MostarMensaje(false);
            }
        }
    }
}