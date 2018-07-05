<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="mainAdmin.aspx.cs" Inherits="myWaiter.Admin.webPages.mainAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>myWaiter Administrador</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
<div id="header">
        Selecione a operação:
    </div>
    <br /><br />
    <div id="Operacoes">
        <asp:HyperLink CssClass="link" NavigateUrl="~/Admin/webPages/mesasAdmin.aspx" runat="server">
            <div id="Mesas" class="oper">
                <h3>Mesas</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/Mesa.png" runat="server" Height="200px" /><br />
                Visualize e altere o status das mesas
            </div>
        </asp:HyperLink>
        &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:HyperLink CssClass="link" NavigateUrl="~/Admin/webPages/pedidosAdmin.aspx" runat="server">
            <div id="Pedidos" class="oper">
                <h3>Pedidos</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/Conta.png" runat="server" Height="200px" /><br />
                Visualize o status dos pedidos
                <br />
            </div>
            </asp:HyperLink>
        &nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:HyperLink CssClass="link" NavigateUrl="produtosHome.aspx" runat="server">
            <div id="Produtos" class="oper">
                <h3>Produtos</h3>
                <asp:Image CssClass="img" ImageUrl="~/Admin/srcs/Menu_256.png" runat="server" Height="200px" /><br />
                Visualize, altere e adicione produtos
            </div>
        </asp:HyperLink>
    </div>
</asp:Content>
