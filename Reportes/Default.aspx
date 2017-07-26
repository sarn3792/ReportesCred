<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Reportes.Default" MaintainScrollPositionOnPostback="true"%>

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

        .button {
            border-radius: 8px;
            height: 40px;
        }

        labels label {
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

        .gvwCasesPager a, .gvwCasesPager span {
            margin-left: 10px;
            margin-right: 10px;
        }

        .modal {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }

        .bold {
            font-weight: bold;
        }
    </style>
    <script>
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $('.classTarget').datepicker({ dateFormat: 'dd/mm/yy' });
            }


            <%--$("#<%= txtDe.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });


            $("#<%= txtHasta.ClientID %>").datepicker({
                dateFormat: "dd/mm/yy"
            });--%>
        });
    </script>
    <title>Reportes</title>
</head>
<body>
    <form id="myForm" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Inicio</a></li>
                    <li><a href="Calificar.aspx">Verificación información</a></li>
                    <li><a href="Inusuales.aspx">Inusuales/24 horas</a></li>
                    <li><a href="InternasPreocupantes.aspx">Internas Preocupantes</a></li>
                    <li><a href="Criterios.aspx">Criterios</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li style="margin-right: 10px;"><a href="Logout.aspx">Cerrar sesión</a></li>
                </ul>
            </div>
        </div>
        <asp:ScriptManager ID="scpBtn" runat="server" EnablePartialRendering="true" AsyncPostBackTimeout="0"></asp:ScriptManager>
        <div class="container">
            <div class="row-fluid">
                <div class="span12">
                    <div class="well visible-desktop">
                        <!--
                        <h1 class="text-center">Reportes CREDIJAL</h1>
                        -->
                        <div class="text-center">
                            <img src="Images/credijalrecor.PNG" style="width: 261px; height: 59px" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <h4><b>Selecciona el tipo de reporte y rango de fechas</b></h4>
                </div>
            </div>
            <asp:UpdateProgress ID="updateProgress" runat="server" DisplayAfter="1" DynamicLayout="true" AssociatedUpdatePanelID="upOptions">
                <ProgressTemplate>
                    <div class="modal">
                        <p>Loading</p>
                        <div class="center">
                            <p>Loading</p>
                            <!--
                            <img id="imgLoading" runat="server" alt="" src="Images/loader.gif" />
                            -->
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="upOptions" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGetReport" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:RadioButtonList ID="reportsType" runat="server" OnSelectedIndexChanged="reportsType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="CNBV" ID="cnbv" Value="cnbv" />
                                <asp:ListItem Text="PLD" ID="pld" Value="pld" />
                                <asp:ListItem Text="Buró de crédito" ID="buroDeCredito" Value="buroDeCredito" />
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-sm-6">
                            <asp:RadioButtonList ID="cnbvOptions" runat="server" OnSelectedIndexChanged="cnbvOptions_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Operaciones relevantes" Value="operacionesRelevantes" />
                                <asp:ListItem Text="Operaciones inusuales" Value="operacionesInusuales" />
                                <asp:ListItem Text="Operaciones internas preocupantes" Value="operacionesInternasPreocupantes" />
                                <asp:ListItem Text="24 horas" Value="24horas"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RadioButtonList ID="otherOptions" runat="server" OnSelectedIndexChanged="otherOptions_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Persona física" Value="personaFisica" />
                                <asp:ListItem Text="Persona moral" Value="personaMoral" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="pnlFechas" runat="server" Visible="false">
                                <table class="table">
                                    <tr>
                                        <td class="col-sm-2 text-right">
                                            <asp:Label ID="lblDe" Text="De:" runat="server" CssClass="bold"></asp:Label></td>
                                        <td class="col-sm-4 text-left">
                                            <asp:TextBox ID="txtDe" runat="server" CssClass="form-control classTarget" Width="65%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDe" runat="server" ControlToValidate="txtDe" Text="Ingrese fecha inicial" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                        <td class="col-sm-2 text-right">
                                            <asp:Label ID="lblHasta" Text="Hasta:" runat="server" CssClass="bold"></asp:Label></td>
                                        <td class="col-sm-4 text-left">
                                            <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control classTarget" Width="65%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvHasta" runat="server" ControlToValidate="txtHasta" Text="Ingrese fecha final" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlPLD" runat="server" Visible="false">
                                <div class="text-center">
                                    <table class="table">
                                        <tr>
                                            <td class="col-sm-5 text-right">
                                                <asp:Label ID="lblPLD" runat="server" Text="Seleccione tipo de cliente" CssClass="bold"></asp:Label>
                                            </td>
                                            <td class="col-sm-7 text-left">
                                                <asp:RadioButtonList ID="rblPLD" runat="server">
                                                    <asp:ListItem Value="Todos" Text="Todos" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="Activos" Text="Activos"></asp:ListItem>
                                                    <asp:ListItem Value="Inactivos" Text="Inactivos"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlBuro" runat="server" Visible="false">
                                <div class="text-center">
                                    <table class="table">
                                        <tr>
                                            <td class="col-sm-5 text-right">
                                                <asp:Label ID="lblPeriodo" runat="server" Text="Seleccione periodo" CssClass="bold"></asp:Label>
                                            </td>
                                            <td class="col-sm-7 text-left">
                                                <asp:TextBox ID="txtPeriodo" runat="server" CssClass="form-control classTarget" Width="65%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPeriodo" runat="server" ControlToValidate="txtPeriodo" Text="Seleccione periodo" ValidationGroup="gpFinal" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Button ID="btnGetReport" CssClass="button" Text="Obtener reporte" OnClick="btnGetReport_Click" runat="server" Font-Bold="True" ValidationGroup="gpFinal" />
                        </div>
                    </div>
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
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label ID="lblReport" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <!-- Grid must be here -->
                            <div style="overflow-x: auto; width: 100%">
                                <!--Scroll horizontal -->
                                <asp:GridView ID="gvReport" runat="server" Width="100%" OnPageIndexChanging="gvReport_PageIndexChanging" ViewStateMode="Enabled" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="20" CssClass="gvwCasesPager" OnRowDataBound="gvReport_RowDataBound" AllowCustomPaging="False" AutoGenerateSelectButton="False">
                                    <%--<Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                Seleccionar
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    </Columns>--%>
                                    <AlternatingRowStyle BackColor="#CCCCCC" Wrap="False" />
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="Gray" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="text-center">
                                <asp:Button ID="btnDownloadFile" runat="server" CssClass="button" Text="Descargar archivo" OnClick="btnDownloadFile_Click" Font-Bold="true" />
                            </div>
                        </div>
                    </div>
                    <hr />
                    <footer>
                        <p><strong>CREDIJAL <%: DateTime.Today.ToString("dd-MM-yyyy") %> </strong></p>
                    </footer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <script type="text/javascript">
        function Validate() { //avoid going to the server side
            var reporType = $("#reportsType input:checked").val();
            if (reporType == undefined || reporType == "") {
                alert("Selecciona un reporte");
                return false;
            } else {
                if (reporType == "cnbv") {
                    var cnbvOption = $("#cnbvOptions input:checked").val();
                    if (cnbvOption == undefined || cnbvOption == "") {
                        alert("Selecciona un tipo de reporte");
                        return false;
                    }
                } else {
                    var otherOption = $("#otherOptions input:checked").val();
                    if (otherOption == undefined || otherOption == "") {
                        alert("Selecciona un tipo de reporte");
                        return false;
                    }
                }
            }
            return true;
        }


        $(document).ready(function () {

            $("#otherOptions").hide();
            $("#cnbvOptions").hide();

            /*
            $("#cnbv").click(function () {
                $("#otherOptions").hide();
                $("#cnbvOptions").show();
            });

            $("#pld").click(function () {
                $("#otherOptions").show();
                $("#cnbvOptions").hide();
            });

            $("#buroDeCredito").click(function () {
                $("#otherOptions").show();
                $("#cnbvOptions").hide();
            });
            */
        });
    </script>
</body>
</html>
