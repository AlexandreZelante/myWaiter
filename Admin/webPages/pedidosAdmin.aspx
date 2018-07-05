<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="pedidosAdmin.aspx.cs" Inherits="myWaiter.Admin.webPages.pedidosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Pedidos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Pedidos
    </div>
    <br /><br />
    <asp:GridView ID="gvPedido" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Número da Mesa" HeaderText="Número da Mesa" SortExpression="Número da Mesa" />
            <asp:BoundField DataField="Número da Conta" HeaderText="Número da Conta" InsertVisible="False" ReadOnly="True" SortExpression="Número da Conta" />
            <asp:BoundField DataField="Hora de início da Conta" HeaderText="Hora de início da Conta" SortExpression="Hora de início da Conta" />
            <asp:BoundField DataField="Hora do fim da Conta" HeaderText="Hora do fim da Conta" SortExpression="Hora do fim da Conta" />
            <asp:BoundField DataField="Número da Comanda" HeaderText="Número da Comanda" InsertVisible="False" ReadOnly="True" SortExpression="Número da Comanda" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Hora do início da Comanda" HeaderText="Hora do início da Comanda" SortExpression="Hora do início da Comanda" />
            <asp:BoundField DataField="Hora do Fim da Comanda" HeaderText="Hora do Fim da Comanda" SortExpression="Hora do Fim da Comanda" />
            <asp:BoundField DataField="Código do Produto" HeaderText="Código do Produto" InsertVisible="False" ReadOnly="True" SortExpression="Código do Produto" />
            <asp:BoundField DataField="Nome do Produto" HeaderText="Nome do Produto" SortExpression="Nome do Produto" />
            <asp:BoundField DataField="Valor do Pedido" HeaderText="Valor do Pedido" SortExpression="Valor do Pedido" />
            <asp:BoundField DataField="Valor total da Comanda" HeaderText="Valor total da Comanda" SortExpression="Valor total da Comanda" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_MyWaiterConnectionString3 %>" SelectCommand="getAllContas" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
