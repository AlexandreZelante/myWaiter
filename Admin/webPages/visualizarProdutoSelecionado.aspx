<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="visualizarProdutoSelecionado.aspx.cs" Inherits="myWaiter.Admin.webPages.visualizarProdutoSelecionado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Visualizar <%Response.Write(Session["nomeProd"]); %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Visualizar Produto
    </div>
    <br />
    <div id="Form">
        <table style="width: 80%;">
            <tr>
                <td class="bold" style="width: 30%">
                    <asp:Label ID="Label1" runat="server" Text="Nome do Produto:" /></td>
                <td style="width: 70%">
                    <asp:Label ID="lblNomeProd" runat="server"><%Response.Write(Session["nomeProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label2" runat="server" Text="Descrição do Produto (Max: 500 caracteres):" />
                </td>
                <td>
                    <asp:Label ID="lblDesc" runat="server"><%Response.Write(Session["descProd"].ToString()); %></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label3" runat="server" Text="Categoria do Produto:" />
                </td>
                <td>
                    <asp:Label ID="lblCatProd" runat="server"><%Response.Write(Session["catProd"].ToString()); %></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label4" runat="server" Text="Preço do Produto (R$):" /></td>
                <td>
                    <asp:Label ID="lblPreco" runat="server"><%Response.Write(Session["precoProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label6" runat="server" Text="Quantidade de Porções em estoque:" /></td>
                <td>
                    <asp:Label ID="lblQtd" runat="server"><%Response.Write(Session["qtdProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label5" runat="server" Text="Prioridade do Produto:" /></td>
                <td>
                    <asp:Label ID="lblPriorProd" runat="server"><%int prior = Convert.ToInt32(Session["priorProd"]);
                                                                  {
                                                                      if (prior == 0)
                                                                      {
                                                                          Response.Write("Normal");
                                                                      }
                                                                      else
                                                                      {
                                                                          Response.Write("Alta");
                                                                      }
                                                                  }
                                                                       %></asp:Label></td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label runat="server" Text="Imagem Selecionada" /></td>
                <td>
                    <asp:Image ID="imgProd" runat="server" Height="170px" /></td>
            </tr>
            <tr>
                <td>&nbsp</td>
                <td>
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
                    <asp:Label ID="lblMsg2" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
                <td><asp:Button Text="Editar Esse Produto" runat="server" ID="btnEdit" OnClick="btnEdit_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
