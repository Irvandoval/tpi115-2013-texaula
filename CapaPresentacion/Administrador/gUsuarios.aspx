<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gUsuarios.aspx.cs" Inherits="SistemaHospital.Presentacion.Administrador.gUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <strong>Gestión de usuarios</strong></h1>
    <p>
        <strong>
    </p>
    <asp:GridView ID="tUsuarios" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        style="margin-left: 241px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="idUsuario" HeaderText="ID" />
            <asp:BoundField AccessibleHeaderText="Usuario" DataField="userName" 
                HeaderText="Usuario" />
            <asp:BoundField DataField="pass" HeaderText="pass" />
            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <h1>
        </strong>
    </h1>
</asp:Content>
