<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="adicionarProdutos.aspx.cs" Inherits="myWaiter.Admin.webPages.adicionarProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Adicionar Produtos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Adicionar Produto
    </div>
    <br /><br />
    <div id="Form">
        <table style="width:80%">
            <tr>
                <td style="width:30%" class="bold"><asp:Label ID="Label1" runat="server" Text="Nome do Produto:"/></td>
                <td style="width:70%"><asp:TextBox ID="txtNome_Prod" runat="server" Width="50%" MaxLength="40"/></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label2" runat="server" Text="Descrição do Produto (Max: 500 caracteres):"/></td>
                <td><asp:TextBox ID="txtDesc_Prod" runat="server" Width="50%" TextMode="MultiLine" Rows="5" MaxLength="200"/></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label3" runat="server" Text="Categoria do Produto:"/></td>
                <td><asp:DropDownList ID="ddlCat" runat="server" >
                    <asp:ListItem Value="Saladas">Saladas</asp:ListItem>
                    <asp:ListItem Value="Grelhados">Grelhados</asp:ListItem>
                    <asp:ListItem Value="Pasta_E_Cia">Pasta & Cia</asp:ListItem>
                    <asp:ListItem Value="Peixes">Peixes</asp:ListItem>
                    <asp:ListItem Value="Sanduíches">Sanduíches</asp:ListItem>
                    <asp:ListItem Value="Burger">Burger</asp:ListItem>
                    <asp:ListItem Value="Porçoes">Porções</asp:ListItem>
                    <asp:ListItem Value="Prato_Feito">Prato Feito</asp:ListItem>
                    <asp:ListItem Value="Sobremesas">Sobremesas</asp:ListItem>
                    <asp:ListItem Value="Bebidas">Bebidas</asp:ListItem>
                    </asp:DropDownList></td>
                
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label4" runat="server" Text="Preço do Produto (R$):"/></td>
                <td><asp:TextBox ID="txtPreco" runat="server" Width="15%" /></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label6" runat="server" Text="Quantidade de Porções em estoque:"/></td>
                <td><asp:TextBox ID="txtQtd" runat="server" Width="15%" MaxLength="40"/></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label5" runat="server" Text="Prioridade do Produto:"/></td>
                <td><asp:DropDownList ID="ddlPrior" runat="server">
                        <asp:ListItem Value="0">Normal</asp:ListItem>
                        <asp:ListItem Value="1">Alta</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label runat="server" Text="Selecione a Imagem"/></td>
                <td><asp:FileUpload ID="FileUpload" runat="server" /></td>
                
            </tr>
            <tr>
                <td>&nbsp</td>
                <td><asp:Label ID="lblMsg" runat="server" ForeColor="Red"  /><br /><asp:Label ID="lblMsg2" runat="server" ForeColor="Red"  /></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" /></td>
            </tr>
            
        </table>
    </div>

</asp:Content>
