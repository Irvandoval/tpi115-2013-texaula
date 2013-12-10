<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menuppal.aspx.cs" Inherits="SistemaHospital.Presentacion.Administrador.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="style2">
        <strong style="font-size: larger">Menú principal</strong></h1>
    <asp:Panel ID="Panel1" runat="server" Height="359px" Width="921px">
        <h4 class="style1">
            <strong>Por favor eliga la opción deseada</strong></h4>
        <p class="style1">
            &nbsp;</p>
        <div style="height: 229px; width: 181px; margin-left: 385px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Menu ID="Menu1" runat="server" BackColor="White" 
                DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#284E98" StaticSubMenuIndent="10px" 
                style="font-size: large; text-align: left">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem Text="Gestión de Usuarios" Value="Gestión de Usuarios">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Gestion de Medicos" Value="Gestion de Medicos">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Gestión de Recepcionistas" 
                        Value="Gestión de Recepcionistas">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Gestión de Enfermeras" Value="Gestión de Enfermeras"></asp:MenuItem>
                    <asp:MenuItem Text="Gestión de Exámenes" Value="Gestión de Exámenes">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Gestion de  Tipo de Cáncer" 
                        Value="Gestion de  Tipo de Cáncer">
                    </asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
        </div>
    </asp:Panel>
</asp:Content>
