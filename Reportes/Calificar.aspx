<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calificar.aspx.cs" Inherits="Reportes.Calificar" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="Content\bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <style type="text/css">
        body {
            padding-top: 70px;
        }

        .black {
            font-weight: bold;
        }

        .labels label {
            font-size: 12px;
            text-align: right;
        }

        input[type="text"], input[type=password] {
            height: 25px;
            padding: 5px 10px;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
        }

        span, input[type="submit"], a, table {
            font-size: 12px;
        }

        /*
        input[type="text"] {
            width: 100%;
        }
        */

        /*
        .table tr td {
            width: 50%;
        }
        */

        .horizontal tr td {
            width: 8% !important;
            vertical-align: top;
        }

        /*
        .horizontal tr td label{
            display:block;
        }
            */

        .topAlign {
            vertical-align: top;
        }

        .row {
            margin-bottom: 10px !important;
        }

        .table .noBorder td {
            border: 0;
        }

        .error {
            color: red;
            font-weight: bold;
        }

        .successfully {
            color: forestgreen;
            font-weight: bold;
        }

        .center {
            width: 50%;
            margin: 0 auto;
        }

        .twoRows {
            width: 60%;
        }

        .oneRow {
            width: 40%;
        }

        span {
            font-weight: bold;
        }

        tr td span, tr td a {
            margin-right: 5px;
        }

        #filtros {
            /*background-color:darkgray;
                */
        }

        .rbl input[type="radio"] {
            margin-left: 3px;
            margin-right: 3px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#<%= txtDel.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });

            $("#<%= txtHasta.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });

            $("#<%= txtFechaAutorizacion.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });

            //enable or disable date fields
            $("#cbFechas").change(function () {
                if ($(this).is(':checked')) {
                    $("#txtDel").prop('disabled', false);
                    $("#txtHasta").prop('disabled', false);
                }
                else {
                    $("#txtDel").prop('disabled', true);
                    $("#txtHasta").prop('disabled', true);
                }
            });
        });

    </script>
    <title>Calificar</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnBuscarPorNombre">
            <asp:ScriptManager ID="scpManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <ul class="nav navbar-nav">
                        <li><a href="Default.aspx">Inicio</a></li>
                        <li class="active"><a href="Calificar.aspx">Verificación información</a></li>
                        <li><a href="Inusuales.aspx">Inusuales/24 horas</a></li>
                        <li><a href="InternasPreocupantes.aspx">Internas Preocupantes</a></li>
                        <li><a href="Criterios.aspx">Criterios</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li style="margin-right: 10px;"><a href="Logout.aspx">Cerrar sesión</a></li>
                    </ul>
                </div>
            </div>
            <div class="container">
                <div class="span12">
                    <div class="text-center">
                        <img src="Images/credijalrecor.PNG" style="width: 261px; height: 50px" />
                    </div>
                </div>
                <div class="text-center">
                    <asp:UpdatePanel ID="upOptions" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnActualizar" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar información" CssClass="btn btn-primary pull-right" OnClick="btnActualizar_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h4 class="black">Verificación de información de prevención de lavado de dinero</h4>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
                </div>
                <div id="filtros">
                    <h5 class="black text-left">Filtrar información</h5>
                    <div class="row">
                        <div class="col-sm-12">
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-2" style="vertical-align: text-top;">
                                        <asp:CheckBox ID="cbFechas" runat="server" Text="Rango fechas" />
                                    </td>
                                    <td class="col-sm-1 text-right">
                                        <asp:Label ID="lblDel" Text="Del:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-2 text-left">
                                        <asp:TextBox ID="txtDel" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td class="col-sm-1 text-right">
                                        <asp:Label ID="lblHasta" Text="Hasta:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-2 text-left">
                                        <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td class="col-sm-1 text-right">
                                        <asp:Label ID="lblDdlTipoReporte" Text="Tipo reporte:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-3 text-left">
                                        <asp:DropDownList ID="ddlTipoReporte" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="--Selecciona tipo de reporte--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Relevantes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Inusuales" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Preocupantes" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="24 horas" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Registros sin reportar" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Registros reportados" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Registros no reportados" Value="7"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- end filtros div -->
                <asp:UpdateProgress ID="UpdPro" runat="server" AssociatedUpdatePanelID="upOptions">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; opacity: 1.7;">
                            <table class="auto-style2">
                                <tr>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td class="auto-style6"></td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <asp:Image ID="imgProceso" runat="server" ImageUrl="~/Images/Progreso.gif" Style="padding: 10px; position: fixed; top: 21%; left: 40%; height: 146px; width: 168px;" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Panel ID="pnlFiltro" runat="server" Visible="false">
                    <div class="row">
                        <div class="col-sm-7">
                            <table class="table-hover" style="margin-bottom: 0px;">
                                <tr>
                                    <td class="col-sm-4 text-right">
                                        <asp:Label ID="lblFiltroNombre" Text="Filtrar por nombre:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-5 text-left">
                                        <asp:TextBox ID="txtFiltroNombre" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="col-sm-1 text-left">
                                        <asp:ImageButton ID="btnBuscarPorNombre" ImageUrl="~/Images/search.png" runat="server" OnClick="btnBuscarPorNombre_Click" Height="60%" />
                                    </td>
                                    <td class="col-sm-2 text-right">
                                        <asp:Label ID="lblTotalRegistros" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-sm-5">
                            <div class="text-center">
                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary top-buffer" Text="Exportar a excel" OnClick="btnExportToExcel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div style="overflow-x: auto; width: 100%">
                                <asp:GridView ID="gvInformation" runat="server" ViewStateMode="Enabled" AllowPaging="true" PageSize="5" CssClass="table table-hover table-striped" GridLines="None" OnPageIndexChanging="gvInformation_PageIndexChanging" OnRowDataBound="gvInformation_RowDataBound" OnSelectedIndexChanged="gvInformation_SelectedIndexChanged" OnRowCreated="gvInformation_RowCreated">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div id="detalleInfo">
                    <!--
                <h5 class="black text-left">Detalle de la información</h5>
                <div class="row">
                    <div class="col-sm-12">
                        <table class="table table-hover">
                            <tr>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblTipoReporte" runat="server" Text="Tipo de reporte:"></asp:Label>
                                </td>
                                <td class="col-sm-3 text-left">
                                    <asp:TextBox ID="txtTipoReporte" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblFechaOperacion" runat="server" Text="Fecha de operación:"></asp:Label>
                                </td>
                                <td class="col-sm-3 text-left">
                                    <asp:TextBox ID="txtFechaOperacion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblPeriodoDetectado" runat="server" Text="Periodo detectado:"></asp:Label>
                                </td>
                                <td class="col-sm-3 text-left">
                                    <asp:TextBox ID="txtPeriodoDetectado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-hover">
                            <tr>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                </td>
                                <td class="col-sm-5 text-left">
                                    <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="lblNumControl" runat="server" Text="No control:"></asp:Label>
                                </td>
                                <td class="col-sm-4 text-left">
                                    <asp:TextBox ID="txtNumControl" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-hover">
                            <tr>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblTipoOperacion" runat="server" Text="Tipo de operación:"></asp:Label>
                                </td>
                                <td class="col-sm-5 text-left">
                                    <asp:TextBox ID="txtTipoOperacion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:"></asp:Label>
                                </td>
                                <td class="col-sm-2 text-left">
                                    <asp:TextBox ID="txtLocalidad" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblSucursal" runat="server" Text="Sucursal:"></asp:Label>
                                </td>
                                <td class="col-sm-2 text-left">
                                    <asp:TextBox ID="txtSucursal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-hover">
                            <tr>
                                <td class="col-sm-6">&nbsp;
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblMonto" runat="server" Text="Monto:"></asp:Label>
                                </td>
                                <td class="col-sm-2 text-left">
                                    <asp:TextBox ID="txtMonto" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-sm-1 text-right">
                                    <asp:Label ID="lblMoneda" runat="server" Text="Moneda:"></asp:Label>
                                </td>
                                <td class="col-sm-2 text-left">
                                    <asp:TextBox ID="txtMoneda" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                -->
                    <div class="row">
                        <div class="col-sm-12">
                            <h4><strong>Calificar</strong></h4>
                            <div class="text-center">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" Visible="false" CssClass="btn btn-primary top-buffer" OnClick="btnEditar_Click" Style="margin-top: -30px;" />
                            </div>
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblReportar" Text="Reportar" runat="server"></asp:Label>
                                        <asp:RadioButtonList ID="rblReportar" runat="server" RepeatDirection="Horizontal" CssClass="rbl" Enabled="false">
                                            <asp:ListItem Text="SI" Value="SI" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="NO"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblAutorizadoPor" Text="Autorizado por:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-4">
                                        <asp:DropDownList ID="ddlAutorizadoPor" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvAutorizadoPor" runat="server" ControlToValidate="ddlAutorizadoPor" InitialValue="0" Text="Selecciona persona" ValidationGroup="Guardar" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="col-sm-1">
                                        <asp:Label ID="lblFechaAutorizacion" Text="Fecha de autorización" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-3">
                                        <asp:TextBox ID="txtFechaAutorizacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-2">&nbsp;
                                    </td>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblMotivoNoReportar" Text="Motivo para no reportar:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-8">
                                        <asp:DropDownList ID="ddlMotivoNoReportar" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvMotivoNoReportar" runat="server" ControlToValidate="ddlMotivoNoReportar" InitialValue="0" Text="Selecciona motivo" ValidationGroup="Guardar" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-2">&nbsp;
                                    </td>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblCriterioPLD" Text="Criterio PLD:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-8">
                                        <asp:TextBox ID="txtCriterioPLD" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div class="text-center">
                                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-primary top-buffer" ValidationGroup="Guardar" Visible="false" />
                            </div>
                            <asp:Panel ID="pnlPerfilTransac" runat="server" Enabled="false">
                                <h4><strong>Perfil transaccional </strong></h4>
                                <table class="table table-hover">
                                    <tr>
                                        <td class="col-sm-2">
                                            <asp:Label ID="lblActividadPrep" Text="Actividad preponderante:" runat="server"></asp:Label>
                                        </td>
                                        <td class="col-sm-6">
                                            <asp:TextBox ID="txtActividadPrep" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:Label ID="lblManejoEfectivo" Text="Manejo efectivo:" runat="server"></asp:Label>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:TextBox ID="txtManejoEfectivo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-hover">
                                    <tr>
                                        <td class="col-sm-2">
                                            <asp:Label ID="lblMontoEfectivoMensual" Text="Monto efectivo mensual:" runat="server"></asp:Label>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:TextBox ID="txtMontoEfectivoMensual" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:Label ID="lblNumEstimadoMovMensual" Text="Número estimado de movimientos mensuales:" runat="server"></asp:Label>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:TextBox ID="txtNumEstimadoMovMensual" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:Label ID="lblMontoEstimadoMensual" Text="Monto estimado de movimientos mensuales:" runat="server"></asp:Label>
                                        </td>
                                        <td class="col-sm-2">
                                            <asp:TextBox ID="txtMontoEstimadoMensual" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end container div -->
        </asp:Panel>
    </form>
</body>
</html>
