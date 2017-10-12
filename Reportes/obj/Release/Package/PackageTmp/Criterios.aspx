<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Criterios.aspx.cs" Inherits="Reportes.Criterios" EnableEventValidation="false" %>

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

        #buttons input[type="submit"] {
            margin-right: 3%;
        }
    </style>

    <title>Internas Preocupantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnBuscarCriterio">
            <asp:ScriptManager ID="scpManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <ul class="nav navbar-nav">
                        <li><a href="Default.aspx">Inicio</a></li>
                        <li><a href="Calificar.aspx">Verificación información</a></li>
                        <li><a href="Inusuales.aspx">Inusuales/24 horas</a></li>
                        <li><a href="InternasPreocupantes.aspx">Internas Preocupantes</a></li>
                        <li class="active"><a href="Criterios.aspx">Criterios</a></li>
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
                    <h3 class="black">Criterios</h3>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div id="buttons">
                            <asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-primary top-buffer" OnClick="btnAgregar_Click" />
                            <asp:Button ID="btnEditar" Text="Editar" runat="server" CssClass="btn btn-primary top-buffer" OnClick="btnEditar_Click" />
                            <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-primary top-buffer" OnClick="btnEliminar_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="text-center">
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-5 text-right">
                                        <asp:Label ID="lblBuscarCriterio" Text="Criterio:" runat="server"></asp:Label>
                                    </td>
                                    <td class="col-sm-4 text-left">
                                        <asp:TextBox ID="txtBuscarCriterio" runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="col-sm-3 text-left">
                                        <asp:ImageButton ID="btnBuscarCriterio" ImageUrl="~/Images/search.png" runat="server" Height="60%" OnClick="btnBuscarCriterio_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div style="overflow-x: auto; width: 100%">
                            <asp:GridView ID="gvCriterios" runat="server" ViewStateMode="Enabled" AllowPaging="true" PageSize="8" CssClass="table table-hover table-striped" GridLines="None" OnPageIndexChanging="gvCriterios_PageIndexChanging" OnRowDataBound="gvCriterios_RowDataBound" OnSelectedIndexChanged="gvCriterios_SelectedIndexChanged" OnRowCreated="gvCriterios_RowCreated">
                            </asp:GridView>
                        </div>
                        <br />
                        <div class="text-center">
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-5 text-right">
                                        <asp:Label ID="lblCriterio" Text="Criterio" runat="server"></asp:Label></td>
                                    <td class="col-sm-7 text-left">
                                        <asp:TextBox ID="txtCriterio" runat="server" Width="55%"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvCriterio" runat="server" ControlToValidate="txtCriterio" Text="Ingresa criterio" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <table class="table table-hover">
                                <tr>
                                    <td class="col-sm-5 text-right">
                                        <asp:Label ID="lblTipoOpcion" Text="Tipo opción" runat="server"></asp:Label></td>
                                    <td class="col-sm-7 text-left">
                                        <div style="margin-left: 0%;">
                                            <asp:RadioButtonList ID="rblTipoOpcion" runat="server" CssClass="twoRows">
                                                <asp:ListItem Text="Criterio PLD" Value="OpCrit" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Motivo para no reportar" Value="NoRept"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--<div class="text-center">
                            <asp:Button ID="btnGuardar" ValidationGroup="gpFinal" CssClass="btn btn-primary top-buffer" Text="Guardar" runat="server" OnClick="btnGuardar_Click" />
                        </div>--%>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
