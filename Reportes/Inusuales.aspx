<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inusuales.aspx.cs" Inherits="Reportes.Inusuales" %>

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
    </style>

    <title>Internas Preocupantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scpManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <ul class="nav navbar-nav">
                    <li><a href="Default.aspx">Inicio</a></li>
                    <li><a href="Calificar.aspx">Verificación información</a></li>
                    <li class="active"><a href="Inusuales.aspx">Inusuales/24 horas</a></li>
                    <li><a href="InternasPreocupantes.aspx">Internas Preocupantes</a></li>
                    <li><a href="Criterios.aspx">Criterios</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li style="margin-right: 10px;"><a href="Logout.aspx">Cerrar sesión</a></li>
                </ul>
            </div>
        </div>
        <div class="container">
            <div class="row-fluid">
                <div class="span12">
                    <div class="text-center">
                        <img src="Images/credijalrecor.PNG" style="width: 261px; height: 50px" />
                    </div>
                </div>
            </div>
            <div class="text-center">
                <h3 class="black">Operaciones inusuales</h3>
                <br />
                <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblNumCliente" Text="Número cliente" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtNumCliente" runat="server" Width="35%"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvNumCliente" ControlToValidate="txtNumCliente" runat="server" ValidationGroup="gpNumCliente" Text="Ingrese número cliente" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            &nbsp; 
                            <asp:RequiredFieldValidator ID="rfvNumCliente2" ControlToValidate="txtNumCliente" runat="server" ValidationGroup="gpFinal" Text="Ingrese número cliente" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <div class="text-center" style="width: 35%">
                                <asp:ImageButton ID="btnBuscarCliente" runat="server" OnClick="btnBuscarCliente_Click" Width="20px" Height="20px" ImageUrl="~/Images/search.png" ValidationGroup="gpNumCliente" />
                            </div>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblCliente" Text="Cliente" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtCliente" runat="server" Width="80%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblNumControl" Text="Número de control" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:DropDownList ID="ddlNumControl" runat="server" CssClass="form-control input-sm oneRow">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvNumControl" runat="server" ControlToValidate="ddlNumControl" InitialValue="0" Text="Selecciona número de control" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblMonto" Text="Monto" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtMonto" runat="server" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvMonto" ControlToValidate="txtMonto" runat="server" ValidationGroup="gpFinal" Text="Ingrese monto" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="revMonto" ControlToValidate="txtMonto" runat="server" ErrorMessage="Sólo números" ForeColor="Red" ValidationExpression="((\d+)((\.\d{1,2})?))$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblMoneda" Text="Moneda" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control input-sm twoRows">
                                <asp:ListItem Text="--Seleccionar moneda--" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Pesos" Value="MXN"></asp:ListItem>
                                <asp:ListItem Text="Dólares" Value="DLL"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMoneda" runat="server" ControlToValidate="ddlMoneda" InitialValue="0" Text="Selecciona moneda" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblInstrumentoMonetario" Text="Instrumento monetario" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:DropDownList ID="ddlInstumentoMonetario" runat="server" CssClass="form-control input-sm twoRows">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvInstrumentoMonetario" ControlToValidate="ddlInstumentoMonetario" InitialValue="0" runat="server" ValidationGroup="gpFinal" Text="Seleccione instrumento monetario" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblTipoReporte" Text="Tipo de reporte" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <div style="margin-left: 10%;">
                                <asp:RadioButtonList ID="rblTipoReporte" runat="server" CssClass="twoRows">
                                    <asp:ListItem Text="Inusual" Value="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="24 Horas" Value="4"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblTipoOperacion" Text="Tipo de operación" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:DropDownList ID="ddlTipoOperacion" runat="server" CssClass="form-control input-sm oneRow">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoOperacion" runat="server" ControlToValidate="ddlTipoOperacion" InitialValue="0" Text="Selecciona tipo de operación" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblDescripcionOperacion" Text="Descripción de la operación" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:DropDownList ID="ddlDescripcionOperacion" runat="server" CssClass="form-control input-sm oneRow">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDescripcionOperacion" runat="server" ControlToValidate="ddlDescripcionOperacion" InitialValue="0" Text="Selecciona descripción de la operación" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblCausa" Text="Causa por la que se reporte como operación inusual" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:TextBox ID="txtCausa" runat="server" Width="80%" Height="50px">
                            </asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvCausa" runat="server" ControlToValidate="txtCausa" Text="Ingrese causa de la operación" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div class="text-center">
                    <asp:Button ID="btnReportar" ValidationGroup="gpFinal" CssClass="btn btn-primary top-buffer" Text="Reportar" runat="server" OnClick="btnReportar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
