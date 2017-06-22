using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reportes
{
    public partial class Default : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnDownloadFile);
            //scriptManager.RegisterPostBackControl(this.btnGetReport);
            scriptManager.RegisterPostBackControl(this.gvReport);

            if (!Page.IsPostBack) //first time
            {
                btnGetReport.Visible = false;
                btnDownloadFile.Visible = false;
                
            }
        }

        protected void reportsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String reportsValue = reportsType.SelectedItem.Value;
            String optionsCNBVValue = cnbvOptions.SelectedItem != null ? cnbvOptions.SelectedItem.Value : String.Empty;
            String optionsOtherValue = otherOptions.SelectedItem != null ? otherOptions.SelectedItem.Value : String.Empty;

            switch (reportsValue)
            {
                case "cnbv":
                    otherOptions.Visible = false;
                    cnbvOptions.Visible = true;
                    btnGetReport.Visible = optionsCNBVValue == String.Empty ? false : true;
                    pnlPLD.Visible = false;
                    pnlBuro.Visible = false;
                    pnlFechas.Visible = true;
                    break;

                case "pld":
                    cnbvOptions.Visible = false;
                    otherOptions.Visible = true;
                    btnGetReport.Visible = optionsOtherValue == String.Empty ? false : true;
                    pnlPLD.Visible = true;
                    pnlFechas.Visible = false;
                    pnlBuro.Visible = false;
                    break;

                case "buroDeCredito":
                    cnbvOptions.Visible = false;
                    otherOptions.Visible = true;
                    btnGetReport.Visible = optionsOtherValue == String.Empty ? false : true;
                    pnlPLD.Visible = false;
                    pnlFechas.Visible = false;
                    pnlBuro.Visible = true;
                    break;
            }
        }

        protected void cnbvOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cnbvOptions.SelectedItem.Value != null && cnbvOptions.SelectedItem.Value != String.Empty)
                {
                    btnGetReport.Visible = true;

                    if (otherOptions.SelectedItem != null && reportsType.SelectedItem.Value == "pld" && (otherOptions.SelectedItem.Value == "personaFisica" || otherOptions.SelectedItem.Value == "personaMoral")) //pld
                    {
                        pnlPLD.Visible = true;
                        pnlFechas.Visible = false;
                        pnlBuro.Visible = false;
                    }
                    else if(reportsType.SelectedItem.Value == "cnbv")
                    {
                        pnlPLD.Visible = false;
                        pnlBuro.Visible = false;
                        pnlFechas.Visible = true;
                    }
                    else
                    {
                        pnlPLD.Visible = false;
                        pnlBuro.Visible = true;
                        pnlFechas.Visible = false;
                    }
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void otherOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (otherOptions.SelectedItem.Value != null && otherOptions.SelectedItem.Value != String.Empty)
            {
                btnGetReport.Visible = true;
                
                if ((otherOptions.SelectedItem.Value == "personaFisica" || otherOptions.SelectedItem.Value == "personaMoral")  && reportsType.SelectedItem.Value == "pld")
                {
                    pnlPLD.Visible = true;
                    pnlFechas.Visible = false;
                }
                else if (reportsType.SelectedItem.Value == "cnbv")
                {
                    pnlPLD.Visible = false;
                    pnlBuro.Visible = false;
                    pnlFechas.Visible = true;
                }
                else
                {
                    pnlPLD.Visible = false;
                    pnlBuro.Visible = true;
                    pnlFechas.Visible = false;
                }
            }
        }

        protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvReport.PageIndex = e.NewPageIndex;
                BindData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPeriodo.Text != String.Empty)
                {
                    ReportsOperations.UpdatePeriod(DateTime.ParseExact(txtPeriodo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                BindData(); //bind data
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('A ocurrido un error favor de contactar al administrador');</script>" + ex);
            }
        }

        protected void btnDownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                String reportsValue = reportsType.SelectedItem.Value;
                String optionsCNBVValue = cnbvOptions.SelectedItem != null ? cnbvOptions.SelectedItem.Value : String.Empty;
                String optionsOtherValue = otherOptions.SelectedItem != null ? otherOptions.SelectedItem.Value : String.Empty;
                Report report;
                GetReport getData;
                report = GetObject(reportsValue, optionsCNBVValue, optionsOtherValue);
                getData = new GetReport(report);

                /*
                DateTime initialDate = txtDe != null && txtDe.Text != String.Empty ? DateTime.ParseExact(txtDe.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;
                DateTime finalDate = txtHasta != null && txtHasta.Text != String.Empty ? DateTime.ParseExact(txtHasta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;

                DataTable data = getData.GetData(initialDate, finalDate);
                */
                DataTable data = Session["gvData"] as DataTable;

                DataTable aux = data.Clone();// get the same structure
                foreach (DataColumn column in aux.Columns)
                {
                    if (column.DataType == typeof(String)) column.MaxLength = 1000;
                    column.AllowDBNull = true;
                    column.Unique = false;
                }

                //if (reportsValue == "cnbv" && cnbvOptions.SelectedItem.Value == "operacionesInusuales") //get only checkboxes checked
                //{
                //    for (int i = 0; i < gvReport.Rows.Count; i++)
                //    {
                //        CheckBox chk = (CheckBox)gvReport.Rows[i].FindControl("chkSelect");
                //        if (chk != null && chk.Checked)
                //        {
                //            aux.Rows.Add(data.Rows[i].ItemArray);
                //        }
                //    }

                //    String fileName = getData.GenerateFile(aux);
                //    DownloadFile(fileName);
                //}
                //else
                //{
                    Session["pldTipo"] = rblPLD.SelectedItem != null ? rblPLD.SelectedItem.Text : String.Empty;
                    Session["pld"] = reportsValue == "pld" && otherOptions.SelectedValue != null ? otherOptions.SelectedItem.Text : String.Empty;

                    if (reportsValue == "pld" && otherOptions.SelectedItem != null && (otherOptions.SelectedItem.Value == "personaFisica" || otherOptions.SelectedItem.Value == "personaMoral"))
                    {
                        String fileName = getData.GenerateFile(FilterPLD(data, rblPLD.SelectedItem.Value));
                        DownloadFile(fileName);
                    }
                    else
                    {
                        String fileName = getData.GenerateFile(data);
                        DownloadFile(fileName);
                    }
                    
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        private DataTable BindData()
        {
            try {
                Report report;
                GetReport getData;
                DataTable data = new DataTable();
                bool flagOperacionesInusuales = false;

                if (cnbvOptions.Visible)
                {
                    otherOptions.Visible = false;
                }
                else if (otherOptions.Visible)
                {
                    cnbvOptions.Visible = false;
                }
                String reportTypeValue = reportsType.SelectedValue;
                String cnbvOptionsValue = cnbvOptions.SelectedValue;
                String otherOptionsValue = otherOptions.SelectedValue;

                lblReport.Text = reportsType.SelectedItem.Text;

                //if (reportTypeValue == "cnbv")
                //{
                //    if (cnbvOptions.SelectedItem.Value == "operacionesInusuales") flagOperacionesInusuales = true;
                //}

                //lblReport.Text += " - " + cnbvOptions.SelectedItem.Text;

                //This code implements Strategy and factory Pattern
                report = GetObject(reportTypeValue, cnbvOptionsValue, otherOptionsValue);
                getData = new GetReport(report);

                DateTime initialDate = txtDe != null && txtDe.Text != String.Empty ? DateTime.ParseExact(txtDe.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;
                DateTime finalDate = txtHasta != null && txtHasta.Text != String.Empty ? DateTime.ParseExact(txtHasta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;

                data = getData.GetData(initialDate, finalDate);
                Session["gvData"] = data;

                //if (flagOperacionesInusuales)
                //{
                //    gvReport.Columns[0].Visible = true;
                //}
                //else
                //{
                //    gvReport.Columns[0].Visible = false;
                //}

                if (reportTypeValue == "pld" && (otherOptions.SelectedItem.Value == "personaFisica" || otherOptions.SelectedItem.Value == "personaMoral"))
                {
                    gvReport.DataSource = FilterPLD(data, rblPLD.SelectedItem.Value);
                }
                else
                {
                    gvReport.DataSource = data;
                }

                gvReport.DataBind();
                if (data.Rows.Count > 0)
                {
                    btnDownloadFile.Visible = true;
                }
                else
                {

                }

                return data;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        //"Factory" pattern
        private Report GetObject(String reportTypeValue, String cnbvOptionsValue, String otherOptionsValue)
        {
            if (reportTypeValue == "cnbv")
            {
                switch (cnbvOptionsValue)
                {
                    case "operacionesRelevantes":
                        return new CNBVRelavates();
                    case "operacionesInusuales":
                        return new CNBVInusuales();
                    case "operacionesInternasPreocupantes":
                        return new CNBVPreocupantes();
                    case "24horas":
                        return new _24horas();
                }
            }
            else
            {
                if (reportTypeValue == "pld")
                {
                    switch (otherOptionsValue)
                    {
                        case "personaFisica":
                            return new PLDFisica();
                        case "personaMoral":
                            return new PLDMoral();
                    }
                }
                else if (reportTypeValue == "buroDeCredito")
                {
                    switch (otherOptionsValue)
                    {
                        case "personaFisica":
                            return new BuroFisica();
                        case "personaMoral":
                            return new BuroMoral();
                    }
                }
            }

            return new CNBVRelavates();
        }

        private void DownloadFile(String fileName)
        {
            try
            {
                string filepath = Server.MapPath(FileSettings.filePath + fileName);

                //file information
                FileInfo file = new FileInfo(filepath);
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

        private DataTable FilterPLD(DataTable data, String value)
        {
            try
            {
                if(value == "Activos") //saldo > 0
                {
                    return (from row in data.AsEnumerable()
                           where Convert.ToDecimal(row["Saldo"]) > 0
                           select row).CopyToDataTable();

                } else if (value == "Inactivos") //saldo == 0
                {
                    return (from row in data.AsEnumerable()
                            where Convert.ToDecimal(row["Saldo"]) == 0
                            select row).CopyToDataTable();
                }
                else
                {
                    return data;
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if(reportsType.SelectedValue == "cnbv" && cnbvOptions.SelectedItem.Value == "operacionesInusuales")
            //{
            //    e.Row.Cells[0].Visible = true;
            //}
            
        }
    }
}