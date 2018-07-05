<%@ Page Title="" Language="C#" MasterPageFile="MasterCategoria.master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="myWaiter.Produto1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderConteudos" runat="server">
    <link href="../css/msgBoxProd.css" rel="stylesheet" />
    <table id="tabelaProdutoSozinho">
        <tr>
            <td rowspan="3" style="width: 329px">
                <asp:Image ID="imgProduto" runat="server" CssClass="imagem"/></td>

            <td colspan="3" style="height: 27px">
                <br />
                <asp:Label ID="lblNome" runat="server" Text="Label" CssClass="textoProduto" Font-Bold="True" Font-Names="Century Gothic" Font-Size="30px"></asp:Label></td>       
        </tr>
        <tr>
            <td colspan="2" style="height: 209px">
              <div id="divTextoProd">
                  <p style="font-family:'Century Gothic'"><strong>Descrição:</strong></p>
                  <br />
                  <asp:Label ID="lblDescricao" runat="server" Text="Label" Font-Names="Century Gothic"></asp:Label>
              </div>               
            </td>                     
            <td style="height: 209px">
                <br />
                <br />
                <div id="divQtde">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgUp" runat="server" Height="38px" ImageUrl="~/Mobile/images/pagina3/botaoProduto.fw.png" Width="55px" style="padding-top:10px" OnClick="imgUp_Click"/>                   
                    <br />                                  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                  
                    <asp:TextBox ID="txtNumero" runat="server" Height="34px" Width="52px" Font-Bold="True" Font-Size="XX-Large" ReadOnly="True">  1</asp:TextBox>
                    <br />                
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                     
                    <asp:ImageButton ID="imgDown" runat="server" Height="37px" ImageUrl="~/Mobile/images/pagina3/botaoProdutoBaixo.fw.png" Width="50px" style="padding-top:7px" OnClick="imgDown_Click"/>
                </div>
            </td>        
        </tr>
        <tr>
            <td style="width: 159px">
                <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Mobile/images/paginaProduto/btnCancelar.fw.png" OnClick="btnCancelar_Click"/></td>
            <td style="width: 178px">
                <asp:Image ID="imgAddAoPedido" runat="server" ImageUrl="~/Mobile/images/paginaProduto/btnAdicionarAoPedido.fw.png" CssClass="addImg"/></td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPreco" runat="server" Text="Label" CssClass="textoProduto" Font-Names="Century Gothic" Font-Size="22px"></asp:Label></td>
        </tr>
    </table>


    <div id="msgBoxProduto">

        <asp:Image ID="imgGarcom" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

        <div id="msgtext" class="msgText" runat="server">
            <p>Tem certeza que deseja adicionar esse produto ao pedido?</p>
        </div>

        <asp:ImageButton ID="btnCancelarBox" CssClass="btnCancellBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" />
        <asp:ImageButton ID="btnOk" CssClass="btnOkBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" OnClick="Yes_Click"  />
    </div>

    <script src="../../jquery-1.11.3.js"></script>
    <script>
        $(document).ready(function () {
            $(".addImg").click(function () {
                $("#msgBoxProduto").css("visibility", "visible");
                $("table").css("opacity", 0.2);
                $("table").css("pointer-events", "none");
                $("#masterCategoria").css("opacity", 0.2);
                $("#masterCategoria").css("pointer-events", "none");
                $("#header").css("opacity", 0.2);
                $("#header").css("pointer-events", "none");
            })
        })
    </script>
</asp:Content>
