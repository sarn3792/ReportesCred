<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternasPreocupantes.aspx.cs" Inherits="Reportes.InternasPreocupantes" %>

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
                    <li><a href="Inusuales.aspx">Inusuales/24 horas</a></li>
                    <li class="active"><a href="InternasPreocupantes.aspx">Internas Preocupantes</a></li>
                    <li><a href="Criterios.aspx">Criterios</a></li>
                </ul>
                <asp:Panel ID="divLogout" runat="server" Visible="false">
                    <ul class="nav navbar-nav navbar-right">
                        <li style="margin-right: 10px;"><a href="Logout.aspx">Cerrar sesión</a></li>
                    </ul>
                </asp:Panel>
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
                <h3 class="black">Operaciones internas preocupantes</h3>
                <br />
                <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblApellidoPaterno" Text="Apellido paterno" runat="server"></asp:Label>
                        </td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvApellidoPaterno" ControlToValidate="txtApellidoPaterno" runat="server" ValidationGroup="gpFinal" Text="Ingrese apellido paterno" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblApellidoMaterno" Text="Apellido materno" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvApellidoMaterno" ControlToValidate="txtApellidoMaterno" runat="server" ValidationGroup="gpFinal" Text="Ingrese apellido materno" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblNombre" Text="Nombre(s)" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="oneRow"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvNombre" ControlToValidate="txtNombre" runat="server" ValidationGroup="gpFinal" Text="Ingrese nombre(s)" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblDomicilio" Text="Domicilio" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="oneRow"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvDomicilio" ControlToValidate="txtDomicilio" runat="server" ValidationGroup="gpFinal" Text="Ingrese domicilio" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblCiudad" Text="Ciudad o población" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvCiudad" ControlToValidate="txtCiudad" runat="server" ValidationGroup="gpFinal" Text="Ingrese ciudad" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblColonia" Text="Colonia" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtColonia" runat="server" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvColonia" ControlToValidate="txtColonia" runat="server" ValidationGroup="gpFinal" Text="Ingrese colonia" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblTelefono" Text="Teléfono" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:TextBox ID="txtTelefono" runat="server" Width="23.5%"></asp:TextBox></td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblFechaNacimiento" Text="Fecha de nacimiento" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" placeholder="dd/mm/aaaa" CssClass="twoRows"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvFechaNacimiento" ControlToValidate="txtFechaNacimiento" runat="server" ValidationGroup="gpFinal" Text="Ingrese fecha de nacimiento" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFechaNacimiento" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Formato inválido (dd/mm/aaaa)" ForeColor="Red" ValidationGroup="gpFinal" />
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblNacionalidad" Text="Nacionalidad" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="form-control input-sm twoRows">
                                <asp:ListItem Text="--Seleccionar nacionalidad--" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Mexicana" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Extranjera" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTitTipoDomicilio" runat="server" ControlToValidate="ddlNacionalidad" InitialValue="0" Text="Selecciona nacionalidad" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblRfc" Text="RFC" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtRfc" runat="server" CssClass="twoRows"></asp:TextBox></td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblCurp" Text="CURP" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:TextBox ID="txtCurp" runat="server" CssClass="twoRows"></asp:TextBox></td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblLocalidad" Text="Localidad" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control input-sm twoRows">
                                <asp:ListItem Text="--Seleccionar localidad--" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="01539009" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" InitialValue="0" Text="Selecciona localidad" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblSucursal" Text="Sucursal" runat="server"></asp:Label></td>
                        <td class="col-sm-4 text-left">
                            <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm twoRows">
                                <asp:ListItem Text="--Seleccionar sucursal--" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="00001" Value="1"></asp:ListItem>
                                <asp:ListItem Text="0001" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlSucursal" InitialValue="0" Text="Selecciona sucursal" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="table table-hover">
                    <tr>
                        <td class="col-sm-2 text-right">
                            <asp:Label ID="lblCausa" Text="Causa por la que se reporta como operación preocupante" runat="server"></asp:Label></td>
                        <td class="col-sm-10 text-left">
                            <asp:TextBox ID="txtCausa" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvCausa" ControlToValidate="txtCausa" runat="server" ValidationGroup="gpFinal" Text="Ingrese causa" ForeColor="Red">
                            </asp:RequiredFieldValidator>
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
