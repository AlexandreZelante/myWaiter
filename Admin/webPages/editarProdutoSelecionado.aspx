<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/webPages/masterPg.Master" AutoEventWireup="true" CodeBehind="editarProdutoSelecionado.aspx.cs" Inherits="myWaiter.Admin.webPages.editarProdutoSelecionado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><title>Editar <%Response.Write(Session["nomeProd"]); %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="header">
        Editar Produto
    </div>
    <br />
    <div id="Form">
        <table style="width:80%">
            <tr>
                <td class="bold" style="width:30%">
                    <asp:Label ID="Label1" runat="server" Text="Nome do Produto:" /></td>
                <td style="width:70%"><asp:Label ID="lblNomeProd" runat="server" ><%Response.Write(Session["nomeProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:TextBox ID="txtNome_Prod" runat="server" Width="50%" MaxLength="40" />
                </td>
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
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtDesc_Prod" runat="server" Width="50%" TextMode="MultiLine" Rows="5" MaxLength="500"/>
                </td>
            </tr>
            <tr>
                <td class="bold">
                    <asp:Label ID="Label3" runat="server" Text="Categoria do Produto:"/>
                </td>
                <td>
                    <asp:Label ID="lblCatProd" runat="server"><%Response.Write(Session["catProd"].ToString()); %></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCat" runat="server" >
                    <asp:ListItem Value="Saladas">Saladas</asp:ListItem>
                    <asp:ListItem Value="Grelhados">Grelhados</asp:ListItem>
                    <asp:ListItem Value="Pasta_&_Cia">Pasta & Cia</asp:ListItem>
                    <asp:ListItem Value="Peixes">Peixes</asp:ListItem>
                    <asp:ListItem Value="Sanduíches">Sanduíches</asp:ListItem>
                    <asp:ListItem Value="Burger">Burger</asp:ListItem>
                    <asp:ListItem Value="Porçoes">Porções</asp:ListItem>
                    <asp:ListItem Value="Prato_Feito">Prato Feito</asp:ListItem>
                    <asp:ListItem Value="Sobremesas">Sobremesas</asp:ListItem>
                    <asp:ListItem Value="Bebidas">Bebidas</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label4" runat="server" Text="Preço do Produto (R$):"/></td>
                <td><asp:Label ID="lblPreco" runat="server"><%Response.Write(Session["precoProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:TextBox ID="txtPrecoProd" runat="server" Width="15%" /></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label6" runat="server" Text="Quantidade de Porções em estoque:"/></td>
                <td><asp:Label ID="lblQtd" runat="server"><%Response.Write(Session["qtdProd"].ToString()); %></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:TextBox ID="txtQtdProd" runat="server" Width="15%" MaxLength="40"/></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label ID="Label5" runat="server" Text="Prioridade do Produto:"/></td>
                <td><asp:Label ID="lblPriorProd" runat="server"><%int prior=Convert.ToInt32(Session["priorProd"]);{
                                                                      if(prior==0){
                                                                          Response.Write("Normal");
                                                                      }
                                                                      else{
                                                                           Response.Write("Alta");
                                                                      }
                                                                  }
                                                                       %></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:DropDownList ID="ddlPrior" runat="server">
                        <asp:ListItem Value="0">Normal</asp:ListItem>
                        <asp:ListItem Value="1">Alta</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bold"><asp:Label runat="server" Text="Imagem Selecionada"/></td>
                <td><asp:Image ID="imgProd" runat="server" Height="170px" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:FileUpload ID="FileUpload" runat="server" /></td>
            </tr>
            <tr>
                <td>&nbsp</td>
                <td><asp:Label ID="lblMsg" runat="server" ForeColor="Red"  /><br /><asp:Label ID="lblMsg2" runat="server" ForeColor="Red"  /></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnCadastrar" runat="server" Text="Editar" OnClick="btnCadastrar_Click" /></td>
            </tr>
    </div>
    
</asp:Content>
