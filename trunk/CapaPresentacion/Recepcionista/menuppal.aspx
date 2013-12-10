<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menuppal.aspx.cs" Inherits="SistemaHospital.Presentacion.Recepcionista.menuppal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Menú Principal</h1>
    <asp:Panel ID="Panel1" runat="server" Height="181px" style="margin-left: 351px">
        <br />
        <br />
        <asp:Menu ID="Menu1" runat="server" BackColor="White" 
    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Medium" 
    ForeColor="#284E98" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <Items>
                <asp:MenuItem Text="Gestion de Pacientes" Value="Gestion de Pacientes" 
                    NavigateUrl="~/Recepcionista/gPacientes.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="Gestion de Expedientes" Value="Gestion de Expedientes">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#507CD1" />
        </asp:Menu>
    </asp:Panel>
</asp:Content>
