<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="SistemaHospital.Presentacion.Recepcionista.principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <strong>Menu principal</strong></h1>
    <asp:Panel ID="Panel1" runat="server" Height="206px">
        <div style="height: 146px; width: 219px; margin-left: 349px">
            <br />
            <br />
            <asp:Menu ID="Menu1" runat="server" BackColor="White" 
                DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#284E98" StaticSubMenuIndent="10px" 
                style="text-align: left; font-size: large">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem Text="Expedientes" Value="Expedientes">
                        <asp:MenuItem Text="Nuevo Expediente" Value="Nuevo Expediente"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Pacientes" Value="Pacientes">
                        <asp:MenuItem Text="Nuevo Paciente" Value="Nuevo Paciente"></asp:MenuItem>
                        <asp:MenuItem Text="Elimina Paciente" Value="Elimina Paciente"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
        </div>
    </asp:Panel>
</asp:Content>
