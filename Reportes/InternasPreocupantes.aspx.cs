using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class InternasPreocupantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                divLogout.Visible = true;
            }
            else
            {
                divLogout.Visible = false;
            }
        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            try
            {
                CNBVPreocupantesBean preo = ReportsOperations.Get();
                preo.Nombre = txtNombre.Text.Trim();
                preo.ApellidoPaterno = txtApellidoPaterno.Text.Trim();
                preo.ApellidoMaterno = txtApellidoMaterno.Text.Trim();
                preo.RazonSocial = String.Format("{0} {1} {2}", preo.ApellidoPaterno, preo.ApellidoMaterno, preo.Nombre);
                preo.Domicilio = txtDomicilio.Text.Trim();
                preo.Ciudad = txtCiudad.Text.Trim();
                preo.Colonia = txtColonia.Text.Trim();
                preo.Telefono = txtTelefono.Text.Trim();
                DateTime fechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                preo.FechaNacimiento = fechaNacimiento.ToString("yyyyMMdd");
                preo.Nacionalidad = ddlNacionalidad.SelectedItem.Value;
                preo.RFC = txtRfc.Text.Trim();
                preo.CURP = txtCurp.Text.Trim();
                preo.TipoPersona = "1";
                //preo.Localidad = ddlLocalidad.SelectedItem.Text;
                //preo.OrganoSupervisor = ddlSucursal.SelectedItem.Text;
                preo.Razones = txtCausa.Text.Trim();
                ReportsOperations.Save(preo);
                LimpiarCampos();
                MostarMensaje(true);
            }
            catch (Exception ex)
            {
                MostarMensaje(false);
                throw ex;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = String.Empty;
            txtApellidoPaterno.Text = String.Empty;
            txtApellidoMaterno.Text = String.Empty;
            txtDomicilio.Text = String.Empty;
            txtCiudad.Text = String.Empty;
            txtColonia.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtFechaNacimiento.Text = String.Empty;
            ddlNacionalidad.SelectedValue = "0";
            txtRfc.Text = String.Empty;
            txtCurp.Text = String.Empty;
            ddlLocalidad.SelectedValue = "0";
            ddlSucursal.SelectedValue = "0";
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