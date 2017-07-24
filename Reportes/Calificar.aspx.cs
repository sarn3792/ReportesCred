using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Calificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                InitialSettings();
                EnableDisableDate(false);
            }
            else
            {
                EditFields(false);
                ClearData();
                if (txtDel.Text != String.Empty && txtHasta.Text != String.Empty)
                {
                    cbFechas.Checked = true;
                }
            }
        }
        public void InitialSettings()
        {
            LlenarDropDowns.AutorizadoPor(ddlAutorizadoPor);
            LlenarDropDowns.MotivoNoReportar(ddlMotivoNoReportar);
        }

        public void ClearData()
        {
            lblMensaje.Visible = false;
            //cbFechas.Checked = false;
            //btnEditar.Visible = false;
        }

        public void EnableDisableDate(bool flag)
        {
            this.txtDel.Enabled = flag;
            this.txtHasta.Enabled = flag;

        }
        private void ShowMessage(bool error)
        {
            if (!error)
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

        private void ShowMessage(bool error, String text)
        {
            if (!error)
            {
                lblMensaje.Text = text;
                lblMensaje.CssClass = "successfully";
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Text = text;
                lblMensaje.CssClass = "error";
                lblMensaje.Visible = true;
            }
        }

        private void BindData()
        {
            try
            {
                if (this.ddlTipoReporte.SelectedItem.Value != "0")
                {

                    if (cbFechas.Checked)
                    {
                        if (txtDel.Text != String.Empty && txtHasta.Text != String.Empty) //Bind gridview between dates
                        {
                            DateTime initialDate = DateTime.ParseExact(txtDel.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime finalDate = DateTime.ParseExact(txtHasta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            String query = ReportsOperations.GetQueryReports(ddlTipoReporte.SelectedItem.Value, initialDate, finalDate);
                            if(txtFiltroNombre.Text.Trim() != String.Empty)
                            {
                                String finalQuery = String.Format("AND RazonSocial LIKE '%{0}%'", txtFiltroNombre.Text.Trim());
                                query = String.Format("{0} {1}", query, finalQuery); //concat like condition to where clause
                            }

                            DataTable aux = new DataTable();
                            DataBaseSettings db = new DataBaseSettings();
                            aux = db.GetDataTable(query);
                            gvInformation.DataSource = aux;
                            gvInformation.DataBind();
                            if (aux.Rows.Count > 0)
                            {
                                pnlFiltro.Visible = true;
                            }
                            else
                            {
                                txtFiltroNombre.Text = String.Empty;
                                pnlFiltro.Visible = false;
                                ShowMessage(true, "No fueron encontrados registros con dichos criterios de búsqueda");
                            }
                            
                        }
                        else
                        {
                            ShowMessage(true, "Favor de ingresar ambas fechas");
                        }
                    }
                    else //Bind gridview without dates
                    {
                        String query = ReportsOperations.GetQueryReports(ddlTipoReporte.SelectedItem.Value);
                        if (txtFiltroNombre.Text.Trim() != String.Empty)
                        {
                            String finalQuery = String.Format("AND RazonSocial LIKE '%{0}%'", txtFiltroNombre.Text.Trim());
                            query = String.Format("{0} {1}", query, finalQuery); //concat like condition to where clause
                        }

                        DataTable aux = new DataTable();
                        DataBaseSettings db = new DataBaseSettings();
                        aux = db.GetDataTable(query);
                        gvInformation.DataSource = aux;
                        gvInformation.DataBind();
                        if (aux.Rows.Count > 0)
                        {
                            pnlFiltro.Visible = true;
                        }
                        else
                        {
                            txtFiltroNombre.Text = String.Empty;
                            pnlFiltro.Visible = false;
                            ShowMessage(true, "No fueron encontrados registros con dichos criterios de búsqueda");
                        }
                    }
                    cbFechas.Checked = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltroNombre.Text = String.Empty;
                BindData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvInformation.PageIndex = e.NewPageIndex;
                BindData();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInformation.SelectedRow != null)
                {
                    EditFields(true);
                    //txtFechaAutorizacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    rblReportar.SelectedValue = "NO";
                    rblReportar.Enabled = false;

                    //String ID = gvInformation.SelectedRow.Cells[0].Text;
                    //txtCriterioPLD.Text = ReportsOperations.GetDescripcionOperacion(ID);
                }
                else
                {
                    ShowMessage(true, "Favor de seleccionar un registro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EditFields(bool flag)
        {
            rblReportar.Enabled = flag;
            txtFechaAutorizacion.Enabled = flag;
            ddlAutorizadoPor.Enabled = flag;
            ddlMotivoNoReportar.Enabled = flag;
            //txtCriterioPLD.Enabled = flag;
            btnGuardar.Visible = flag;
            //ddlAutorizadoPor.SelectedValue = "0";
            //ddlMotivoNoReportar.SelectedValue = "0";
            //txtCriterioPLD.Text = String.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInformation.SelectedRow != null)
                {
                    ReportsOperations.UpdateRegistro(gvInformation.SelectedRow.Cells[0].Text, ddlAutorizadoPor.SelectedItem.Text, ddlMotivoNoReportar.SelectedItem.Text, DateTime.ParseExact(txtFechaAutorizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    ShowMessage(false);
                    ddlAutorizadoPor.SelectedValue = "0";
                    ddlMotivoNoReportar.SelectedValue = "0";
                    txtCriterioPLD.Text = String.Empty;
                    btnEditar.Visible = false;

                    BindData();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(true);
                throw ex;
            }
        }

        protected void gvInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvInformation, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            txtCriterioPLD.Text = String.Empty; 
            txtFechaAutorizacion.Text = String.Empty;
            ddlAutorizadoPor.SelectedValue = "0";
            ddlMotivoNoReportar.SelectedValue = "0";

            foreach (GridViewRow row in gvInformation.Rows)
            {
                if (row.RowIndex == gvInformation.SelectedIndex) //when row is selected
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = String.Empty;
                    //fill values when row is clicked
                    txtFechaAutorizacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    String ID = gvInformation.SelectedRow.Cells[0].Text;
                    txtCriterioPLD.Text = ReportsOperations.GetDescripcionOperacion(ID);

                    if (row.Cells[6].Text != "NO") 
                    { //inusuales y no reportados no se pueden modificar
                        if (ddlTipoReporte.SelectedItem.Value != "1" && ddlTipoReporte.SelectedItem.Value != "7")
                        {
                            btnEditar.Visible = true;
                        }
                    }
                    else
                    {
                        ReportsOperations.InformationOperacion data = ReportsOperations.GetInformationOperacion(ID);
                        ddlAutorizadoPor.SelectedIndex = ddlAutorizadoPor.Items.IndexOf(ddlAutorizadoPor.Items.FindByText(data.autorizadoPor));
                        txtFechaAutorizacion.Text = data.fechaAutorizacion;
                        ddlMotivoNoReportar.SelectedIndex = ddlMotivoNoReportar.Items.IndexOf(ddlMotivoNoReportar.Items.FindByText(data.motivoParaNoReportar));
                    }

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }

        }

        private void ClearAllPage()
        {
            cbFechas.Checked = false;
            txtDel.Text = String.Empty;
            txtDel.Enabled = false;
            txtHasta.Text = String.Empty;
            ddlTipoReporte.SelectedValue = "0";
            gvInformation.DataSource = null;
            gvInformation.DataBind();
            btnEditar.Visible = false;
            EditFields(false);
            ddlAutorizadoPor.SelectedValue = "0";
            ddlMotivoNoReportar.SelectedValue = "0";
            txtCriterioPLD.Text = String.Empty;
        }
    
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery("EXEC xInserta_Sofomes");
                //ShowMessage(false, "Información actualizada correctamente");
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvInformation_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[0].Visible = false; // hides the first column
        }

        protected void btnBuscarPorNombre_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlTipoReporte.SelectedItem.Value != "0")
                {

                    if (cbFechas.Checked)
                    {
                        if (txtDel.Text != String.Empty && txtHasta.Text != String.Empty) //Bind gridview between dates
                        {
                            DateTime initialDate = DateTime.ParseExact(txtDel.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime finalDate = DateTime.ParseExact(txtHasta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            String query = ReportsOperations.GetQueryToExport(ddlTipoReporte.SelectedItem.Value, initialDate, finalDate);
                            if (txtFiltroNombre.Text.Trim() != String.Empty)
                            {
                                String finalQuery = String.Format("AND RazonSocial LIKE '%{0}%'", txtFiltroNombre.Text.Trim());
                                query = String.Format("{0} {1}", query, finalQuery); //concat like condition to where clause
                            }

                            DataTable aux = new DataTable();
                            DataBaseSettings db = new DataBaseSettings();
                            aux = db.GetDataTable(query);
                            string fileName = FileSettings.CreateCSVFile(aux, ddlTipoReporte.SelectedItem.Text + " " + DateTime.Now.ToString("yyyy-MM-dd"));
                            this.DownloadFile(fileName);
                        }
                        else
                        {
                            ShowMessage(true, "Favor de ingresar ambas fechas");
                        }
                    }
                    else //Bind gridview without dates
                    {
                        String query = ReportsOperations.GetQueryToExport(ddlTipoReporte.SelectedItem.Value);
                        if (txtFiltroNombre.Text.Trim() != String.Empty)
                        {
                            String finalQuery = String.Format("AND RazonSocial LIKE '%{0}%'", txtFiltroNombre.Text.Trim());
                            query = String.Format("{0} {1}", query, finalQuery); //concat like condition to where clause
                        }

                        DataTable aux = new DataTable();
                        DataBaseSettings db = new DataBaseSettings();
                        aux = db.GetDataTable(query);
                        string fileName = FileSettings.CreateCSVFile(aux, ddlTipoReporte.SelectedItem.Text + " " + DateTime.Now.ToString("yyyy-MM-dd"));
                        this.DownloadFile(fileName);
                    }
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DownloadFile(String fileName)
        {
            try
            {
                //file information
                FileInfo file = new FileInfo(fileName);
                if (file.Exists)
                {
                    Response.ClearContent();

                    //Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                    // Add the file size into the response header
                    Response.AddHeader("Content-Length", file.Length.ToString());

                    // Set the ContentType
                    Response.ContentType = FileSettings.ReturnExtension(file.Extension.ToLower());

                    // Write the file into the response
                    Response.TransmitFile(file.FullName);

                    // End the response
                    //Response.End();
                    Response.Flush(); // Sends all currently buffered output to the client.
                    Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}