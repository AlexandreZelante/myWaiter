<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="produtosHome.aspx.cs" Inherits="myWaiter.Admin.webPages.produtosHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Produtos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        O que você deseja?
    </div>
    <br />
    <div id="Operacoes">
        <asp:HyperLink CssClass="link" NavigateUrl="~/Admin/webPages/visualizarProdutos.aspx" runat="server">
            <div id="View" class="oper">
                <h3>Visualizar Produtos</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/eye22.png" runat="server" Height="200px" /><br />
            </div>
        </asp:HyperLink>
        &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:HyperLink CssClass="link" NavigateUrl="~/Admin/webPages/editarProdutos.aspx" runat="server">
            <div id="Edit" class="oper">
                <h3>Editar Produtos</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/pencil125.png" runat="server" Height="200px" /><br />
            </div>
            </asp:HyperLink>
        &nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:HyperLink CssClass="link" NavigateUrl="~/Admin/webPages/adicionarProdutos.aspx" runat="server">
            <div id="Add" class="oper">
                <h3>Adicionar Produtos</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/add30.png" runat="server" Height="200px" /><br />
            </div>
        </asp:HyperLink>
    </div>
</asp:Content>
