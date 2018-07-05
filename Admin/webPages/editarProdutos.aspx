<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="editarProdutos.aspx.cs" Inherits="myWaiter.Admin.webPages.editarProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Editar Produtos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Editar Produto
    </div>
    <br /><br />
    <div class="white">
        <asp:Label runat="server" Text="Pesquise o nome do produto: " /><asp:TextBox ID="txtNomeProd_Pesq" runat="server" Width="50%" />
        <asp:Button runat="server" Text="Buscar" ID="btnSearch" OnClick="btnSearch_Click" />
        <br /><br /><br />
        <asp:GridView ID="gvProd" CssClass="grid" Font-Size="Large" OnSelectedIndexChanged="gvProd_SelectedIndexChanged" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"  ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Id">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" SelectText="Editar" SelectImageUrl="../srcs/pencil125.png" ButtonType="Image" ControlStyle-Height="35px" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" SortExpression="Categoria" />
                <asp:BoundField DataField="Disponibilidade" HeaderText="Disponibilidade" ReadOnly="True" SortExpression="Disponibilidade" />
                <asp:BoundField DataField="Prioridade" HeaderText="Prioridade" ReadOnly="True" SortExpression="Prioridade" />
                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
                <asp:BoundField DataField="Preço (R$)" HeaderText="Preço (R$)" SortExpression="Preço (R$)" />
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
        
    </div>
</asp:Content>
