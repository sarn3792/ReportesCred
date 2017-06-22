using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Inusuales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                this.CargarInformacionDropDowns();
            }
        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            try
            {
                CNBVInusualesBean data = Session["Object"] as CNBVInusualesBean;
                data.NumeroCuenta = ddlNumControl.SelectedItem.Text;
                data.Monto = Convert.ToDecimal(txtMonto.Text.Trim());
                data.Moneda = ddlMoneda.SelectedItem.Value;
                data.InstrumentoMonetario = ddlInstumentoMonetario.SelectedItem.Value;
                data.TipoOperacion = ddlTipoOperacion.SelectedItem.Value;
                data.DescripcionOperacion = ddlDescripcionOperacion.SelectedItem.Text;
                data.Razones = txtCausa.Text.Trim();
                ReportsOperations.Save(data, rblTipoReporte.SelectedValue);
                LimpiarCampos();
                MostarMensaje(true);

            } catch (Exception ex)
            {
                MostarMensaje(false);
                throw ex;
            }
            
        }

        protected void btnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CNBVInusualesBean data = ReportsOperations.Get(txtNumCliente.Text.Trim());
                Session["Object"] = data;
                ddlNumControl.Items.Clear();

                txtCliente.Text = data.RazonSocial;
                LlenarDropDowns.NumeroControl(ddlNumControl, txtNumCliente.Text.Trim()); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarInformacionDropDowns()
        {
            LlenarDropDowns.InstrumentoMonetario(ddlInstumentoMonetario);
            LlenarDropDowns.TipoOperacion(ddlTipoOperacion);
            LlenarDropDowns.DescripcionOperacion(ddlDescripcionOperacion);
        }

        private void LimpiarCampos()
        {
            txtNumCliente.Text = String.Empty;
            txtCliente.Text = String.Empty;
            ddlNumControl.SelectedValue = "0";
            txtMonto.Text = String.Empty;
            ddlMoneda.SelectedValue = "0";
            ddlInstumentoMonetario.SelectedValue = "0";
            ddlTipoOperacion.SelectedValue = "0";
            ddlDescripcionOperacion.SelectedValue = "0";
            txtCausa.Text = String.Empty;
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
    }
}